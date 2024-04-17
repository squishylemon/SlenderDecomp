Shader "Hidden/Nature/Tree Creator Leaves Optimized" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _TranslucencyColor ("Translucency Color", Color) = (0.73,0.85,0.41,1)
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.3
 _TranslucencyViewDependency ("View dependency", Range(0,1)) = 0.7
 _ShadowStrength ("Shadow Strength", Range(0,1)) = 0.8
 _ShadowOffsetScale ("Shadow Offset Scale", Float) = 1
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _ShadowTex ("Shadow (RGB)", 2D) = "white" {}
 _BumpSpecMap ("Normalmap (GA) Spec (R) Shadow Offset (B)", 2D) = "bump" {}
 _TranslucencyMap ("Trans (B) Gloss(A)", 2D) = "white" {}
 _Scale ("Scale", Vector) = (1,1,1,1)
 _SquashAmount ("Squash", Float) = 1
}
	//DummyShaderTextExporter
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
}