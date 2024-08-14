Shader "Custom/NatureLeavesShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _CutoutTex ("Cutout Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
    }

    SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma exclude_renderers gles xbox360 ps3

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            sampler2D _MainTex;
            sampler2D _CutoutTex;
            float4 _Color;
            float _Cutoff;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                
                // Calculate billboarding by aligning to camera
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                float3 cameraForward = normalize(_WorldSpaceCameraPos - worldPos);
                float3 cameraRight = cross(float3(0,1,0), cameraForward);
                float3 cameraUp = cross(cameraForward, cameraRight);
                
                float4x4 billboardMatrix = float4x4(cameraRight.x, cameraUp.x, cameraForward.x, 0,
                                                     cameraRight.y, cameraUp.y, cameraForward.y, 0,
                                                     cameraRight.z, cameraUp.z, cameraForward.z, 0,
                                                     0, 0, 0, 1);
                
                o.pos = mul(billboardMatrix, float4(v.vertex.xyz, 1));
                o.uv = v.uv;
                o.normal = v.normal;
                
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half4 texColor = tex2D(_MainTex, i.uv) * _Color;
                half cutoutAlpha = tex2D(_CutoutTex, i.uv).r;
                
                if (texColor.a < _Cutoff || cutoutAlpha < _Cutoff)
                    discard;

                // Simple Lambertian lighting
                half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                half ndotl = max(0, dot(i.normal, lightDir));
                half4 lighting = ndotl * _LightColor0;

                return texColor * lighting;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
