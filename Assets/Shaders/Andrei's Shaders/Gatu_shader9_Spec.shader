// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:34772,y:32574,varname:node_3138,prsc:2|normal-6280-RGB,custl-174-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32160,y:32384,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_NormalVector,id:6939,x:31511,y:32349,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:947,x:31511,y:32527,varname:node_947,prsc:2;n:type:ShaderForge.SFN_Dot,id:1626,x:31847,y:32405,varname:node_1626,prsc:2,dt:1|A-6939-OUT,B-947-OUT;n:type:ShaderForge.SFN_Multiply,id:1780,x:32372,y:32560,varname:node_1780,prsc:2|A-7241-RGB,B-1626-OUT;n:type:ShaderForge.SFN_LightColor,id:6335,x:34197,y:32822,varname:node_6335,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:5656,x:34197,y:32967,varname:node_5656,prsc:2;n:type:ShaderForge.SFN_Multiply,id:174,x:34433,y:32799,varname:node_174,prsc:2|A-6420-OUT,B-6335-RGB,C-5656-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:3512,x:31511,y:32694,varname:node_3512,prsc:2;n:type:ShaderForge.SFN_Dot,id:5323,x:31822,y:32660,varname:node_5323,prsc:2,dt:1|A-947-OUT,B-3512-OUT;n:type:ShaderForge.SFN_Power,id:2170,x:32193,y:32661,varname:node_2170,prsc:2|VAL-5323-OUT,EXP-3068-OUT;n:type:ShaderForge.SFN_Exp,id:3068,x:32027,y:32746,varname:node_3068,prsc:2,et:1|IN-7681-OUT;n:type:ShaderForge.SFN_Slider,id:7681,x:31841,y:32943,ptovrint:False,ptlb:Spec_power,ptin:_Spec_power,varname:node_7681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1.729613,max:9;n:type:ShaderForge.SFN_Slider,id:5737,x:32190,y:32946,ptovrint:False,ptlb:Spec_intensity,ptin:_Spec_intensity,varname:_Spec_power_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:4.718379,max:9;n:type:ShaderForge.SFN_Multiply,id:4889,x:32372,y:32741,varname:node_4889,prsc:2|A-2170-OUT,B-5737-OUT;n:type:ShaderForge.SFN_Add,id:6420,x:34197,y:32648,varname:node_6420,prsc:2|A-1780-OUT,B-7926-OUT,C-9613-OUT;n:type:ShaderForge.SFN_Tex2d,id:6280,x:34433,y:32583,ptovrint:False,ptlb:Normal_map,ptin:_Normal_map,varname:node_6280,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:8112,x:32565,y:32884,ptovrint:False,ptlb:Diffuse_texture,ptin:_Diffuse_texture,varname:node_8112,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Desaturate,id:7086,x:32772,y:32995,varname:node_7086,prsc:2|COL-8112-RGB,DES-9197-OUT;n:type:ShaderForge.SFN_Slider,id:9197,x:32589,y:33167,ptovrint:False,ptlb:Desaturate,ptin:_Desaturate,varname:node_9197,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-8,cur:0.9832264,max:8;n:type:ShaderForge.SFN_Multiply,id:252,x:33066,y:32994,varname:node_252,prsc:2|A-7086-OUT,B-9748-OUT;n:type:ShaderForge.SFN_Slider,id:9748,x:32944,y:33170,ptovrint:False,ptlb:Spec_brightness,ptin:_Spec_brightness,varname:node_9748,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:2.715273,max:8;n:type:ShaderForge.SFN_Power,id:797,x:33371,y:32997,varname:node_797,prsc:2|VAL-252-OUT,EXP-3487-OUT;n:type:ShaderForge.SFN_Exp,id:3487,x:33371,y:33138,varname:node_3487,prsc:2,et:1|IN-5447-OUT;n:type:ShaderForge.SFN_Slider,id:5447,x:33195,y:33344,ptovrint:False,ptlb:Spec_levels,ptin:_Spec_levels,varname:_Spec_brightness_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:2.142052,max:7;n:type:ShaderForge.SFN_Color,id:2017,x:32590,y:32039,ptovrint:False,ptlb:Select_color,ptin:_Select_color,varname:node_2017,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5367647,c2:0.3948933,c3:0.2604888,c4:1;n:type:ShaderForge.SFN_If,id:6915,x:33008,y:32465,varname:node_6915,prsc:2|A-2017-RGB,B-8112-RGB,GT-89-RGB,EQ-89-RGB,LT-2783-RGB;n:type:ShaderForge.SFN_Color,id:89,x:32590,y:32253,ptovrint:False,ptlb:Color_a,ptin:_Color_a,varname:_Select_color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9264706,c2:0.9264706,c3:0.9264706,c4:1;n:type:ShaderForge.SFN_Color,id:2783,x:32590,y:32420,ptovrint:False,ptlb:Color_b,ptin:_Color_b,varname:_Color_a_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2647059,c2:0.2647059,c3:0.2647059,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:8448,x:33236,y:32465,varname:node_8448,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6915-OUT;n:type:ShaderForge.SFN_Multiply,id:7926,x:33745,y:32792,varname:node_7926,prsc:2|A-8448-OUT,B-797-OUT,C-4889-OUT;n:type:ShaderForge.SFN_Tex2d,id:1728,x:33066,y:32819,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_1728,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:193f7b77c32c04944a03bb9fd670b3e7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:9613,x:33367,y:32676,varname:node_9613,prsc:2,blmd:1,clmp:True|SRC-8112-RGB,DST-1728-RGB;proporder:7241-7681-5737-6280-8112-9197-9748-5447-2017-89-2783-1728;pass:END;sub:END;*/

Shader "Shader Forge/Gatu_shader9_Spec" {
    Properties {
        _Color ("Color", Color) = (0,0,0,1)
        _Spec_power ("Spec_power", Range(1, 9)) = 1.729613
        _Spec_intensity ("Spec_intensity", Range(1, 9)) = 4.718379
        _Normal_map ("Normal_map", 2D) = "bump" {}
        _Diffuse_texture ("Diffuse_texture", 2D) = "white" {}
        _Desaturate ("Desaturate", Range(-8, 8)) = 0.9832264
        _Spec_brightness ("Spec_brightness", Range(1, 8)) = 2.715273
        _Spec_levels ("Spec_levels", Range(1, 7)) = 2.142052
        _Select_color ("Select_color", Color) = (0.5367647,0.3948933,0.2604888,1)
        _Color_a ("Color_a", Color) = (0.9264706,0.9264706,0.9264706,1)
        _Color_b ("Color_b", Color) = (0.2647059,0.2647059,0.2647059,1)
        _AO ("AO", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _Spec_power;
            uniform float _Spec_intensity;
            uniform sampler2D _Normal_map; uniform float4 _Normal_map_ST;
            uniform sampler2D _Diffuse_texture; uniform float4 _Diffuse_texture_ST;
            uniform float _Desaturate;
            uniform float _Spec_brightness;
            uniform float _Spec_levels;
            uniform float4 _Select_color;
            uniform float4 _Color_a;
            uniform float4 _Color_b;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_map_var = UnpackNormal(tex2D(_Normal_map,TRANSFORM_TEX(i.uv0, _Normal_map)));
                float3 normalLocal = _Normal_map_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Diffuse_texture_var = tex2D(_Diffuse_texture,TRANSFORM_TEX(i.uv0, _Diffuse_texture));
                float node_6915_if_leA = step(_Select_color.rgb,_Diffuse_texture_var.rgb);
                float node_6915_if_leB = step(_Diffuse_texture_var.rgb,_Select_color.rgb);
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                float3 finalColor = (((_Color.rgb*max(0,dot(normalDirection,lightDirection)))+(lerp((node_6915_if_leA*_Color_b.rgb)+(node_6915_if_leB*_Color_a.rgb),_Color_a.rgb,node_6915_if_leA*node_6915_if_leB).r*pow((lerp(_Diffuse_texture_var.rgb,dot(_Diffuse_texture_var.rgb,float3(0.3,0.59,0.11)),_Desaturate)*_Spec_brightness),exp2(_Spec_levels))*(pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(_Spec_power))*_Spec_intensity))+saturate((_Diffuse_texture_var.rgb*_AO_var.rgb)))*_LightColor0.rgb*attenuation);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _Spec_power;
            uniform float _Spec_intensity;
            uniform sampler2D _Normal_map; uniform float4 _Normal_map_ST;
            uniform sampler2D _Diffuse_texture; uniform float4 _Diffuse_texture_ST;
            uniform float _Desaturate;
            uniform float _Spec_brightness;
            uniform float _Spec_levels;
            uniform float4 _Select_color;
            uniform float4 _Color_a;
            uniform float4 _Color_b;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_map_var = UnpackNormal(tex2D(_Normal_map,TRANSFORM_TEX(i.uv0, _Normal_map)));
                float3 normalLocal = _Normal_map_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Diffuse_texture_var = tex2D(_Diffuse_texture,TRANSFORM_TEX(i.uv0, _Diffuse_texture));
                float node_6915_if_leA = step(_Select_color.rgb,_Diffuse_texture_var.rgb);
                float node_6915_if_leB = step(_Diffuse_texture_var.rgb,_Select_color.rgb);
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                float3 finalColor = (((_Color.rgb*max(0,dot(normalDirection,lightDirection)))+(lerp((node_6915_if_leA*_Color_b.rgb)+(node_6915_if_leB*_Color_a.rgb),_Color_a.rgb,node_6915_if_leA*node_6915_if_leB).r*pow((lerp(_Diffuse_texture_var.rgb,dot(_Diffuse_texture_var.rgb,float3(0.3,0.59,0.11)),_Desaturate)*_Spec_brightness),exp2(_Spec_levels))*(pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(_Spec_power))*_Spec_intensity))+saturate((_Diffuse_texture_var.rgb*_AO_var.rgb)))*_LightColor0.rgb*attenuation);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
