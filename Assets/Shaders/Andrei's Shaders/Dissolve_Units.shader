// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:36463,y:32669,varname:node_3138,prsc:2|diff-6294-OUT,spec-3108-OUT,gloss-1847-OUT,normal-4283-OUT,emission-7243-OUT,clip-8096-OUT;n:type:ShaderForge.SFN_Slider,id:9046,x:33324,y:33396,ptovrint:False,ptlb:Visibility,ptin:_Visibility,varname:node_9046,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:61,x:33281,y:33114,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_61,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fd007d02d6b063a419e56fe3939af343,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:872,x:33681,y:33000,varname:node_872,prsc:2|A-64-OUT,B-61-R;n:type:ShaderForge.SFN_Multiply,id:9987,x:34389,y:33505,varname:node_9987,prsc:2|A-872-OUT,B-560-OUT;n:type:ShaderForge.SFN_If,id:369,x:34804,y:32984,varname:node_369,prsc:2|A-322-OUT,B-6785-OUT,GT-9396-OUT,EQ-2733-OUT,LT-2733-OUT;n:type:ShaderForge.SFN_Slider,id:322,x:34404,y:32846,ptovrint:False,ptlb:Edge_width,ptin:_Edge_width,varname:node_322,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:52.45775,max:200;n:type:ShaderForge.SFN_Vector1,id:9396,x:34541,y:33005,varname:node_9396,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2733,x:34541,y:33062,varname:node_2733,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:6072,x:34561,y:32665,ptovrint:False,ptlb:Glow_color,ptin:_Glow_color,varname:node_6072,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6602,x:34832,y:32784,varname:node_6602,prsc:2|A-6072-RGB,B-369-OUT,C-929-OUT;n:type:ShaderForge.SFN_Tex2d,id:5653,x:34984,y:32028,ptovrint:False,ptlb:Base_Color,ptin:_Base_Color,varname:node_5653,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:5253,x:35123,y:32848,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_5253,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:174,x:35129,y:33108,ptovrint:False,ptlb:Glossiness,ptin:_Glossiness,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:6294,x:35188,y:32028,varname:node_6294,prsc:2|A-6632-RGB,B-5653-RGB;n:type:ShaderForge.SFN_Color,id:6632,x:34984,y:31847,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_6632,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1268,x:34984,y:32238,ptovrint:False,ptlb:Normal_Map,ptin:_Normal_Map,varname:node_1268,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Lerp,id:4283,x:35242,y:32320,varname:node_4283,prsc:2|A-1268-RGB,B-73-OUT,T-2696-OUT;n:type:ShaderForge.SFN_Vector3,id:73,x:34984,y:32398,varname:node_73,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Slider,id:2595,x:34844,y:32496,ptovrint:False,ptlb:Normal_Map_Intensity,ptin:_Normal_Map_Intensity,varname:node_2595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Negate,id:2696,x:35242,y:32444,varname:node_2696,prsc:2|IN-2595-OUT;n:type:ShaderForge.SFN_Slider,id:929,x:34404,y:32557,ptovrint:False,ptlb:Edge_Glow_Power,ptin:_Edge_Glow_Power,varname:node_929,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_Slider,id:64,x:33331,y:32926,ptovrint:False,ptlb:Noise_Brightness,ptin:_Noise_Brightness,varname:node_64,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Power,id:6785,x:34573,y:33148,varname:node_6785,prsc:2|VAL-2387-OUT,EXP-3015-OUT;n:type:ShaderForge.SFN_Slider,id:8020,x:33324,y:33569,ptovrint:False,ptlb:Visibility_multiplier,ptin:_Visibility_multiplier,varname:node_8020,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.880344,max:10;n:type:ShaderForge.SFN_Slider,id:1727,x:33972,y:33129,ptovrint:False,ptlb:Edge_Power,ptin:_Edge_Power,varname:node_1727,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5.461538,max:20;n:type:ShaderForge.SFN_Multiply,id:2387,x:34299,y:33203,varname:node_2387,prsc:2|A-9987-OUT,B-1727-OUT;n:type:ShaderForge.SFN_Multiply,id:2691,x:33856,y:33582,varname:node_2691,prsc:2|A-9046-OUT,B-8020-OUT;n:type:ShaderForge.SFN_Add,id:560,x:34192,y:33622,varname:node_560,prsc:2|A-2691-OUT,B-8111-OUT;n:type:ShaderForge.SFN_Slider,id:8111,x:33818,y:33827,ptovrint:False,ptlb:Visibility_floor,ptin:_Visibility_floor,varname:node_8111,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0.5,max:5;n:type:ShaderForge.SFN_Power,id:8096,x:34622,y:33588,varname:node_8096,prsc:2|VAL-9987-OUT,EXP-6617-OUT;n:type:ShaderForge.SFN_Slider,id:6617,x:34363,y:33781,ptovrint:False,ptlb:Visibility_power,ptin:_Visibility_power,varname:node_6617,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8471476,max:1;n:type:ShaderForge.SFN_Vector1,id:3015,x:34076,y:32868,varname:node_3015,prsc:2,v1:4;n:type:ShaderForge.SFN_Multiply,id:3108,x:35521,y:32624,varname:node_3108,prsc:2|A-7204-R,B-5253-OUT;n:type:ShaderForge.SFN_Tex2d,id:7204,x:35242,y:32619,ptovrint:False,ptlb:Metallic_map,ptin:_Metallic_map,varname:node_7204,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1715,x:35286,y:32940,ptovrint:False,ptlb:Gloss_map,ptin:_Gloss_map,varname:_Metallic_map_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1847,x:35505,y:32940,varname:node_1847,prsc:2|A-1715-G,B-174-OUT;n:type:ShaderForge.SFN_Tex2d,id:925,x:35558,y:33284,ptovrint:False,ptlb:Emission_map,ptin:_Emission_map,varname:node_925,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:be933de2695ae4440a0958f28008c03f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:139,x:35426,y:33480,ptovrint:False,ptlb:Emssion_power,ptin:_Emssion_power,varname:node_139,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.918127,max:10;n:type:ShaderForge.SFN_Add,id:7243,x:35911,y:33078,varname:node_7243,prsc:2|A-6602-OUT,B-9851-OUT;n:type:ShaderForge.SFN_Multiply,id:9851,x:35911,y:33211,varname:node_9851,prsc:2|A-925-RGB,B-139-OUT;proporder:9046-5653-6632-7204-5253-1715-174-1268-2595-925-139-61-64-322-6072-929-8020-1727-8111-6617;pass:END;sub:END;*/

Shader "Custom/DissolveUnit" {
    Properties {
        _Visibility ("Visibility", Range(0, 1)) = 1
        _Base_Color ("Base_Color", 2D) = "white" {}
        _Tint ("Tint", Color) = (1,1,1,1)
        _Metallic_map ("Metallic_map", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 1
        _Gloss_map ("Gloss_map", 2D) = "white" {}
        _Glossiness ("Glossiness", Range(0, 1)) = 1
        _Normal_Map ("Normal_Map", 2D) = "bump" {}
        _Normal_Map_Intensity ("Normal_Map_Intensity", Range(-1, 1)) = 0
        _Emission_map ("Emission_map", 2D) = "white" {}
        _Emssion_power ("Emssion_power", Range(0, 10)) = 2.918127
        _Noise ("Noise", 2D) = "white" {}
        _Noise_Brightness ("Noise_Brightness", Range(-1, 1)) = 0
        _Edge_width ("Edge_width", Range(0, 200)) = 52.45775
        _Glow_color ("Glow_color", Color) = (0,1,1,1)
        _Edge_Glow_Power ("Edge_Glow_Power", Range(0, 3)) = 0
        _Visibility_multiplier ("Visibility_multiplier", Range(0, 10)) = 2.880344
        _Edge_Power ("Edge_Power", Range(0, 20)) = 5.461538
        _Visibility_floor ("Visibility_floor", Range(-5, 5)) = 0.5
        _Visibility_power ("Visibility_power", Range(0, 1)) = 0.8471476
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
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
            uniform float _Visibility_multiplier;
            uniform float _Edge_Power;
            uniform float _Visibility_floor;
            uniform float _Visibility_power;
            uniform sampler2D _Metallic_map; uniform float4 _Metallic_map_ST;
            uniform sampler2D _Gloss_map; uniform float4 _Gloss_map_ST;
            uniform sampler2D _Emission_map; uniform float4 _Emission_map_ST;
            uniform float _Emssion_power;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
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
                float node_9987 = ((_Noise_Brightness+_Noise_var.r)*((_Visibility*_Visibility_multiplier)+_Visibility_floor));
                clip(pow(node_9987,_Visibility_power) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Gloss_map_var = tex2D(_Gloss_map,TRANSFORM_TEX(i.uv0, _Gloss_map));
                float gloss = (_Gloss_map_var.g*_Glossiness);
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
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
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
                float4 _Metallic_map_var = tex2D(_Metallic_map,TRANSFORM_TEX(i.uv0, _Metallic_map));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, (_Metallic_map_var.r*_Metallic), specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_369_if_leA = step(_Edge_width,pow((node_9987*_Edge_Power),4.0));
                float node_369_if_leB = step(pow((node_9987*_Edge_Power),4.0),_Edge_width);
                float node_2733 = 0.0;
                float4 _Emission_map_var = tex2D(_Emission_map,TRANSFORM_TEX(i.uv0, _Emission_map));
                float3 emissive = ((_Glow_color.rgb*lerp((node_369_if_leA*node_2733)+(node_369_if_leB*1.0),node_2733,node_369_if_leA*node_369_if_leB)*_Edge_Glow_Power)+(_Emission_map_var.rgb*_Emssion_power));
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
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
            uniform float _Visibility_multiplier;
            uniform float _Edge_Power;
            uniform float _Visibility_floor;
            uniform float _Visibility_power;
            uniform sampler2D _Metallic_map; uniform float4 _Metallic_map_ST;
            uniform sampler2D _Gloss_map; uniform float4 _Gloss_map_ST;
            uniform sampler2D _Emission_map; uniform float4 _Emission_map_ST;
            uniform float _Emssion_power;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
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
                float node_9987 = ((_Noise_Brightness+_Noise_var.r)*((_Visibility*_Visibility_multiplier)+_Visibility_floor));
                clip(pow(node_9987,_Visibility_power) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Gloss_map_var = tex2D(_Gloss_map,TRANSFORM_TEX(i.uv0, _Gloss_map));
                float gloss = (_Gloss_map_var.g*_Glossiness);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Base_Color_var = tex2D(_Base_Color,TRANSFORM_TEX(i.uv0, _Base_Color));
                float3 diffuseColor = (_Tint.rgb*_Base_Color_var.rgb); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _Metallic_map_var = tex2D(_Metallic_map,TRANSFORM_TEX(i.uv0, _Metallic_map));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, (_Metallic_map_var.r*_Metallic), specularColor, specularMonochrome );
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Noise_Brightness;
            uniform float _Visibility_multiplier;
            uniform float _Visibility_floor;
            uniform float _Visibility_power;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_9987 = ((_Noise_Brightness+_Noise_var.r)*((_Visibility*_Visibility_multiplier)+_Visibility_floor));
                clip(pow(node_9987,_Visibility_power) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Visibility;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Edge_width;
            uniform float4 _Glow_color;
            uniform sampler2D _Base_Color; uniform float4 _Base_Color_ST;
            uniform float _Metallic;
            uniform float _Glossiness;
            uniform float4 _Tint;
            uniform float _Edge_Glow_Power;
            uniform float _Noise_Brightness;
            uniform float _Visibility_multiplier;
            uniform float _Edge_Power;
            uniform float _Visibility_floor;
            uniform sampler2D _Metallic_map; uniform float4 _Metallic_map_ST;
            uniform sampler2D _Gloss_map; uniform float4 _Gloss_map_ST;
            uniform sampler2D _Emission_map; uniform float4 _Emission_map_ST;
            uniform float _Emssion_power;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_9987 = ((_Noise_Brightness+_Noise_var.r)*((_Visibility*_Visibility_multiplier)+_Visibility_floor));
                float node_369_if_leA = step(_Edge_width,pow((node_9987*_Edge_Power),4.0));
                float node_369_if_leB = step(pow((node_9987*_Edge_Power),4.0),_Edge_width);
                float node_2733 = 0.0;
                float4 _Emission_map_var = tex2D(_Emission_map,TRANSFORM_TEX(i.uv0, _Emission_map));
                o.Emission = ((_Glow_color.rgb*lerp((node_369_if_leA*node_2733)+(node_369_if_leB*1.0),node_2733,node_369_if_leA*node_369_if_leB)*_Edge_Glow_Power)+(_Emission_map_var.rgb*_Emssion_power));
                
                float4 _Base_Color_var = tex2D(_Base_Color,TRANSFORM_TEX(i.uv0, _Base_Color));
                float3 diffColor = (_Tint.rgb*_Base_Color_var.rgb);
                float specularMonochrome;
                float3 specColor;
                float4 _Metallic_map_var = tex2D(_Metallic_map,TRANSFORM_TEX(i.uv0, _Metallic_map));
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, (_Metallic_map_var.r*_Metallic), specColor, specularMonochrome );
                float4 _Gloss_map_var = tex2D(_Gloss_map,TRANSFORM_TEX(i.uv0, _Gloss_map));
                float roughness = 1.0 - (_Gloss_map_var.g*_Glossiness);
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
