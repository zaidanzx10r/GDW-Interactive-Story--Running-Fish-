Shader "Custom/DiffuseAmbientShader" {
    Properties 
    {
        _MainColor ("Main Color", Color) = (1, 1, 1, 1)
        _AmbientColor ("Ambient Color", Color) = (0.2, 0.2, 0.2, 1)
    }
    SubShader 
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t 
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f 
            {
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
                float4 color : COLOR;
            };

            fixed4 _MainColor;
            fixed4 _AmbientColor;

            v2f vert(appdata_t v) 
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal); 
                o.color = _MainColor; // Set main color
                return o;
            }

            fixed4 frag(v2f i) : SV_Target 
            {
                // Calculate diffuse lighting
                float3 lightDir = normalize(float3(1, 1, 1)); 
                float diff = max(dot(i.normal, lightDir), 0);
                
                // Combine diffuse and ambient lighting
                fixed4 diffuse = _MainColor * diff;
                fixed4 ambient = _AmbientColor * _MainColor;
                
                return diffuse + ambient;
            }
            ENDCG
        }
    }
}

