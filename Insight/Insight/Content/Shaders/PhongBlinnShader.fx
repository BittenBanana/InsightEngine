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

texture2D BasicTexture;
sampler2D basicTextureSampler = sampler_state
{
	texture = <BasicTexture>;
	addressU = wrap;
	addressV = wrap;
	minfilter = anisotropic;
	magfilter = anisotropic;
	mipfilter = linear;
};
bool TextureEnabled = false;

texture2D AOTexture;
sampler AOSampler = sampler_state
{
    texture = <AOTexture>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};
bool AOEnabled = false;

texture2D LightTexture;
sampler2D LightTextureSampler = sampler_state
{
	texture = <LightTexture>;
	minfilter = point;
	magfilter = point;
	mipfilter = point;
};

float4 AmbientColor = float4(1, 1, 1, 1);
float AmbientIntensity = 0.5;

float3 LightDirection = normalize(float3(-0.5, -0.5, 0.0));
float4 DiffuseColor = float4(1, 1, 1, 1);
float DiffuseIntensity = 0.4;

float4 SpecularColor = float4(1,1,1,1);
float SpecularIntensity = 0.3;

float3 CamPosition;

#include "PPShared.fxh"

struct VertexShaderInput
{
	float4 Position : POSITION;
	float2 UV : TEXCOORD0;
	float3 Normal : NORMAL;
//	float3 View : TEXCOORD1;
};


struct VertexShaderOutput
{
	float4 Position : POSITION;
	float2 UV : TEXCOORD0;
	float4 PositionCopy : TEXCOORD1;
	float3 Normal : NORMAL;
	float3 View : TEXCOORD2;
};

//			Blinn
VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);
	float3 normal = normalize(mul(input.Normal, World));
	output.Normal = normal;
	output.View = normalize(float4(CamPosition, 1.0) - worldPosition);

	output.PositionCopy = output.Position;
	output.UV = input.UV;

	return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR0
{
	// Sample model's texture
	float3 basicTexture = tex2D(basicTextureSampler, input.UV);

    float3 ao = tex2D(AOSampler, input.UV);

	if (!TextureEnabled)
		basicTexture = float4(1, 1, 1, 1);

    if(!AOEnabled)
        ao = float3(1, 1, 1);

	// Extract lighting value from light map
	float2 texCoord = postProjToScreen(input.PositionCopy) +
		halfPixel();
	float3 light = tex2D(LightTextureSampler, texCoord);

	float4 normal = float4(input.Normal, 1.0);
	float4 diffuse = saturate(dot(-LightDirection,normal));
	float4 reflect = normalize(2 * diffuse*normal - float4(LightDirection, 1.0));
	float4 specular = pow(saturate(dot(reflect, input.View)),15 );

	light += AmbientColor.rgb * AmbientIntensity * ao;

	float4 BlinnColor = DiffuseIntensity * DiffuseColor * diffuse + SpecularIntensity*SpecularColor*specular;

	return float4(basicTexture * BlinnColor.rgb * light, 1);
}

technique Blinn
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}

	/*pass P1 
	{
		VertexShader = compile VS_SHADERMODEL ShadowMapVS();
		PixelShader = compile PS_SHADERMODEL ShadowMapPS();
	}*/
};