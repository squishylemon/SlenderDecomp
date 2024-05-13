// Compiled shader for PC, Mac & Linux Standalone, uncompressed size: 8.5KB

// Skipping shader variants that would not be included into build of current scene.

Shader "UI/DefaultCull" {
Properties {
[PerRendererData]  _MainTex ("Sprite Texture", 2D) = "white" { }
 _Color ("Tint", Color) = (1,1,1,1)
 _StencilComp ("Stencil Comparison", Float) = 8
 _Stencil ("Stencil ID", Float) = 0
 _StencilOp ("Stencil Operation", Float) = 0
 _StencilWriteMask ("Stencil Write Mask", Float) = 255
 _StencilReadMask ("Stencil Read Mask", Float) = 255
 _ColorMask ("Color Mask", Float) = 15
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="true" }


 // Stats for Vertex shader:
 //       d3d11 : 5 math
 //    d3d11_9x : 5 math
 //        d3d9 : 9 math
 //      opengl : 3 math, 2 texture, 1 branch
 // Stats for Fragment shader:
 //       d3d11 : 3 math, 1 texture
 //    d3d11_9x : 3 math, 1 texture
 //        d3d9 : 3 math, 2 texture
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="true" }
  ZTest [unity_GUIZTestMode]
  ZWrite Off
  Cull Back
  Stencil {
   Ref [_Stencil]
   ReadMask [_StencilReadMask]
   WriteMask [_StencilWriteMask]
   Comp [_StencilComp]
   Pass [_StencilOp]
  }
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask [_ColorMask]
  GpuProgramID 53140
Program "vp" {
SubProgram "opengl " {
// Stats: 3 math, 2 textures, 1 branches
"!!GLSL
#ifdef VERTEX

uniform vec4 _Color;
varying vec4 xlv_COLOR;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_COLOR = (gl_Color * _Color);
  xlv_TEXCOORD0 = gl_MultiTexCoord0.xy;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec4 xlv_COLOR;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR);
  float x_2;
  x_2 = (tmpvar_1.w - 0.01);
  if ((x_2 < 0.0)) {
    discard;
  };
  gl_FragData[0] = tmpvar_1;
}


#endif
"
}
SubProgram "d3d9 " {
// Stats: 9 math
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 5 [_Color]
Vector 4 [_ScreenParams]
"vs_2_0
def c6, -1, 1, 0, 0
dcl_position v0
dcl_color v1
dcl_texcoord v2
dp4 oPos.z, c2, v0
dp4 oPos.w, c3, v0
dp4 r0.x, c0, v0
dp4 r0.y, c1, v0
mov r1.x, c6.x
add r0.zw, r1.x, c4
mad oPos.xy, r0.zwzw, c6, r0
mul oD0, v1, c5
mov oT0.xy, v2

"
}
SubProgram "d3d11 " {
// Stats: 5 math
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 96 [_Color]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedjponkieeepkkljglkeagkmihoaedoijmabaaaaaageacaaaaadaaaaaa
cmaaaaaajmaaaaaabaabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
gmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaagcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfaepfdejfeejepeoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefcemabaaaaeaaaabaafdaaaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaipccabaaaabaaaaaaegbobaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaadgaaaaafdccabaaaacaaaaaaegbabaaaacaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
// Stats: 5 math
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 96 [_Color]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedpnahgoiimggdnpnonlgfgoobcndccdbjabaaaaaageadaaaaaeaaaaaa
daaaaaaacmabaaaaiaacaaaapaacaaaaebgpgodjpeaaaaaapeaaaaaaaaacpopp
leaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaagaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
afaaaaadaaaaapoaabaaoejaabaaoekaafaaaaadaaaaapiaaaaaffjaadaaoeka
aeaaaaaeaaaaapiaacaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
abaaadoaacaaoejappppaaaafdeieefcemabaaaaeaaaabaafdaaaaaafjaaaaae
egiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaaipccabaaaabaaaaaaegbobaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaadgaaaaafdccabaaaacaaaaaaegbabaaaacaaaaaadoaaaaab
ejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
fpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaafaepfdejfeejepeo
aaedepemepfcaafeeffiedepepfceeaaepfdeheogmaaaaaaadaaaaaaaiaaaaaa
faaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadamaaaafdfgfpfaepfdejfeejepeoaaedepemepfcaafeeffiedepep
fceeaakl"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
// Stats: 3 math, 2 textures
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
def c0, -0.00999999978, 0, 0, 0
dcl v0
dcl_pp t0.xy
dcl_2d s0
texld r0, t0, s0
mad_pp r1, r0.w, v0.w, c0.x
mul_pp r0, r0, v0
mov_pp oC0, r0
texkill r1

"
}
SubProgram "d3d11 " {
// Stats: 3 math, 1 textures
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedadjklaodokopfkdpcdjdnfjcmecoolmiabaaaaaanaabaaaaadaaaaaa
cmaaaaaakaaaaaaaneaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcpeaaaaaaeaaaaaaa
dnaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaadkaabaaa
aaaaaaaadkbabaaaabaaaaaaabeaaaaaaknhcdlmdiaaaaahpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegbobaaaabaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadbaaaaahbcaabaaaaaaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaa
anaaaeadakaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
// Stats: 3 math, 1 textures
SetTexture 0 [_MainTex] 2D 0
"ps_4_0_level_9_1
eefiecedknhlffangbeofgmlphegcaoljljppkdiabaaaaaajaacaaaaaeaaaaaa
daaaaaaaomaaaaaaoiabaaaafmacaaaaebgpgodjleaaaaaaleaaaaaaaaacpppp
imaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkaaknhcdlmaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaacdlabpaaaaacaaaaaajaaaaiapka
ecaaaaadaaaaapiaabaaoelaaaaioekaaeaaaaaeabaacpiaaaaappiaaaaappla
aaaaaakaafaaaaadaaaacpiaaaaaoeiaaaaaoelaabaaaaacaaaicpiaaaaaoeia
ebaaaaababaaapiappppaaaafdeieefcpeaaaaaaeaaaaaaadnaaaaaafkaaaaad
aagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
acaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaadkaabaaaaaaaaaaadkbabaaa
abaaaaaaabeaaaaaaknhcdlmdiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
egbobaaaabaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadbaaaaah
bcaabaaaaaaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaaanaaaeadakaabaaa
aaaaaaaadoaaaaabejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
fdfgfpfaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
}