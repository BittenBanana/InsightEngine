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

float4 AmbientColor = float4(1, 1, 0, 1);
float AmbientIntensity = 0.2;

float3 LightDirection = normalize(float3(-0.5, -0.5, 0.0));
float4 DiffuseColor = float4(1, 0, 1, 1);
float DiffuseIntensity = 0.4;

float4 SpecularColor = float4(1,1,1,1);
float SpecularIntensity = 0.3;

float3 CamPosition;

struct VertexShaderInput
{
	float4 Position : POSITION;
	float3 Normal : NORMAL;
	float3 View : TEXCOORD0;
};


struct VertexShaderOutput
{
	float4 Position : POSITION;
	float3 Normal : NORMAL;
	float3 View : TEXCOORD0;
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

	return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR0
{
	float4 normal = float4(input.Normal, 1.0);
	float4 diffuse = saturate(dot(-LightDirection,normal));
	float4 reflect = normalize(2 * diffuse*normal - float4(LightDirection, 1.0));
	float4 specular = pow(saturate(dot(reflect, input.View)),15 );

	return AmbientColor * AmbientIntensity + DiffuseIntensity * DiffuseColor * diffuse + SpecularIntensity*SpecularColor*specular;
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