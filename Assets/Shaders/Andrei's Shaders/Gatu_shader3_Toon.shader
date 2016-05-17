// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33413,y:32659,varname:node_3138,prsc:2|custl-2367-OUT,olwid-538-OUT,olcol-6317-RGB;n:type:ShaderForge.SFN_Tex2d,id:6322,x:32744,y:32631,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_6322,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:46332cfd2003a432db3323b66713b5f4,ntxv:0,isnm:False|UVIN-6631-OUT;n:type:ShaderForge.SFN_Slider,id:538,x:32645,y:33332,ptovrint:False,ptlb:Outline_Width,ptin:_Outline_Width,varname:node_538,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.06192512,max:1;n:type:ShaderForge.SFN_Color,id:6317,x:32789,y:33451,ptovrint:False,ptlb:Outline_Color,ptin:_Outline_Color,varname:node_6317,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_NormalVector,id:8409,x:31318,y:32662,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:8718,x:31207,y:32457,varname:node_8718,prsc:2;n:type:ShaderForge.SFN_Dot,id:5179,x:31919,y:32517,varname:node_5179,prsc:2,dt:1|A-1965-OUT,B-8409-OUT;n:type:ShaderForge.SFN_Append,id:6631,x:32429,y:32565,varname:node_6631,prsc:2|A-9425-OUT,B-9425-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:5905,x:31919,y:32720,varname:node_5905,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9425,x:32151,y:32599,varname:node_9425,prsc:2|A-5179-OUT,B-5905-OUT;n:type:ShaderForge.SFN_Dot,id:4022,x:31835,y:33116,varname:node_4022,prsc:2,dt:1|A-8409-OUT,B-6172-OUT;n:type:ShaderForge.SFN_Append,id:9966,x:32213,y:33141,varname:node_9966,prsc:2|A-4022-OUT,B-4022-OUT;n:type:ShaderForge.SFN_Tex2d,id:5783,x:32435,y:33141,ptovrint:False,ptlb:Spec_ramp,ptin:_Spec_ramp,varname:node_5783,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d52b3cb1402614d51a6ae02326de0637,ntxv:0,isnm:False|UVIN-9966-OUT;n:type:ShaderForge.SFN_Add,id:2367,x:33025,y:32912,varname:node_2367,prsc:2|A-6322-RGB,B-5783-RGB;n:type:ShaderForge.SFN_ViewReflectionVector,id:6172,x:31336,y:33109,varname:node_6172,prsc:2;n:type:ShaderForge.SFN_ViewVector,id:1965,x:31287,y:32262,varname:node_1965,prsc:2;proporder:538-6317-6322-5783;pass:END;sub:END;*/

Shader "Shader Forge/Gatu_shader3" {
    Properties {
        _Outline_Width ("Outline_Width", Range(0, 1)) = 0.06192512
        _Outline_Color ("Outline_Color", Color) = (0,0,0,1)
        _Ramp ("Ramp", 2D) = "white" {}
        _Spec_ramp ("Spec_ramp", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Outline_Width;
            uniform float4 _Outline_Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*_Outline_Width,1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_Outline_Color.rgb,0);
            }
            ENDCG
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
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Spec_ramp; uniform float4 _Spec_ramp_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_5179 = max(0,dot(viewDirection,i.normalDir));
                float node_9425 = (node_5179*attenuation);
                float2 node_6631 = float2(node_9425,node_9425);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_6631, _Ramp));
                float node_4022 = max(0,dot(i.normalDir,viewReflectDirection));
                float2 node_9966 = float2(node_4022,node_4022);
                float4 _Spec_ramp_var = tex2D(_Spec_ramp,TRANSFORM_TEX(node_9966, _Spec_ramp));
                float3 finalColor = (_Ramp_var.rgb+_Spec_ramp_var.rgb);
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
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Spec_ramp; uniform float4 _Spec_ramp_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_5179 = max(0,dot(viewDirection,i.normalDir));
                float node_9425 = (node_5179*attenuation);
                float2 node_6631 = float2(node_9425,node_9425);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_6631, _Ramp));
                float node_4022 = max(0,dot(i.normalDir,viewReflectDirection));
                float2 node_9966 = float2(node_4022,node_4022);
                float4 _Spec_ramp_var = tex2D(_Spec_ramp,TRANSFORM_TEX(node_9966, _Spec_ramp));
                float3 finalColor = (_Ramp_var.rgb+_Spec_ramp_var.rgb);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
