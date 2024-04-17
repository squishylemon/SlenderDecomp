Shader "Hidden/TerrainEngine/Splatmap/Lightmap-FirstPass" {
Properties {
 _Control ("Control (RGBA)", 2D) = "red" {}
 _Splat3 ("Layer 3 (A)", 2D) = "white" {}
 _Splat2 ("Layer 2 (B)", 2D) = "white" {}
 _Splat1 ("Layer 1 (G)", 2D) = "white" {}
 _Splat0 ("Layer 0 (R)", 2D) = "white" {}
 _MainTex ("BaseMap (RGB)", 2D) = "white" {}
 _Color ("Main Color", Color) = (1,1,1,1)
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