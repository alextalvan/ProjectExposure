// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32966,y:32508,varname:node_3138,prsc:2|emission-8952-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31973,y:32487,ptovrint:False,ptlb:Glow_Color,ptin:_Glow_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_NormalVector,id:6859,x:31544,y:32750,prsc:2,pt:False;n:type:ShaderForge.SFN_Fresnel,id:402,x:31756,y:32750,varname:node_402,prsc:2|NRM-6859-OUT,EXP-4638-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4638,x:31756,y:32910,ptovrint:False,ptlb:EXP,ptin:_EXP,varname:node_4638,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_OneMinus,id:9830,x:31984,y:32750,varname:node_9830,prsc:2|IN-402-OUT;n:type:ShaderForge.SFN_Multiply,id:990,x:32209,y:32750,varname:node_990,prsc:2|A-9830-OUT,B-3096-OUT;n:type:ShaderForge.SFN_Slider,id:3096,x:32052,y:32913,ptovrint:False,ptlb:Edge_glow,ptin:_Edge_glow,varname:node_3096,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Multiply,id:4834,x:32236,y:32480,varname:node_4834,prsc:2|A-7241-RGB,B-4703-OUT;n:type:ShaderForge.SFN_Slider,id:4703,x:31816,y:32664,ptovrint:False,ptlb:Glow_intensity,ptin:_Glow_intensity,varname:node_4703,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Color,id:5291,x:32236,y:32327,ptovrint:False,ptlb:Base_Color,ptin:_Base_Color,varname:node_5291,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:8952,x:32735,y:32495,varname:node_8952,prsc:2|A-5291-RGB,B-4834-OUT,T-990-OUT;proporder:7241-4638-3096-4703-5291;pass:END;sub:END;*/

Shader "Custom/Glow" {
    Properties {
        _Glow_Color ("Glow_Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _EXP ("EXP", Float ) = 1
        _Edge_glow ("Edge_glow", Range(0, 10)) = 0
        _Glow_intensity ("Glow_intensity", Range(0, 10)) = 0
        _Base_Color ("Base_Color", Color) = (0.5,0.5,0.5,1)
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Glow_Color;
            uniform float _EXP;
            uniform float _Edge_glow;
            uniform float _Glow_intensity;
            uniform float4 _Base_Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = lerp(_Base_Color.rgb,(_Glow_Color.rgb*_Glow_intensity),((1.0 - pow(1.0-max(0,dot(i.normalDir, viewDirection)),_EXP))*_Edge_glow));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
