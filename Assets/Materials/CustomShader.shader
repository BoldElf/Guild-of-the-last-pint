Shader "Custom/AlbedoEmissionOpacityShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _EmissionTex ("Emission (RGB)", 2D) = "black" {}
        _OpacityTex ("Opacity (A)", 2D) = "white" {}
        _EmissionColor ("Emission Color", Color) = (1,1,1,1)
        _EmissionIntensity ("Emission Intensity", Range(0.0, 2.0)) = 1.0
        _OpacityStrength ("Opacity Strength", Range(0.0, 1.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _EmissionTex;
            sampler2D _OpacityTex;
            float4 _EmissionColor;
            float _EmissionIntensity;
            float _OpacityStrength;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // Sample the textures
                half4 albedo = tex2D(_MainTex, i.uv);
                half4 emission = tex2D(_EmissionTex, i.uv) * _EmissionColor * _EmissionIntensity;
                half opacity = tex2D(_OpacityTex, i.uv).r * _OpacityStrength;

                // Combine textures
                half4 color = albedo + emission;
                color.a *= opacity;

                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
