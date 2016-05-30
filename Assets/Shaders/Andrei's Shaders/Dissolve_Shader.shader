// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:35560,y:32641,varname:node_3138,prsc:2|diff-6294-OUT,spec-5253-OUT,gloss-174-OUT,normal-4283-OUT,emission-6602-OUT,clip-6930-OUT;n:type:ShaderForge.SFN_Slider,id:9046,x:33266,y:33410,ptovrint:False,ptlb:Visibility,ptin:_Visibility,varname:node_9046,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:1,max:2;n:type:ShaderForge.SFN_Tex2d,id:61,x:33281,y:33114,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_61,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7a632f967e8ad42f5bd275898151ab6a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:872,x:33681,y:33000,varname:node_872,prsc:2|A-64-OUT,B-61-R;n:type:ShaderForge.SFN_Multiply,id:9987,x:33916,y:33163,varname:node_9987,prsc:2|A-872-OUT,B-9046-OUT;n:type:ShaderForge.SFN_Multiply,id:2744,x:34245,y:33154,varname:node_2744,prsc:2|A-9987-OUT,B-550-OUT;n:type:ShaderForge.SFN_Vector1,id:550,x:34245,y:33291,varname:node_550,prsc:2,v1:4;n:type:ShaderForge.SFN_Power,id:4276,x:34541,y:33153,varname:node_4276,prsc:2|VAL-2744-OUT,EXP-4514-OUT;n:type:ShaderForge.SFN_Vector1,id:4514,x:34541,y:33294,varname:node_4514,prsc:2,v1:100;n:type:ShaderForge.SFN_ConstantClamp,id:6930,x:34804,y:33139,varname:node_6930,prsc:2,min:0,max:1|IN-4276-OUT;n:type:ShaderForge.SFN_If,id:369,x:34804,y:32984,varname:node_369,prsc:2|A-322-OUT,B-4276-OUT,GT-9396-OUT,EQ-2733-OUT,LT-2733-OUT;n:type:ShaderForge.SFN_Slider,id:322,x:34404,y:32846,ptovrint:False,ptlb:Edge_width,ptin:_Edge_width,varname:node_322,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:91.26214,max:200;n:type:ShaderForge.SFN_Vector1,id:9396,x:34541,y:33005,varname:node_9396,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2733,x:34541,y:33062,varname:node_2733,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:6072,x:34561,y:32665,ptovrint:False,ptlb:Glow_color,ptin:_Glow_color,varname:node_6072,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6602,x:34832,y:32784,varname:node_6602,prsc:2|A-6072-RGB,B-369-OUT,C-929-OUT;n:type:ShaderForge.SFN_Tex2d,id:5653,x:34984,y:32028,ptovrint:False,ptlb:Base_Color,ptin:_Base_Color,varname:node_5653,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:5253,x:34981,y:32583,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_5253,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:174,x:34981,y:32681,ptovrint:False,ptlb:Glossiness,ptin:_Glossiness,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:6294,x:35188,y:32028,varname:node_6294,prsc:2|A-6632-RGB,B-5653-RGB;n:type:ShaderForge.SFN_Color,id:6632,x:34984,y:31847,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_6632,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1268,x:34984,y:32238,ptovrint:False,ptlb:Normal_Map,ptin:_Normal_Map,varname:node_1268,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e08c295755c0885479ad19f518286ff2,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Lerp,id:4283,x:35242,y:32320,varname:node_4283,prsc:2|A-1268-RGB,B-73-OUT,T-2696-OUT;n:type:ShaderForge.SFN_Vector3,id:73,x:34984,y:32398,varname:node_73,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Slider,id:2595,x:34844,y:32496,ptovrint:False,ptlb:Normal_Map_Intensity,ptin:_Normal_Map_Intensity,varname:node_2595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Negate,id:2696,x:35242,y:32444,varname:node_2696,prsc:2|IN-2595-OUT;n:type:ShaderForge.SFN_Slider,id:929,x:34404,y:32557,ptovrint:False,ptlb:Edge_Glow_Power,ptin:_Edge_Glow_Power,varname:node_929,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:3;n:type:ShaderForge.SFN_Slider,id:64,x:33331,y:32926,ptovrint:False,ptlb:Noise_Brightness,ptin:_Noise_Brightness,varname:node_64,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;proporder:9046-5653-6632-1268-2595-5253-174-61-64-322-6072-929;pass:END;sub:END;*/

Shader "Custom/DissolvePBR" {
    Properties {
        _Visibility ("Visibility", Range(-2, 2)) = 1
        _Base_Color ("Base_Color", 2D) = "white" {}
        _Tint ("Tint", Color) = (1,1,1,1)
        _Normal_Map ("Normal_Map", 2D) = "bump" {}
        _Normal_Map_Intensity ("Normal_Map_Intensity", Range(-1, 1)) = 0
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Glossiness ("Glossiness", Range(0, 1)) = 0
        _Noise ("Noise", 2D) = "white" {}
        _Noise_Brightness ("Noise_Brightness", Range(-1, 1)) = 0
        _Edge_width ("Edge_width", Range(0, 200)) = 91.26214
        _Glow_color ("Glow_color", Color) = (0,1,1,1)
        _Edge_Glow_Power ("Edge_Glow_Power", Range(0, 3)) = 3
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Edge_width;
            uniform float4 _Glow_color;
            uniform sampler2D _Base_Color; uniform float4 _Base_Color_ST;
            uniform float _Metallic;
            uniform float _Glossiness;
            uniform float4 _Tint;
            uniform sampler2D _Normal_Map; uniform float4 _Normal_Map_ST;
            uniform float _Normal_Map_Intensity;
            uniform float _Edge_Glow_Power;
            uniform float _Noise_Brightness;
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
                float3 _Normal_Map_var = UnpackNormal(tex2D(_Normal_Map,TRANSFORM_TEX(i.uv0, _Normal_Map)));
                float3 normalLocal = lerp(_Normal_Map_var.rgb,float3(0,0,1),(-1*_Normal_Map_Intensity));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4276 = pow((((_Noise_Brightness+_Noise_var.r)*_Visibility)*4.0),100.0);
                clip(clamp(node_4276,0,1) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossiness;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Base_Color_var = tex2D(_Base_Color,TRANSFORM_TEX(i.uv0, _Base_Color));
                float3 diffuseColor = (_Tint.rgb*_Base_Color_var.rgb); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_369_if_leA = step(_Edge_width,node_4276);
                float node_369_if_leB = step(node_4276,_Edge_width);
                float node_2733 = 0.0;
                float3 emissive = (_Glow_color.rgb*lerp((node_369_if_leA*node_2733)+(node_369_if_leB*1.0),node_2733,node_369_if_leA*node_369_if_leB)*_Edge_Glow_Power);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Edge_width;
            uniform float4 _Glow_color;
            uniform sampler2D _Base_Color; uniform float4 _Base_Color_ST;
            uniform float _Metallic;
            uniform float _Glossiness;
            uniform float4 _Tint;
            uniform sampler2D _Normal_Map; uniform float4 _Normal_Map_ST;
            uniform float _Normal_Map_Intensity;
            uniform float _Edge_Glow_Power;
            uniform float _Noise_Brightness;
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
                float3 _Normal_Map_var = UnpackNormal(tex2D(_Normal_Map,TRANSFORM_TEX(i.uv0, _Normal_Map)));
                float3 normalLocal = lerp(_Normal_Map_var.rgb,float3(0,0,1),(-1*_Normal_Map_Intensity));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_4276 = pow((((_Noise_Brightness+_Noise_var.r)*_Visibility)*4.0),100.0);
                clip(clamp(node_4276,0,1) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossiness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Base_Color_var = tex2D(_Base_Color,TRANSFORM_TEX(i.uv0, _Base_Color));
                float3 diffuseColor = (_Tint.rgb*_Base_Color_var.rgb); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Noise_Brightness;
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
                float node_4276 = pow((((_Noise_Brightness+_Noise_var.r)*_Visibility)*4.0),100.0);
                clip(clamp(node_4276,0,1) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
