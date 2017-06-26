#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float4x4 World;
float4x4 View;
float4x4 Projection;

texture2D NormalTexture;
sampler2D normalSampler = sampler_state
{
    Texture = <NormalTexture>;
    Minfilter = linear;
    MagFilter = linear;
    MipFilter = linear;
    AddressU = Wrap;
    AddressV = Wrap;
};
bool NormalEnabled = false;

#include "PPShared.fxh"

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float3 Normal : NORMAL0;
    float2 UV : TEXCOORD0;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
    float2 UV : TEXCOORD0;
	float2 Depth : TEXCOORD1;
	float3 Normal : TEXCOORD2;
};

struct PixelShaderOutput
{
	float4 Normal : COLOR0;
	float4 Depth : COLOR1;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	float4x4 viewProjection = mul(View, Projection);
	float4x4 worldViewProjection = mul(World, viewProjection);

	output.Position = mul(input.Position, worldViewProjection);
    output.UV = input.UV;
	output.Normal = mul(input.Normal, World);
	output.Depth.xy = output.Position.zw;

	return output;
}

VertexShaderOutput SkinnedVS(in GameSkinnedInput input)
{
    Skin(input, BoneCount);

    VertexShaderOutput output = (VertexShaderOutput) 0;

    float4x4 viewProjection = mul(View, Projection);
    float4x4 worldViewProjection = mul(World, viewProjection);

    output.Position = mul(input.Position, worldViewProjection);
    output.UV = input.UV;
    output.Normal = mul(input.Normal, World);
    output.Depth.xy = output.Position.zw;

    return output;
}

PixelShaderOutput MainPS(VertexShaderOutput input)
{
	PixelShaderOutput output = (PixelShaderOutput)0;
	
	float4 color = 0;

	color.r = input.Depth.x / input.Depth.y;

    float3 normal = tex2D(normalSampler, input.UV).rgb;
    normal = normal * 2 - 1;

    if (!NormalEnabled)
        normal = float3(1, 1, 1);

	output.Normal.xyz = (normalize(input.Normal * normal).xyz / 2) + .5;

	color.a = 1;
	output.Normal.a = 1;

	output.Depth = color;

	return output;
}

technique Basic
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};

technique Skinned
{
    pass P0
    {
        VertexShader = compile VS_SHADERMODEL SkinnedVS();
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};