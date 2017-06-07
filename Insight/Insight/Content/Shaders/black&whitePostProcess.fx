#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

//------------------------------ TEXTURE PROPERTIES ----------------------------
// This is the texture that SpriteBatch will try to set before drawing
texture2D ScreenTexture;
 
// Our sampler for the texture, which is just going to be pretty simple
sampler TextureSampler = sampler_state
{
    texture = <ScreenTexture>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};

texture2D BloodTexture;

sampler BloodSampler = sampler_state
{
    texture = <BloodTexture>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};

float colorPercentage = 0;

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};
 
float4 PixelShaderFunction(VertexShaderOutput i) : COLOR0
{
    float4 color = tex2D(TextureSampler, i.TextureCoordinates);
    float4 blood = tex2D(BloodSampler, i.TextureCoordinates);
    float3 value;

    float invColorPercentage = 1 - colorPercentage;

    value.r = (color.r * invColorPercentage + blood.r * colorPercentage);
    value.g = (color.g * invColorPercentage + blood.g * colorPercentage);
    value.b = (color.b * invColorPercentage + blood.b * colorPercentage);
    color.rgb = value;
    color.a = 1;
    return color;
}
 
//-------------------------- TECHNIQUES ----------------------------------------
// This technique is pretty simple - only one pass, and only a pixel shader
technique Plain
{
    pass Pass1
    {
        PixelShader = compile PS_SHADERMODEL PixelShaderFunction();
    }
}