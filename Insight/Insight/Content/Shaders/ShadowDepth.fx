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

float FarPlane = 10000;

#include "PPShared.fxh"

struct VertexShaderInput
{
	float4 Position : POSITION0;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float4 ScreenPosition : TEXCOORD0;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

    float4x4 wvp = mul(World, mul(View, Projection));
    float4 position = mul(input.Position, wvp);

    output.Position = position;
	output.ScreenPosition = position;

	return output;
}

VertexShaderOutput SkinnedVS(in GameSkinnedInput input)
{
    Skin(input, 3);

    VertexShaderOutput output = (VertexShaderOutput) 0;

    float4x4 wvp = mul(World, mul(View, Projection));
    float4 position = mul(input.Position, wvp);

    output.Position = position;
    output.ScreenPosition = position;

    return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float depth = clamp(input.ScreenPosition.z / input.ScreenPosition.w, 0, 1);
    return float4(depth, 0, 0, 1);
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