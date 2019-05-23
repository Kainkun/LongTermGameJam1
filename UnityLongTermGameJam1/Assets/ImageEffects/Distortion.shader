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
                fixed2 dist = i.uv;
                i.uv = (2*i.uv) - 1; 
                fixed r = atan2(i.uv.y, i.uv.x);
                //fixed2 theta = fixed2(acos(i.uv.x/r), asin(i.uv.y/r));

                //dist.x = dist.x + .005 * sin(n.y * 10 + _Time * 100);
                //dist.y = dist.y + .005 * sin(n.x * 10 + _Time * 100);
                dist.x += _Strength * ((cos(r * 1 + _Time * 100)) - .5);
                dist.y += _Strength * ((cos(r * 1 + _Time * 100)) - .5);
                
                fixed4 col = tex2D(_MainTex, dist);
                // just invert the colors
                return col;
            }
            ENDCG
        }
    }
}
