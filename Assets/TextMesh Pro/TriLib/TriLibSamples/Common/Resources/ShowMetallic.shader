Shader "Hidden/ShowMetallic"
{
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MetallicGlossMap;
            float4 _MetallicGlossMap_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MetallicGlossMap);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float4 metallicSmooth = tex2D(_MetallicGlossMap, i.uv);
                return metallicSmooth.x;
            }
            ENDCG
        }
    }
}
