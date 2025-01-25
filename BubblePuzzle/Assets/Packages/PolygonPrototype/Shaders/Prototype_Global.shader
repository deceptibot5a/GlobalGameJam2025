Shader"Universal Render Pipeline/CustomShader"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        _Grid("Grid Texture", 2D) = "white" {}
        _GridScale("Grid Scale", Float) = 5
        _Falloff("Falloff", Float) = 50
        _OverlayAmount("Overlay Amount", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderPipeline" = "UniversalRenderPipeline" }
        
        Pass
        {
Name"MainPass"
            Tags
{"LightMode" = "UniversalForward"
}
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
struct Attributes
{
    float4 position : POSITION;
    float3 normal : NORMAL;
    float2 uv : TEXCOORD0;
};

struct Varyings
{
    float4 position : SV_POSITION;
    float2 uv : TEXCOORD0;
    float3 worldPos : TEXCOORD1;
    float3 worldNormal : TEXCOORD2;
};

sampler2D _Grid;
float4 _BaseColor;
float _GridScale;
float _Falloff;
float _OverlayAmount;

Varyings vert(Attributes v)
{
    Varyings o;
    o.position = TransformObjectToHClip(v.position);
    o.uv = v.uv;
    o.worldPos = TransformObjectToWorld(v.position);
    o.worldNormal = TransformObjectToWorldNormal(v.normal);
    return o;
}

half4 frag(Varyings i) : SV_Target
{
                // Triplanar Mapping Logic
    float3 projNormal = pow(abs(i.worldNormal), _Falloff);
    projNormal /= projNormal.x + projNormal.y + projNormal.z;

    float3 nsign = sign(i.worldNormal);

                // Sampling textures in triplanar fashion
    float4 triplanarX = tex2D(_Grid, i.worldPos.yz * _GridScale) * projNormal.x;
    float4 triplanarY = tex2D(_Grid, i.worldPos.zx * _GridScale) * projNormal.y;
    float4 triplanarZ = tex2D(_Grid, i.worldPos.xy * _GridScale) * projNormal.z;

    float4 triplanarResult = triplanarX + triplanarY + triplanarZ;

                // Mix base color and triplanar result
    float4 overlayColor = lerp(float4(1, 1, 1, 1), triplanarResult, _OverlayAmount);
    return _BaseColor * overlayColor;
}
            ENDHLSL
        }
    }
}
