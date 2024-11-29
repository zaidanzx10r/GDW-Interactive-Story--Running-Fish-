Shader "Custom/Big Water"
{
    Properties
    {
        _MainTex ("Water", 2D) = "white" {}
        _FoamTex ("Foam Texture", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _ScrollX ("Scroll X", Range(-5,5)) = 1
        _ScrollY ("Scroll Y", Range(-5,5)) = 1
        _Tint("Colour Tint", Color) = (1,1,1,1)
        _Freq("Frequency", Range(0,5)) = 3
        _Speed("Speed", Range(0,100)) = 10
        _Amp("Amplitude", Range(0,1)) = 0.5

    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert 

        sampler2D _MainTex;
        sampler2D _FoamTex;
        sampler2D _NormalMap;

        float _ScrollX;
        float _ScrollY;

        float4 _Tint;
        float _Freq;
        float _Speed;
        float _Amp;

        struct Input
        {
            float2 uv_MainTex;
            float3 vertColor;
            float2 uv_NormalMap;
        };

        struct appdata 
        {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 tangent : TANGENT;
            float4 texcoord : TEXCOORD0;
            float4 texcoord1 : TEXCOORD1;
            float4 texcoord2 : TEXCOORD2;
        };

        void vert (inout appdata v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input,o);

            float t = _Time.y * _Speed;
            float waveHeight = sin(t + v.vertex.x * _Freq) * _Amp + sin(t*2 + v.vertex.x * _Freq*2) * _Amp;

            v.vertex.y += waveHeight;
            v.normal = normalize(float3(v.normal.x + waveHeight, v.normal.y, v.normal.z));
            o.vertColor = waveHeight + 2;
        }

        void surf (Input IN, inout SurfaceOutput o) 
        {
            float2 scrolledUV = IN.uv_MainTex + float2(_ScrollX * _Time.y, _ScrollY * _Time.y);
            float2 foamUV = IN.uv_MainTex + float2(_ScrollX * _Time.y / 2.0, _ScrollY * _Time.y / 2.0);

            float3 baseColor = tex2D(_MainTex, scrolledUV).rgb;
            float3 foamColor = tex2D(_FoamTex, foamUV).rgb;

            float3 finalColor = lerp(baseColor, foamColor, 0.5) * _Tint.rgb;

            o.Albedo = finalColor * IN.vertColor.rgb;

            float3 normalTex = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
            o.Normal = normalTex;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
