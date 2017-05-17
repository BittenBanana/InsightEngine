#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float4x4 World;
float4x4 lightViewProjection;

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float4 Color : COLOR0;
};

struct CreateShadowVertexOutput
{
	float4 Position : POSITION;
	float2 Depth :TEXCOORD0;
};

struct CreateShadowVertexInput
{
	float4 Position : POSITION;
};

CreateShadowVertexOutput ShadowMapVS(in CreateShadowVertexInput i)
{
	CreateShadowVertexOutput o = (CreateShadowVertexOutput)0;
	o.Position = mul(i.Position, mul(World, lightViewProjection));
	o.Depth = o.Position.zw;

	return o;
}

float4 ShadowMapPS(in CreateShadowVertexOutput i) : COLOR0
{
	return i.Depth.x / i.Depth.y;
}

technique CreateShadow
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL ShadowMapVS();
		PixelShader = compile PS_SHADERMODEL ShadowMapPS();
	}
};