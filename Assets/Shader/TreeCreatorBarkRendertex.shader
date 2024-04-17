Shader "Hidden/Nature/Tree Creator Bark Rendertex" {
Properties {
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _BumpSpecMap ("Normalmap (GA) Spec (R)", 2D) = "bump" {}
 _TranslucencyMap ("Trans (RGB) Gloss(A)", 2D) = "white" {}
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
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