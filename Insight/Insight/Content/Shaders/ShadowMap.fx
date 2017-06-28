#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float4x4 WorldViewProjection;
float4x4 InvViewProjection;

texture2D ShadowMap;
sampler2D shadowSampler = sampler_state
{
    texture = <ShadowMap>;
    minfilter = point;
    magfilter = point;
    mipfilter = point;
};

texture2D NormalTexture;
sampler2D normalSampler = sampler_state
{
    texture = <NormalTexture>;
    minfilter = point;
    magfilter = point;
    mipfilter = point;
};

float3 LightPosition;
float LightAttenuation;

#include "PPShared.fxh"

struct CreateShadowVertexOutput
{
	float4 Position : POSITION0;
	float4 ShadowPosition :TEXCOORD0;
};

struct CreateShadowVertexInput
{
	float4 Position : POSITION0;
};

CreateShadowVertexOutput ShadowMapVS(in CreateShadowVertexInput i)
{
	CreateShadowVertexOutput o = (CreateShadowVertexOutput)0;
	o.Position = mul(i.Position, WorldViewProjection);
    o.ShadowPosition = o.Position;

	return o;
}

float4 ShadowMapPS(in CreateShadowVertexOutput i) : COLOR0
{
    float2 texCoord = postProjToScreen(i.ShadowPosition) + halfPixel();

    float4 depth = tex2D(shadowSampler, texCoord);

    float4 position;
    position.x = texCoord.x * 2 - 1;
    position.y = (1 - texCoord.y) * 2 - 1;
    position.z = depth.r;
    position.w = 1.0f;

    position = mul(position, InvViewProjection);
    position.xyz /= position.w;

    float4 normal = (tex2D(normalSampler, texCoord) - .5) * 2;

	// Perform the lighting calculations for a point light
    float3 lightDirection = normalize(LightPosition - position.xyz);
    float lighting = clamp(dot(normal.rgb, lightDirection), 0, 1);

	// Attenuate the light to simulate a point light
    float d = distance(LightPosition, position.xyz);
    float att = 1 - pow(d / LightAttenuation, 2);

    return position;
}

technique Basic
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL ShadowMapVS();
		PixelShader = compile PS_SHADERMODEL ShadowMapPS();
	}
};