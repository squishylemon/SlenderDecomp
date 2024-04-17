Shader "Skin/Diffuse" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Shininess ("Shininess", Range(0.01,1)) = 0.078125
 _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
 _RimTex ("Rim ramp (GRB) Fresnel ramp (A)", 2D) = " grey" {}
 _WrapTex ("Wrap ramp (RGBA)", 2D) = "grey" {}
}
Fallback " Diffuse"
}