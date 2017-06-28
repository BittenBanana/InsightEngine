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

texture2D BloodTexture1;

sampler BloodSampler1 = sampler_state
{
    texture = <BloodTexture1>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};

texture2D BloodTexture2;

sampler BloodSampler2 = sampler_state
{
    texture = <BloodTexture2>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};

texture2D BloodTexture3;

sampler BloodSampler3 = sampler_state
{
    texture = <BloodTexture3>;
    addressU = wrap;
    addressV = wrap;
    minfilter = anisotropic;
    magfilter = anisotropic;
    mipfilter = linear;
};

float colorPercentage = 0;
float brightness = 1.0;

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};
 
float4 PixelShaderFunction(VertexShaderOutput i) : COLOR0
{
    float4 color = tex2D(TextureSampler, i.TextureCoordinates);
    float4 blood1 = tex2D(BloodSampler1, i.TextureCoordinates);
    float4 blood2 = tex2D(BloodSampler2, i.TextureCoordinates);
    float4 blood3 = tex2D(BloodSampler3, i.TextureCoordinates);
    float3 value;
    //colorPercentage = clamp(colorPercentage, 0, .75);
    float invColorPercentage = 1 - colorPercentage;
    //if (colorPercentage >= 0.5 && colorPercentage < .75)
    //{
    //    value.r = (color.r * invColorPercentage + blood2.r * colorPercentage);
    //    value.g = (color.g * invColorPercentage + blood2.g * colorPercentage);
    //    value.b = (color.b * invColorPercentage + blood2.b * colorPercentage);
    //}
    //else if(colorPercentage >= .75)
    //{
    //    value.r = (color.r * invColorPercentage + blood3.r * colorPercentage);
    //    value.g = (color.g * invColorPercentage + blood3.g * colorPercentage);
    //    value.b = (color.b * invColorPercentage + blood3.b * colorPercentage);
    //}
    //else
    //{
        value.r = (color.r * invColorPercentage + blood1.r * colorPercentage);
        value.g = (color.g * invColorPercentage + blood1.g * colorPercentage);
        value.b = (color.b * invColorPercentage + blood1.b * colorPercentage);
    //}

    color.rgb = value;
    color.a = 1;

	color.rgba /= brightness;
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