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
sampler2D AOSampler = sampler_state
{
    texture = <AOTexture>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};
bool AOEnabled = false;

texture2D MetalnessTexture;
sampler2D metalnessSampler = sampler_state
{
    texture = <MetalnessTexture>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};
bool MetalnessEnabled = false;

texture2D LightTexture;
sampler2D LightTextureSampler = sampler_state
{
	texture = <LightTexture>;
	minfilter = point;
	magfilter = point;
	mipfilter = point;
};

bool DoShadowMapping = true;
float4x4 ShadowView;
float4x4 ShadowProjection;
float4x4 ShadowWorld;
texture2D ShadowMap;
sampler2D shadowSampler = sampler_state
{
    texture = <ShadowMap>;
    minfilter = point;
    magfilter = point;
    mipfilter = point;
};

float3 ShadowLightPosition;
float ShadowFarPlane;
float ShadowMult = 0.3f;
float ShadowBias = 1.0f / 100.0f;


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
};


struct VertexShaderOutput
{
	float4 Position : POSITION;
	float2 UV : TEXCOORD0;
	float4 PositionCopy : TEXCOORD1;
	float3 Normal : NORMAL;
	float3 View : TEXCOORD2;
    float4 ShadowScreenPosition : TEXCOORD3;
};

float sampleShadowMap(float2 UV)
{
    if (UV.x < 0 || UV.x > 1 || UV.y < 0 || UV.y > 1)
        return 1;
    return tex2D(shadowSampler, UV).r;
}

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);
	float3 normal = normalize(mul(input.Normal, (float3x4)World));
	output.Normal = normal;
	output.View = normalize(float4(CamPosition, 1.0) - worldPosition);
    output.ShadowScreenPosition = mul(mul(input.Position, World), mul(ShadowView, ShadowProjection));

	output.PositionCopy = output.Position;
	output.UV = input.UV;

	return output;
}

VertexShaderOutput SkinnedVS(in GameSkinnedInput input)
{
    Skin(input, BoneCount);

    VertexShaderOutput output = (VertexShaderOutput) 0;

    float4 worldPosition = mul(input.Position, World);
    float4 viewPosition = mul(worldPosition, View);
    output.Position = mul(viewPosition, Projection);
    float3 normal = normalize(mul(input.Normal, (float3x4) World));
    output.Normal = normal;
    output.View = normalize(float4(CamPosition, 1.0) - worldPosition);
    output.ShadowScreenPosition = mul(mul(input.Position, World), mul(ShadowView, ShadowProjection));

    output.PositionCopy = output.Position;
    output.UV = input.UV;

    return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR0
{
	// Sample model's texture
	float3 basicTexture = tex2D(basicTextureSampler, input.UV);

    float3 ao = tex2D(AOSampler, input.UV);

    float3 metalness = tex2D(metalnessSampler, input.UV);

    float2 shadowTexCoord = postProjToScreen(input.ShadowScreenPosition)
 + halfPixel();
 //   float mapDepth = sampleShadowMap(shadowTexCoord);

 //   float realDepth = input.ShadowScreenPosition.z / input.ShadowScreenPosition.w;
 //   float shadow = 1;
 //   if (realDepth - ShadowBias <= mapDepth)
 //       shadow = ShadowMult;

    float2 ProjectedTexCoords;
    ProjectedTexCoords[0] = input.ShadowScreenPosition.x / input.ShadowScreenPosition.w / 2.0f + 0.5f;
    ProjectedTexCoords[1] = -input.ShadowScreenPosition.y / input.ShadowScreenPosition.w / 2.0f + 0.5f;

    float shadow = 1;
    if(DoShadowMapping)
    if ((saturate(ProjectedTexCoords).x == ProjectedTexCoords.x) && (saturate(ProjectedTexCoords).y == ProjectedTexCoords.y))
    {
        float depthStoredInShadowMap = tex2D(shadowSampler, ProjectedTexCoords).r;
        float realDistance = input.ShadowScreenPosition.z / input.ShadowScreenPosition.w;
        if (realDistance - ShadowBias >= depthStoredInShadowMap)
        {
            shadow = ShadowMult;
        }
    }

	if (!TextureEnabled)
		basicTexture = float4(1, 1, 1, 1);

    if(!AOEnabled)
        ao = float3(1, 1, 1);

    if(!MetalnessEnabled)
        metalness = float3(1, 1, 1);

	// Extract lighting value from light map
	float2 texCoord = postProjToScreen(input.PositionCopy) +
		halfPixel();
	float3 light = tex2D(LightTextureSampler, texCoord);

	float4 normal = float4(input.Normal, 1.0);
	float4 diffuse = saturate(dot(-LightDirection,normal.rgb));
	float4 reflect = normalize(2 * diffuse*normal - float4(LightDirection, 1.0));
	float4 specular = pow(saturate(dot(reflect.rgb, input.View)),15 );

    light += AmbientColor.rgb * AmbientIntensity * ao * shadow;

    float3 BlinnColor = (AmbientColor.rgb * ao + DiffuseColor.rgb * diffuse.rgb + metalness * SpecularColor.rgb * specular.rgb).rgb;

    return float4(basicTexture * BlinnColor.rgb * light, 1);
    //return tex2D(shadowSampler, shadowTexCoord);

}

technique Basic
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

technique Skinned
{
    pass P0
    {
        VertexShader = compile VS_SHADERMODEL SkinnedVS();
        PixelShader = compile PS_SHADERMODEL MainPS();
    }

};