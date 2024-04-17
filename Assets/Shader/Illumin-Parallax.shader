Shader "Self-Illumin/Parallax Diffuse" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _Parallax ("Height", Range(0.005,0.08)) = 0.02
 _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
 _Illum ("Illumin (A)", 2D) = "white" {}
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _ParallaxMap ("Heightmap (A)", 2D) = "black" {}
 _EmissionLM ("Emission (Lightmapper)", Float) = 0
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