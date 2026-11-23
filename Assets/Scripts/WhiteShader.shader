Shader "Custom/WhiteSprite"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _FlashAmount ("Flash Amount", Range(0, 1)) = 1
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "CanUseSpriteAtlas"="True" }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _FlashAmount;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color;
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 sprite = tex2D(_MainTex, i.uv);
                fixed alpha = sprite.a * i.color.a;
                fixed3 normalColor = sprite.rgb * i.color.rgb;
                fixed3 blendedColor = lerp(normalColor, fixed3(1, 1, 1), _FlashAmount);
                return fixed4(blendedColor * alpha, alpha);
            }
            ENDCG
        }
    }
}
