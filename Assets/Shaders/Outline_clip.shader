// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33924,y:32154,varname:node_9361,prsc:2|emission-8820-OUT,custl-6744-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32163,y:32096,ptovrint:False,ptlb:Emssion_Texture,ptin:_Emssion_Texture,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5aef530c9291bd947969764e9732dab8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5927,x:32164,y:32275,ptovrint:False,ptlb:Emssion_Tint,ptin:_Emssion_Tint,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.875,c2:0.2123162,c3:0.2123162,c4:1;n:type:ShaderForge.SFN_Multiply,id:544,x:32556,y:32261,cmnt:Diffuse Color,varname:node_544,prsc:2|A-851-RGB,B-5927-RGB,C-8755-OUT;n:type:ShaderForge.SFN_Slider,id:8755,x:31991,y:32458,ptovrint:False,ptlb:Emission_Intensity,ptin:_Emission_Intensity,varname:node_8755,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.023792,max:9;n:type:ShaderForge.SFN_Tex2d,id:3021,x:32691,y:32419,ptovrint:False,ptlb:Diffuse_Texture,ptin:_Diffuse_Texture,varname:node_3021,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6959c0cd078d5724eb2af3119f45949d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:8462,x:30332,y:31907,varname:node_8462,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:4738,x:30576,y:31907,varname:node_4738,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8462-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:2130,x:30805,y:31914,varname:node_2130,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4738-OUT;n:type:ShaderForge.SFN_ArcTan2,id:2918,x:31033,y:31914,varname:node_2918,prsc:2,attp:2|A-2130-G,B-2130-R;n:type:ShaderForge.SFN_OneMinus,id:1238,x:31213,y:31914,varname:node_1238,prsc:2|IN-2918-OUT;n:type:ShaderForge.SFN_Subtract,id:8576,x:31432,y:31914,varname:node_8576,prsc:2|A-1238-OUT,B-4904-OUT;n:type:ShaderForge.SFN_Slider,id:4904,x:31991,y:32560,ptovrint:False,ptlb:Clip,ptin:_Clip,varname:node_4904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Ceil,id:3845,x:32163,y:31914,varname:node_3845,prsc:2|IN-8576-OUT;n:type:ShaderForge.SFN_Multiply,id:7451,x:32786,y:32240,varname:node_7451,prsc:2|A-5824-OUT,B-544-OUT;n:type:ShaderForge.SFN_OneMinus,id:5824,x:32413,y:31999,varname:node_5824,prsc:2|IN-3845-OUT;n:type:ShaderForge.SFN_Multiply,id:6744,x:33297,y:32498,varname:node_6744,prsc:2|A-5963-RGB,B-8347-OUT,C-8596-OUT;n:type:ShaderForge.SFN_LightColor,id:5963,x:33063,y:32587,varname:node_5963,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:8347,x:33063,y:32751,varname:node_8347,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:1527,x:32036,y:32783,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:7754,x:32036,y:32931,varname:node_7754,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:5339,x:32036,y:33065,varname:node_5339,prsc:2;n:type:ShaderForge.SFN_Dot,id:3185,x:32384,y:33023,varname:node_3185,prsc:2,dt:1|A-7754-OUT,B-5339-OUT;n:type:ShaderForge.SFN_Dot,id:6443,x:32384,y:32848,varname:node_6443,prsc:2,dt:1|A-1527-OUT,B-7754-OUT;n:type:ShaderForge.SFN_Multiply,id:8036,x:32669,y:32889,varname:node_8036,prsc:2|A-2857-RGB,B-6443-OUT;n:type:ShaderForge.SFN_Color,id:2857,x:32384,y:32674,ptovrint:False,ptlb:Light_color,ptin:_Light_color,varname:node_2857,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Power,id:8199,x:32669,y:33028,varname:node_8199,prsc:2|VAL-3185-OUT,EXP-4288-OUT;n:type:ShaderForge.SFN_Exp,id:4288,x:32384,y:33216,varname:node_4288,prsc:2,et:1|IN-6160-OUT;n:type:ShaderForge.SFN_Slider,id:6160,x:31957,y:33306,ptovrint:False,ptlb:Spec_Power,ptin:_Spec_Power,varname:node_6160,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:9;n:type:ShaderForge.SFN_Multiply,id:8596,x:33126,y:33018,varname:node_8596,prsc:2|A-8036-OUT,B-4285-OUT;n:type:ShaderForge.SFN_Add,id:8820,x:33198,y:32291,varname:node_8820,prsc:2|A-4536-OUT,B-4690-OUT;n:type:ShaderForge.SFN_Slider,id:4707,x:32642,y:33255,ptovrint:False,ptlb:Spec_Intensity,ptin:_Spec_Intensity,varname:node_4707,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:9;n:type:ShaderForge.SFN_Multiply,id:4285,x:32912,y:33018,varname:node_4285,prsc:2|A-8199-OUT,B-4707-OUT;n:type:ShaderForge.SFN_Color,id:6879,x:32691,y:32596,ptovrint:False,ptlb:Diffuse_tint,ptin:_Diffuse_tint,varname:node_6879,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4690,x:32916,y:32408,varname:node_4690,prsc:2|A-3021-RGB,B-6879-RGB;n:type:ShaderForge.SFN_Multiply,id:4536,x:33028,y:32123,varname:node_4536,prsc:2|A-8586-OUT,B-7451-OUT;n:type:ShaderForge.SFN_Sin,id:3435,x:32406,y:31617,varname:node_3435,prsc:2|IN-7763-OUT;n:type:ShaderForge.SFN_Time,id:1876,x:31903,y:31526,varname:node_1876,prsc:2;n:type:ShaderForge.SFN_Abs,id:8505,x:32654,y:31638,varname:node_8505,prsc:2|IN-3435-OUT;n:type:ShaderForge.SFN_Multiply,id:7763,x:32163,y:31671,varname:node_7763,prsc:2|A-1876-T,B-2800-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2800,x:31853,y:31788,ptovrint:False,ptlb:Flikkering rate,ptin:_Flikkeringrate,varname:node_2800,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:8586,x:32856,y:31727,varname:node_8586,prsc:2|A-8505-OUT,B-6302-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6302,x:32639,y:31825,ptovrint:False,ptlb:emission_floor,ptin:_emission_floor,varname:_Flikkeringrate_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;proporder:4904-3021-6879-851-5927-8755-2857-6160-4707-2800-6302;pass:END;sub:END;*/

Shader "Custom/Outline_clip" {
    Properties {
        _Clip ("Clip", Range(0, 1)) = 1
        _Diffuse_Texture ("Diffuse_Texture", 2D) = "white" {}
        _Diffuse_tint ("Diffuse_tint", Color) = (1,1,1,1)
        _Emssion_Texture ("Emssion_Texture", 2D) = "white" {}
        _Emssion_Tint ("Emssion_Tint", Color) = (0.875,0.2123162,0.2123162,1)
        _Emission_Intensity ("Emission_Intensity", Range(0, 9)) = 2.023792
        _Light_color ("Light_color", Color) = (1,1,1,1)
        _Spec_Power ("Spec_Power", Range(0, 9)) = 0
        _Spec_Intensity ("Spec_Intensity", Range(0, 9)) = 0
        _Flikkeringrate ("Flikkering rate", Float ) = 1
        _emission_floor ("emission_floor", Float ) = 0.2
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
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Emssion_Texture; uniform float4 _Emssion_Texture_ST;
            uniform float4 _Emssion_Tint;
            uniform float _Emission_Intensity;
            uniform sampler2D _Diffuse_Texture; uniform float4 _Diffuse_Texture_ST;
            uniform float _Clip;
            uniform float4 _Light_color;
            uniform float _Spec_Power;
            uniform float _Spec_Intensity;
            uniform float4 _Diffuse_tint;
            uniform float _Flikkeringrate;
            uniform float _emission_floor;
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
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
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
                float3 attenColor = attenuation * _LightColor0.xyz;
////// Emissive:
                float4 node_1876 = _Time + _TimeEditor;
                float2 node_2130 = (i.uv0*2.0+-1.0).rg;
                float4 _Emssion_Texture_var = tex2D(_Emssion_Texture,TRANSFORM_TEX(i.uv0, _Emssion_Texture));
                float4 _Diffuse_Texture_var = tex2D(_Diffuse_Texture,TRANSFORM_TEX(i.uv0, _Diffuse_Texture));
                float3 emissive = (((abs(sin((node_1876.g*_Flikkeringrate)))+_emission_floor)*((1.0 - ceil(((1.0 - ((atan2(node_2130.g,node_2130.r)/6.28318530718)+0.5))-_Clip)))*(_Emssion_Texture_var.rgb*_Emssion_Tint.rgb*_Emission_Intensity)))+(_Diffuse_Texture_var.rgb*_Diffuse_tint.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Emssion_Texture; uniform float4 _Emssion_Texture_ST;
            uniform float4 _Emssion_Tint;
            uniform float _Emission_Intensity;
            uniform sampler2D _Diffuse_Texture; uniform float4 _Diffuse_Texture_ST;
            uniform float _Clip;
            uniform float4 _Light_color;
            uniform float _Spec_Power;
            uniform float _Spec_Intensity;
            uniform float4 _Diffuse_tint;
            uniform float _Flikkeringrate;
            uniform float _emission_floor;
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
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
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
                float3 attenColor = attenuation * _LightColor0.xyz;
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
