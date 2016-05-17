// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32842,y:32704,varname:node_3138,prsc:2|custl-3465-OUT;n:type:ShaderForge.SFN_Transform,id:9698,x:31736,y:32835,varname:node_9698,prsc:2,tffrom:0,tfto:3|IN-3041-OUT;n:type:ShaderForge.SFN_NormalVector,id:3041,x:31521,y:32835,prsc:2,pt:False;n:type:ShaderForge.SFN_ComponentMask,id:2796,x:31934,y:32835,varname:node_2796,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9698-XYZ;n:type:ShaderForge.SFN_Tex2d,id:9105,x:32356,y:32835,ptovrint:False,ptlb:matCap,ptin:_matCap,varname:node_9105,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:eb664ae67c9364cdba72ce79e3355f38,ntxv:0,isnm:False|UVIN-1690-OUT;n:type:ShaderForge.SFN_RemapRange,id:1690,x:32165,y:32835,varname:node_1690,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-2796-OUT;n:type:ShaderForge.SFN_Blend,id:3465,x:32613,y:32711,varname:node_3465,prsc:2,blmd:1,clmp:False|SRC-1525-RGB,DST-9105-RGB;n:type:ShaderForge.SFN_Tex2d,id:1525,x:32359,y:32635,ptovrint:False,ptlb:Ao,ptin:_Ao,varname:node_1525,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:193f7b77c32c04944a03bb9fd670b3e7,ntxv:0,isnm:False;proporder:9105-1525;pass:END;sub:END;*/

Shader "Shader Forge/Gatu_shader5_Matcap" {
    Properties {
        _matCap ("matCap", 2D) = "white" {}
        _Ao ("Ao", 2D) = "white" {}
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
            #pragma exclude_renderers d3d11 gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _matCap; uniform float4 _matCap_ST;
            uniform sampler2D _Ao; uniform float4 _Ao_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
                float4 _Ao_var = tex2D(_Ao,TRANSFORM_TEX(i.uv0, _Ao));
                float2 node_1690 = (mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg*0.5+0.5);
                float4 _matCap_var = tex2D(_matCap,TRANSFORM_TEX(node_1690, _matCap));
                float3 finalColor = (_Ao_var.rgb*_matCap_var.rgb);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
