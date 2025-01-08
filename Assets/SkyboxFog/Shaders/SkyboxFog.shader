// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. 
// Modified by Chris Cunningham to achieve fog blending effect.
// MIT license (see license.txt)

Shader "Skybox/6 Sided Fog" {
    Properties {
        _Tint ("Tint Color", Color) = (.5, .5, .5, .5)
        [Gamma] _Exposure ("Exposure", Range(0, 8)) = 1.0
        _Rotation ("Rotation", Range(0, 360)) = 0
        [NoScaleOffset] _FrontTex ("Front [+Z]   (HDR)", 2D) = "grey" {}
        [NoScaleOffset] _BackTex ("Back [-Z]   (HDR)", 2D) = "grey" {}
        [NoScaleOffset] _LeftTex ("Left [+X]   (HDR)", 2D) = "grey" {}
        [NoScaleOffset] _RightTex ("Right [-X]   (HDR)", 2D) = "grey" {}
        [NoScaleOffset] _UpTex ("Up [+Y]   (HDR)", 2D) = "grey" {}
        [NoScaleOffset] _DownTex ("Down [-Y]   (HDR)", 2D) = "grey" {}
        [Header(Height)]
        _Height ("Height", Float) = 2500.0
        _Blend ("Blend", Float) = 2500.0
        _ColorB ("2nd Color", Color) = (0.0, 0.5, 1.0, 1.0)
        _Opacity ("Opacity", Range(0, 1)) = 1.0
        _DistanceThreshold("Distance Threshold", Float) = 5.0 // Adjust as needed
    }

    SubShader {
        Tags { "Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
        Cull Off ZWrite Off

        CGINCLUDE
        #include "UnityCG.cginc"

        half4 _Tint;
        half _Exposure;
        float _Rotation;
        float _Height;
        float _Blend;
        half4 _ColorB;
        float _Opacity;
        float _DistanceThreshold;

        float3 RotateAroundYInDegrees (float3 vertex, float degrees)
        {
            float alpha = degrees * UNITY_PI / 180.0;
            float sina, cosa;
            sincos(alpha, sina, cosa);
            float2x2 m = float2x2(cosa, -sina, sina, cosa);
            return float3(mul(m, vertex.xz), vertex.y).xzy;
        }

        struct appdata_t {
            float4 vertex : POSITION;
            float2 texcoord : TEXCOORD0;
        };

        struct v2f {
            float4 vertex : SV_POSITION;
            float2 texcoord : TEXCOORD0;
            float3 wPos : TEXCOORD1;
            float distanceToCamera : TEXCOORD2;
        };

        v2f vert (appdata_t v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.texcoord = v.texcoord;
            o.wPos = mul(unity_ObjectToWorld, v.vertex).xyz; // Corrected line
            o.distanceToCamera = distance(_WorldSpaceCameraPos, o.wPos);
            return o;
        }

        half4 skybox_frag (v2f i, sampler2D smp, half4 smpDecode)
        {
            half4 tex = tex2D(smp, i.texcoord);
            half3 c = DecodeHDR(tex, smpDecode);
            c = c * _Tint.rgb * unity_ColorSpaceDouble.rgb;
            c *= _Exposure;

            if (i.wPos.y <= _Height && i.distanceToCamera > _DistanceThreshold) {
                c = lerp(c, _ColorB.rgb, saturate((_Height - i.wPos.y) / _Blend));
                c = lerp(c, unity_FogColor.rgb, saturate((_Height - i.wPos.y) / _Blend));
            }
            c = lerp(c, tex, 1 - _Opacity);
            
            return half4(c, 1);
        }
        ENDCG

        Pass {
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _FrontTex;
		half4 _FrontTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_FrontTex, _FrontTex_HDR); }
		ENDCG 
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _BackTex;
		half4 _BackTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_BackTex, _BackTex_HDR); }
		ENDCG 
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _LeftTex;
		half4 _LeftTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_LeftTex, _LeftTex_HDR); }
		ENDCG
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _RightTex;
		half4 _RightTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_RightTex, _RightTex_HDR); }
		ENDCG
	}	
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _UpTex;
		half4 _UpTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_UpTex, _UpTex_HDR); }
		ENDCG
	}	
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _DownTex;
		half4 _DownTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_DownTex, _DownTex_HDR); }
		ENDCG
	}
}
}