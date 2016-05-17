// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:35436,y:32676,varname:node_3138,prsc:2|emission-6602-OUT,custl-4426-OUT,clip-6930-OUT;n:type:ShaderForge.SFN_NormalVector,id:4094,x:31467,y:32674,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:3874,x:31467,y:32827,varname:node_3874,prsc:2;n:type:ShaderForge.SFN_Dot,id:9903,x:31776,y:32740,varname:node_9903,prsc:2,dt:1|A-4094-OUT,B-3874-OUT;n:type:ShaderForge.SFN_Color,id:2705,x:32293,y:32601,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2705,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8225152,c2:0.8161765,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4426,x:33054,y:32934,varname:node_4426,prsc:2|A-8236-OUT,B-8996-RGB,C-7341-OUT;n:type:ShaderForge.SFN_LightColor,id:8996,x:32616,y:32972,varname:node_8996,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:7341,x:32616,y:33181,varname:node_7341,prsc:2;n:type:ShaderForge.SFN_Add,id:8236,x:32628,y:32771,varname:node_8236,prsc:2|A-2705-RGB,B-9903-OUT,C-4657-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:395,x:31467,y:32968,varname:node_395,prsc:2;n:type:ShaderForge.SFN_Dot,id:3913,x:31776,y:32985,varname:node_3913,prsc:2,dt:1|A-3874-OUT,B-395-OUT;n:type:ShaderForge.SFN_Power,id:9454,x:32030,y:32985,varname:node_9454,prsc:2|VAL-3913-OUT,EXP-9319-OUT;n:type:ShaderForge.SFN_Exp,id:9319,x:31765,y:33147,varname:node_9319,prsc:2,et:0|IN-8203-OUT;n:type:ShaderForge.SFN_Slider,id:8203,x:31320,y:33203,ptovrint:False,ptlb:Spec_Glos,ptin:_Spec_Glos,varname:node_8203,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:4657,x:32295,y:32985,varname:node_4657,prsc:2|A-9454-OUT,B-4498-OUT;n:type:ShaderForge.SFN_Slider,id:4498,x:31951,y:33204,ptovrint:False,ptlb:Spec_Intensity,ptin:_Spec_Intensity,varname:_Spec_Glos_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Slider,id:9046,x:33259,y:33413,ptovrint:False,ptlb:Visibility,ptin:_Visibility,varname:node_9046,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9648734,max:1;n:type:ShaderForge.SFN_Tex2d,id:61,x:33281,y:33114,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_61,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7a632f967e8ad42f5bd275898151ab6a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:872,x:33681,y:33000,varname:node_872,prsc:2|A-8247-OUT,B-61-R;n:type:ShaderForge.SFN_Vector1,id:8247,x:33501,y:32978,varname:node_8247,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:9987,x:33916,y:33163,varname:node_9987,prsc:2|A-872-OUT,B-5647-OUT;n:type:ShaderForge.SFN_Multiply,id:2744,x:34245,y:33154,varname:node_2744,prsc:2|A-9987-OUT,B-550-OUT;n:type:ShaderForge.SFN_Vector1,id:550,x:34245,y:33291,varname:node_550,prsc:2,v1:4;n:type:ShaderForge.SFN_Power,id:4276,x:34541,y:33153,varname:node_4276,prsc:2|VAL-2744-OUT,EXP-4514-OUT;n:type:ShaderForge.SFN_Vector1,id:4514,x:34541,y:33294,varname:node_4514,prsc:2,v1:100;n:type:ShaderForge.SFN_ConstantClamp,id:6930,x:34804,y:33139,varname:node_6930,prsc:2,min:0,max:1|IN-4276-OUT;n:type:ShaderForge.SFN_If,id:369,x:34804,y:32984,varname:node_369,prsc:2|A-322-OUT,B-4276-OUT,GT-9396-OUT,EQ-2733-OUT,LT-2733-OUT;n:type:ShaderForge.SFN_Slider,id:322,x:34404,y:32846,ptovrint:False,ptlb:Edge_width,ptin:_Edge_width,varname:node_322,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:100;n:type:ShaderForge.SFN_Vector1,id:9396,x:34541,y:33005,varname:node_9396,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2733,x:34541,y:33062,varname:node_2733,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:6072,x:34561,y:32665,ptovrint:False,ptlb:Glow_color,ptin:_Glow_color,varname:node_6072,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6602,x:34832,y:32784,varname:node_6602,prsc:2|A-6072-RGB,B-369-OUT,C-2242-OUT;n:type:ShaderForge.SFN_RemapRange,id:5647,x:33636,y:33393,varname:node_5647,prsc:2,frmn:0,frmx:1,tomn:0.1,tomx:0.7|IN-9046-OUT;n:type:ShaderForge.SFN_Vector1,id:2242,x:34777,y:32709,varname:node_2242,prsc:2,v1:10;proporder:2705-8203-4498-9046-61-322-6072;pass:END;sub:END;*/

Shader "Shader Forge/Gatu_shader7_Dissolve" {
    Properties {
        _Color ("Color", Color) = (0.8225152,0.8161765,1,1)
        _Spec_Glos ("Spec_Glos", Range(0, 10)) = 1
        _Spec_Intensity ("Spec_Intensity", Range(0, 10)) = 1
        _Visibility ("Visibility", Range(0, 1)) = 0.9648734
        _Noise ("Noise", 2D) = "white" {}
        _Edge_width ("Edge_width", Range(0, 100)) = 1
        _Glow_color ("Glow_color", Color) = (0,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            uniform float _Spec_Glos;
            uniform float _Spec_Intensity;
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Edge_width;
            uniform float4 _Glow_color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4276 = pow((((0.1+_Noise_var.r)*(_Visibility*0.6+0.1))*4.0),100.0);
                clip(clamp(node_4276,0,1) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float node_369_if_leA = step(_Edge_width,node_4276);
                float node_369_if_leB = step(node_4276,_Edge_width);
                float node_2733 = 0.0;
                float3 emissive = (_Glow_color.rgb*lerp((node_369_if_leA*node_2733)+(node_369_if_leB*1.0),node_2733,node_369_if_leA*node_369_if_leB)*10.0);
                float3 finalColor = emissive + ((_Color.rgb+max(0,dot(i.normalDir,lightDirection))+(pow(max(0,dot(lightDirection,viewReflectDirection)),exp(_Spec_Glos))*_Spec_Intensity))*_LightColor0.rgb*attenuation);
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
            uniform float _Spec_Glos;
            uniform float _Spec_Intensity;
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Edge_width;
            uniform float4 _Glow_color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4276 = pow((((0.1+_Noise_var.r)*(_Visibility*0.6+0.1))*4.0),100.0);
                clip(clamp(node_4276,0,1) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = ((_Color.rgb+max(0,dot(i.normalDir,lightDirection))+(pow(max(0,dot(lightDirection,viewReflectDirection)),exp(_Spec_Glos))*_Spec_Intensity))*_LightColor0.rgb*attenuation);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4276 = pow((((0.1+_Noise_var.r)*(_Visibility*0.6+0.1))*4.0),100.0);
                clip(clamp(node_4276,0,1) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
