Shader "Unlit/MyUnlitShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("mainColor",Color) = (0.5,0.5,0.5,1)
    }

        HLSLINCLUDE
        #include "UnityCG.cginc"
            uniform float4 _Color;
        sampler2D _MainTex;

        struct a2v {
            float4 pos:POSITION;
            float2 uv:TEXCOORD0;
        };

        struct v2f {
            float4 pos:SV_POSITION;
            float2 uv:TEXCOORD0;
        };

        v2f vvv(a2v v) {
            v2f o;
            UNITY_INITIALIZE_OUTPUT(v2f, o);
            o.pos = UnityObjectToClipPos(v.pos);
            o.uv = v.uv;
            return o;
        }

        float4 fff(v2f i) :SV_Target{
            half4 fragColor = half4(_Color.rgb,1.0) * tex2D(_MainTex,i.uv);
            return fragColor;
        }
            ENDHLSL
            
        SubShader
        {
            Tags{ "Queue" = "opaque" }
            LOD 100
            Cull Off
            Pass 
            {
                Tags{"LightMode" = "Always"}
                HLSLPROGRAM
                #pragma vertex vvv
                #pragma fragment fff
                ENDHLSL
            }
        }

}

