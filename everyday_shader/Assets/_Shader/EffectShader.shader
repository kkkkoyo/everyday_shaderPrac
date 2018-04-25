Shader "Custom/EffectShader"
{
    Properties
    {
        _Displacement("Displacement",Range(0,1)) = 0
        _PointColor("PointColor",Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags{"RenderType" = "Transparent" }
        Cull Off ZWrite On Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag            
            #include "UnityCG.cginc"

            struct v2f {
            float4 pos : SV_POSITION;
            // float3 worldPos : TEXCOORD0; // worldPosは使用していないようなので、削除してもいいでしょう
            };

            float _Displacement;
            half4 _PointColor;

            v2f vert (appdata_base v)
            {
                v2f o;
                float3 n = UnityObjectToWorldNormal(v.normal); // ワールド法線
                float3 p = mul(unity_ObjectToWorld, v.vertex).xyz; // モデル座標→ワールド座標
                float3 offset = n * _Displacement; // ワールド座標のずらし量
                float3 pOffset = p + offset; // ずらし後のワールド座標
                float4 pClip = mul(UNITY_MATRIX_VP, float4(pOffset, 1.0)); // ワールド座標→クリッピング座標（XYZ成分だけでなくW成分も必要なので、pOffsetにW成分として1を加えてfloat4としてから変換）
                o.pos = pClip; // pClipを最終的なo.posとして以降の描画プロセスへ送る
                // o.worldPos = pOffset; // worldPosは使用していないようなので、削除してもいいでしょう
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
                return half4(_PointColor.r,_PointColor.g,_PointColor.b,max(1- _Displacement,0));
            }
            ENDCG
        }
    }
}