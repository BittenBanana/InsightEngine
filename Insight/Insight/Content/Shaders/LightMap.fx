﻿#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float4x4 WorldViewProjection;
float4x4 InvViewProjection;

texture2D DepthTexture;
texture2D NormalTexture;

sampler2D depthSampler = sampler_state 
{
	texture = <DepthTexture>;
	minfilter = point;
	magfilter = point;
	mipfilter = point;
};
sampler2D normalSampler = sampler_state
{
	texture = <NormalTexture>;
	minfilter = point;
	magfilter = point;
	mipfilter = point;
};

float3 LightColor;
float3 LightPosition;
float LightAttenuation;

// Include shared functions
#include "PPShared.fxh"

struct VertexShaderInput
{
	float4 Position : POSITION0;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float4 LightPosition : TEXCOORD0;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output;
	output.Position = mul(input.Position, WorldViewProjection);
	output.LightPosition = output.Position;

	return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
	// Find the pixel coordinates of the input position in the depth
	// and normal textures
	float2 texCoord = postProjToScreen(input.LightPosition) + halfPixel();

	// Extract the depth for this pixel from the depth map
	float4 depth = tex2D(depthSampler, texCoord);

	// Recreate the position with the UV coordinates and depth value
	float4 position;
	position.x = texCoord.x * 2 - 1;
	position.y = (1 - texCoord.y) * 2 - 1;
	position.z = depth.r;
	position.w = 1.0f;

	// Transform position from screen space to world space
	position = mul(position, InvViewProjection);
	position.xyz /= position.w;

	// Extract the normal from the normal map and move from
	// 0 to 1 range to -1 to 1 range
	float4 normal = (tex2D(normalSampler, texCoord) - .5) * 2;

	// Perform the lighting calculations for a point light
	float3 lightDirection = normalize(LightPosition - position.xyz);
	float lighting = clamp(dot(normal.rgb, lightDirection), 0, 1);

	// Attenuate the light to simulate a point light
	float d = distance(LightPosition, position.xyz);
	float att = 1 - pow(d / LightAttenuation, 2);

	return float4(LightColor * lighting * att, 1);
}

technique LightMap
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};