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
float4x4 lightViewProjection;

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

struct CreateShadowVertexInput 
{
	float4 Position : POSITION;
};

struct VertexShaderOutput
{
	float4 Position : POSITION;
	float3 Normal : NORMAL;
	float3 View : TEXCOORD0;
};

struct CreateShadowVertexOutput
{
	float4 Position : POSITION;
	float2 Depth :TEXCOORD0;
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

//			ShadowMap
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

//


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

technique CreateShadow 
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL ShadowMapVS();
		PixelShader = compile PS_SHADERMODEL ShadowMapPS();
	}
};