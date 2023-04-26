Shader "Hidden/ShowNormals"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }
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
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3x3 rotation : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float3 binormal = cross(v.normal, v.tangent.xyz) * v.tangent.w;
                o.rotation = transpose(float3x3(v.tangent.xyz, binormal, v.normal));
                o.uv = v.uv;
                return o;
            }

            sampler2D _BumpMap;

            fixed4 frag(v2f i) : SV_Target
            {
                float3 normal = tex2D(_BumpMap, i.uv);
                normal = (normal * 2.0) - 1.0;
                normal = mul(i.rotation, normal);
                normal = (normal * 0.5) + 0.5;
                return float4(normal, 1.0);
            }
            ENDCG
        }
    }
}
