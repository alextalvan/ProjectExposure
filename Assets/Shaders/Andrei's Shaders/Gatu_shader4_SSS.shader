// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33819,y:32695,varname:node_3138,prsc:2|custl-2152-OUT;n:type:ShaderForge.SFN_Dot,id:1094,x:31901,y:32691,varname:node_1094,prsc:2,dt:0|A-8523-OUT,B-7135-OUT;n:type:ShaderForge.SFN_NormalVector,id:8523,x:31655,y:32576,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:7135,x:31655,y:32768,varname:node_7135,prsc:2;n:type:ShaderForge.SFN_Add,id:9294,x:32396,y:32771,varname:node_9294,prsc:2|A-1094-OUT,B-6955-OUT;n:type:ShaderForge.SFN_Vector1,id:6955,x:32396,y:32904,varname:node_6955,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:4317,x:32630,y:32771,varname:node_4317,prsc:2|A-9294-OUT,B-6955-OUT;n:type:ShaderForge.SFN_Multiply,id:7222,x:32816,y:32771,varname:node_7222,prsc:2|A-4317-OUT,B-4317-OUT;n:type:ShaderForge.SFN_Multiply,id:58,x:33431,y:32935,varname:node_58,prsc:2|A-1639-OUT,B-3192-RGB,C-3112-OUT;n:type:ShaderForge.SFN_LightColor,id:3192,x:33099,y:33085,varname:node_3192,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:677,x:31655,y:32944,varname:node_677,prsc:2;n:type:ShaderForge.SFN_Dot,id:2730,x:31901,y:33095,varname:node_2730,prsc:2,dt:1|A-7135-OUT,B-677-OUT;n:type:ShaderForge.SFN_Power,id:6050,x:32151,y:33093,varname:node_6050,prsc:2|VAL-2730-OUT,EXP-4356-OUT;n:type:ShaderForge.SFN_Slider,id:4356,x:31755,y:33287,ptovrint:False,ptlb:Spec_Gloss,ptin:_Spec_Gloss,varname:node_4356,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:8;n:type:ShaderForge.SFN_Multiply,id:4096,x:32396,y:33093,varname:node_4096,prsc:2|A-6050-OUT,B-2115-OUT;n:type:ShaderForge.SFN_Slider,id:2115,x:32072,y:33288,ptovrint:False,ptlb:Spec_Intensity,ptin:_Spec_Intensity,varname:_Spec_Gloss_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.5,max:8;n:type:ShaderForge.SFN_Add,id:1639,x:33112,y:32903,varname:node_1639,prsc:2|A-7222-OUT,B-4096-OUT,C-8674-OUT;n:type:ShaderForge.SFN_Add,id:6291,x:31920,y:33393,varname:node_6291,prsc:2|A-8523-OUT,B-7135-OUT;n:type:ShaderForge.SFN_Negate,id:5032,x:32393,y:33399,varname:node_5032,prsc:2|IN-678-OUT;n:type:ShaderForge.SFN_Dot,id:7828,x:32636,y:33389,varname:node_7828,prsc:2,dt:1|A-5032-OUT,B-624-OUT;n:type:ShaderForge.SFN_ViewVector,id:624,x:32393,y:33626,varname:node_624,prsc:2;n:type:ShaderForge.SFN_Multiply,id:678,x:32177,y:33399,varname:node_678,prsc:2|A-6291-OUT,B-7352-OUT;n:type:ShaderForge.SFN_Slider,id:7352,x:31841,y:33604,ptovrint:False,ptlb:SSS_intensity,ptin:_SSS_intensity,varname:node_7352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:8;n:type:ShaderForge.SFN_Power,id:7709,x:32816,y:33389,varname:node_7709,prsc:2|VAL-7828-OUT,EXP-4967-OUT;n:type:ShaderForge.SFN_Slider,id:4967,x:32582,y:33608,ptovrint:False,ptlb:SSS_width,ptin:_SSS_width,varname:_SSS_width_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:3.542796,max:8;n:type:ShaderForge.SFN_Color,id:4430,x:33103,y:33624,ptovrint:False,ptlb:Color_SSS,ptin:_Color_SSS,varname:node_4430,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6592292,c2:1,c3:0.1176471,c4:1;n:type:ShaderForge.SFN_Multiply,id:8674,x:33103,y:33385,varname:node_8674,prsc:2|A-7709-OUT,B-4430-RGB;n:type:ShaderForge.SFN_LightAttenuation,id:3112,x:33103,y:33236,varname:node_3112,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:5043,x:33112,y:32681,ptovrint:False,ptlb:Ao,ptin:_Ao,varname:node_5043,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:193f7b77c32c04944a03bb9fd670b3e7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:2152,x:33609,y:32788,varname:node_2152,prsc:2,blmd:1,clmp:False|SRC-5043-RGB,DST-58-OUT;proporder:4356-2115-7352-4967-4430-5043;pass:END;sub:END;*/

Shader "Shader Forge/Gatu_shader4_SSS" {
    Properties {
        _Spec_Gloss ("Spec_Gloss", Range(0, 8)) = 3
        _Spec_Intensity ("Spec_Intensity", Range(0, 8)) = 1.5
        _SSS_intensity ("SSS_intensity", Range(0, 8)) = 2
        _SSS_width ("SSS_width", Range(0.1, 8)) = 3.542796
        _Color_SSS ("Color_SSS", Color) = (0.6592292,1,0.1176471,1)
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
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Spec_Gloss;
            uniform float _Spec_Intensity;
            uniform float _SSS_intensity;
            uniform float _SSS_width;
            uniform float4 _Color_SSS;
            uniform sampler2D _Ao; uniform float4 _Ao_ST;
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
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Ao_var = tex2D(_Ao,TRANSFORM_TEX(i.uv0, _Ao));
                float node_6955 = 0.5;
                float node_4317 = ((dot(i.normalDir,lightDirection)+node_6955)*node_6955);
                float3 node_58 = (((node_4317*node_4317)+(pow(max(0,dot(lightDirection,viewReflectDirection)),_Spec_Gloss)*_Spec_Intensity)+(pow(max(0,dot((-1*((i.normalDir+lightDirection)*_SSS_intensity)),viewDirection)),_SSS_width)*_Color_SSS.rgb))*_LightColor0.rgb*attenuation);
                float3 finalColor = (_Ao_var.rgb*node_58);
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
            uniform float _Spec_Gloss;
            uniform float _Spec_Intensity;
            uniform float _SSS_intensity;
            uniform float _SSS_width;
            uniform float4 _Color_SSS;
            uniform sampler2D _Ao; uniform float4 _Ao_ST;
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
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Ao_var = tex2D(_Ao,TRANSFORM_TEX(i.uv0, _Ao));
                float node_6955 = 0.5;
                float node_4317 = ((dot(i.normalDir,lightDirection)+node_6955)*node_6955);
                float3 node_58 = (((node_4317*node_4317)+(pow(max(0,dot(lightDirection,viewReflectDirection)),_Spec_Gloss)*_Spec_Intensity)+(pow(max(0,dot((-1*((i.normalDir+lightDirection)*_SSS_intensity)),viewDirection)),_SSS_width)*_Color_SSS.rgb))*_LightColor0.rgb*attenuation);
                float3 finalColor = (_Ao_var.rgb*node_58);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
