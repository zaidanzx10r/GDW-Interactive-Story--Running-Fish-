Shader "Custom/LUTShader" {
    Properties {
        _MainTex ("Main Texture", 2D) = "white" {}
        _LUT ("LUT", 2D) = "white" {}
        _Contribution ("Contribution", Range(0, 1)) = 1
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;           // Main scene texture
            sampler2D _LUT;               // LUT texture
            float _Contribution;          // Contribution strength (0 to 1)
            float4 _LUT_TexelSize;        // Texel size of the LUT texture

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);   // Sample the main texture
                float colors = 32.0;                  // Number of colors in the LUT
                float maxColor = colors - 1.0;

                // Calculate the LUT position based on color channels
                float2 uvLUT;
                uvLUT.x = col.r * (maxColor / colors) + (0.5 / _LUT_TexelSize.x);
                uvLUT.y = col.g * (maxColor / colors) + (0.5 / _LUT_TexelSize.y);
                float cell = floor(col.b * maxColor);
                uvLUT.x += cell / colors;

                // Sample the LUT and blend based on contribution
                fixed4 gradedCol = tex2D(_LUT, uvLUT);
                return lerp(col, gradedCol, _Contribution);
            }
            ENDCG
        }
    }
}

