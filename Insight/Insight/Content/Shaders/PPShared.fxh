float viewportWidth;
float viewportHeight;
float4x3 Bones[72];
uniform int BoneCount;

struct GameSkinnedInput
{
    float4 Position : POSITION0;
    int4 Indices : BLENDINDICES0;
    float4 Weights : BLENDWEIGHT0;
    float2 UV : TEXCOORD0;
    float3 Normal : NORMAL0;
};

struct GameSkinnedInputShadows
{
    float4 Position : POSITION0;
    int4 Indices : BLENDINDICES0;
    float4 Weights : BLENDWEIGHT0;
};

// Calculate the 2D screen position of a 3D position
float2 postProjToScreen(float4 position)
{
	float2 screenPos = position.xy / position.w;
	return 0.5f * (float2(screenPos.x, -screenPos.y) + 1);
}
// Calculate the size of one half of a pixel, to convert
// between texels and pixels
float2 halfPixel()
{
	return 0.5f / float2(viewportWidth, viewportHeight);
}

void Skin(inout GameSkinnedInput input, uniform int boneCount)
{
    float4x3 skinning = 0;

	[unroll]
    for (int i = 0; i < boneCount; i++)
    {
        skinning += Bones[input.Indices[i]] * input.Weights[i];
    }

    input.Position.xyz = mul(input.Position, skinning);
    input.Normal = mul(input.Normal, (float3x3) skinning);
}

void Skin(inout GameSkinnedInputShadows input, uniform int boneCount)
{
    float4x3 skinning = 0;

    for (int i = 0; i < boneCount; i++)
    {
        skinning += Bones[input.Indices[i]] * input.Weights[i];
    }

    input.Position.xyz = mul(input.Position, skinning);
}

