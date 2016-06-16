// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33403,y:32379,varname:node_3138,prsc:2|custl-8119-OUT;n:type:ShaderForge.SFN_ScreenPos,id:9771,x:31405,y:32832,varname:node_9771,prsc:2,sctp:0;n:type:ShaderForge.SFN_SceneColor,id:9394,x:32274,y:32841,varname:node_9394,prsc:2|UVIN-8530-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:4830,x:31649,y:32832,varname:node_4830,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-9771-UVOUT;n:type:ShaderForge.SFN_Parallax,id:8530,x:32072,y:32853,cmnt:Parallax,varname:node_8530,prsc:2|UVIN-4830-OUT,HEI-1597-OUT,DEP-4984-OUT,REF-926-OUT;n:type:ShaderForge.SFN_Slider,id:1597,x:31689,y:33047,ptovrint:False,ptlb:Hei,ptin:_Hei,varname:node_1597,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:4984,x:31689,y:33138,ptovrint:False,ptlb:Dep,ptin:_Dep,varname:_node_1597_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:926,x:31689,y:33230,ptovrint:False,ptlb:Ref,ptin:_Ref,varname:_node_1597_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_LightVector,id:6348,x:31768,y:32272,varname:node_6348,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:8400,x:31778,y:32418,varname:node_8400,prsc:2;n:type:ShaderForge.SFN_Dot,id:4398,x:31996,y:32320,varname:node_4398,prsc:2,dt:1|A-6348-OUT,B-8400-OUT;n:type:ShaderForge.SFN_Power,id:8091,x:32219,y:32320,varname:node_8091,prsc:2|VAL-4398-OUT,EXP-2695-OUT;n:type:ShaderForge.SFN_Exp,id:2695,x:32014,y:32507,varname:node_2695,prsc:2,et:1|IN-7105-OUT;n:type:ShaderForge.SFN_Slider,id:7105,x:31582,y:32604,ptovrint:False,ptlb:Spec_gloss,ptin:_Spec_gloss,varname:node_7105,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:8;n:type:ShaderForge.SFN_Multiply,id:1728,x:32499,y:32430,varname:node_1728,prsc:2|A-8091-OUT,B-3975-OUT;n:type:ShaderForge.SFN_Add,id:489,x:32705,y:32576,varname:node_489,prsc:2|A-1728-OUT,B-9394-RGB;n:type:ShaderForge.SFN_Slider,id:3975,x:32140,y:32594,ptovrint:False,ptlb:Spec_Intensity,ptin:_Spec_Intensity,varname:_Spec_gloss_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:8;n:type:ShaderForge.SFN_Multiply,id:8119,x:32864,y:32652,varname:node_8119,prsc:2|A-489-OUT,B-7927-RGB;n:type:ShaderForge.SFN_LightColor,id:7927,x:32654,y:32707,varname:node_7927,prsc:2;proporder:1597-4984-926-7105-3975;pass:END;sub:END;*/

Shader "Custom/FresnelTech" {
    Properties {
        _Hei ("Hei", Range(0, 5)) = 0
        _Dep ("Dep", Range(0, 5)) = 0
        _Ref ("Ref", Range(0, 5)) = 0
        _Spec_gloss ("Spec_gloss", Range(1, 8)) = 1
        _Spec_Intensity ("Spec_Intensity", Range(1, 8)) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float _Hei;
            uniform float _Dep;
            uniform float _Ref;
            uniform float _Spec_gloss;
            uniform float _Spec_Intensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                float4 screenPos : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float3 finalColor = (((pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(_Spec_gloss))*_Spec_Intensity)+tex2D( _GrabTexture, (_Dep*(_Hei - _Ref)*mul(tangentTransform, viewDirection).xy + (i.screenPos.rg*0.5+0.5)).rg).rgb)*_LightColor0.rgb);
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float _Hei;
            uniform float _Dep;
            uniform float _Ref;
            uniform float _Spec_gloss;
            uniform float _Spec_Intensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                float4 screenPos : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float3 finalColor = (((pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(_Spec_gloss))*_Spec_Intensity)+tex2D( _GrabTexture, (_Dep*(_Hei - _Ref)*mul(tangentTransform, viewDirection).xy + (i.screenPos.rg*0.5+0.5)).rg).rgb)*_LightColor0.rgb);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
