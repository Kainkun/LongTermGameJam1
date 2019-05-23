Shader "Hidden/Distortion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        
        _Strength ("Strength", float) = .1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Strength;

            fixed4 frag (v2f i) : SV_Target
            {

                fixed2 center = fixed2(.5, .5);
                fixed2 uv = center - i.uv;

                fixed dist = sqrt(dot(uv,uv));
                fixed ang = 20 * dist + _Time.x * 100;
                uv = i.uv + normalize(uv) * sin(ang) * .01;
                
                fixed4 col = tex2D(_MainTex, uv);
                //col.y = abs(i.uv - center);
                return col;
            }
            ENDCG
        }
    }
}
