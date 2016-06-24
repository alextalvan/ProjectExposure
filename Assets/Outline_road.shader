// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:34050,y:32134,varname:node_9361,prsc:2|diff-4690-OUT,spec-1694-OUT,gloss-4637-OUT,emission-5794-OUT,amdfl-6744-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:31936,y:31129,ptovrint:False,ptlb:Emssion_Texture_player1,ptin:_Emssion_Texture_player1,varname:_Emssion_Texture_player1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:544,x:32295,y:31243,cmnt:Diffuse Color,varname:node_544,prsc:2|A-851-RGB,B-3998-RGB,C-8755-OUT;n:type:ShaderForge.SFN_Slider,id:8755,x:31658,y:31563,ptovrint:False,ptlb:Emission_Intensity_player1,ptin:_Emission_Intensity_player1,varname:_Emission_Intensity_player1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.047401,max:99;n:type:ShaderForge.SFN_Tex2d,id:3021,x:33970,y:31448,ptovrint:False,ptlb:Diffuse_Texture,ptin:_Diffuse_Texture,varname:_Diffuse_Texture,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e4dbd078216ec99458aa0ef429011168,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6744,x:33298,y:32567,varname:node_6744,prsc:2|A-5963-RGB,B-8347-OUT,C-8596-OUT;n:type:ShaderForge.SFN_LightColor,id:5963,x:33064,y:32656,varname:node_5963,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:8347,x:33064,y:32820,varname:node_8347,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:1527,x:32037,y:32852,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:7754,x:32037,y:33000,varname:node_7754,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:5339,x:32037,y:33134,varname:node_5339,prsc:2;n:type:ShaderForge.SFN_Dot,id:3185,x:32385,y:33092,varname:node_3185,prsc:2,dt:1|A-7754-OUT,B-5339-OUT;n:type:ShaderForge.SFN_Dot,id:6443,x:32385,y:32917,varname:node_6443,prsc:2,dt:1|A-1527-OUT,B-7754-OUT;n:type:ShaderForge.SFN_Multiply,id:8036,x:32670,y:32958,varname:node_8036,prsc:2|A-2857-RGB,B-6443-OUT;n:type:ShaderForge.SFN_Color,id:2857,x:32385,y:32743,ptovrint:False,ptlb:Light_color,ptin:_Light_color,varname:_Light_color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Power,id:8199,x:32670,y:33097,varname:node_8199,prsc:2|VAL-3185-OUT,EXP-4288-OUT;n:type:ShaderForge.SFN_Exp,id:4288,x:32385,y:33285,varname:node_4288,prsc:2,et:1|IN-6160-OUT;n:type:ShaderForge.SFN_Slider,id:6160,x:31958,y:33375,ptovrint:False,ptlb:Spec_Power,ptin:_Spec_Power,varname:_Spec_Power,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:9;n:type:ShaderForge.SFN_Multiply,id:8596,x:33127,y:33087,varname:node_8596,prsc:2|A-8036-OUT,B-4285-OUT;n:type:ShaderForge.SFN_Slider,id:4707,x:32643,y:33324,ptovrint:False,ptlb:Spec_Intensity,ptin:_Spec_Intensity,varname:_Spec_Intensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:9;n:type:ShaderForge.SFN_Multiply,id:4285,x:32913,y:33087,varname:node_4285,prsc:2|A-8199-OUT,B-4707-OUT;n:type:ShaderForge.SFN_Color,id:6879,x:33970,y:31633,ptovrint:False,ptlb:Diffuse_tint,ptin:_Diffuse_tint,varname:_Diffuse_tint,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4690,x:34190,y:31532,varname:node_4690,prsc:2|A-3021-RGB,B-6879-RGB;n:type:ShaderForge.SFN_Slider,id:1694,x:34009,y:31884,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:_Metallic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:4637,x:34009,y:31967,ptovrint:False,ptlb:Glosssiness,ptin:_Glosssiness,varname:_Glosssiness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.0751807,max:1;n:type:ShaderForge.SFN_Tex2d,id:6323,x:31931,y:31915,ptovrint:False,ptlb:Emssion_Texture_player2,ptin:_Emssion_Texture_player2,varname:_Emssion_Texture_player2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:5853,x:31933,y:32319,ptovrint:False,ptlb:Emission_Intensity_player2,ptin:_Emission_Intensity_player2,varname:_Emission_Intensity_player2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.047401,max:99;n:type:ShaderForge.SFN_Multiply,id:8948,x:32347,y:32184,cmnt:Diffuse Color,varname:node_8948,prsc:2|A-6323-RGB,B-944-RGB,C-5853-OUT;n:type:ShaderForge.SFN_TexCoord,id:532,x:31222,y:31354,varname:node_532,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:2804,x:32108,y:31975,ptovrint:False,ptlb:CityClip,ptin:_CityClip,varname:_CityClip,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5675753,max:1;n:type:ShaderForge.SFN_If,id:7561,x:31786,y:31721,varname:node_7561,prsc:2|A-532-V,B-2804-OUT,GT-3998-RGB,EQ-944-RGB,LT-944-RGB;n:type:ShaderForge.SFN_ComponentMask,id:5528,x:31991,y:31721,varname:node_5528,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7561-OUT;n:type:ShaderForge.SFN_Color,id:3998,x:31558,y:31947,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:_Color1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.03137255,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:944,x:31158,y:32020,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:_Color2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Add,id:5794,x:32965,y:31755,varname:node_5794,prsc:2|A-1647-OUT,B-6802-OUT;n:type:ShaderForge.SFN_Multiply,id:6802,x:32655,y:31983,varname:node_6802,prsc:2|A-5528-OUT,B-8948-OUT;n:type:ShaderForge.SFN_OneMinus,id:3678,x:32295,y:31635,varname:node_3678,prsc:2|IN-5528-OUT;n:type:ShaderForge.SFN_Multiply,id:1647,x:32529,y:31358,varname:node_1647,prsc:2|A-544-OUT,B-3678-OUT;n:type:ShaderForge.SFN_Rotator,id:8535,x:32299,y:33542,varname:node_8535,prsc:2;proporder:2804-3998-944-3021-6879-1694-4637-851-8755-6323-5853-6160-4707-2857;pass:END;sub:END;*/

Shader "Custom/Outline_Road" {
    Properties {
        _CityClip ("CityClip", Range(0, 1)) = 0.5675753
        _Color1 ("Color1", Color) = (0.03137255,0,1,1)
        _Color2 ("Color2", Color) = (1,0,0,1)
        _Diffuse_Texture ("Diffuse_Texture", 2D) = "white" {}
        _Diffuse_tint ("Diffuse_tint", Color) = (1,1,1,1)
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Glosssiness ("Glosssiness", Range(0, 1)) = 0.0751807
        _Emssion_Texture_player1 ("Emssion_Texture_player1", 2D) = "white" {}
        _Emission_Intensity_player1 ("Emission_Intensity_player1", Range(0, 99)) = 2.047401
        _Emssion_Texture_player2 ("Emssion_Texture_player2", 2D) = "white" {}
        _Emission_Intensity_player2 ("Emission_Intensity_player2", Range(0, 99)) = 2.047401
        _Spec_Power ("Spec_Power", Range(0, 9)) = 0
        _Spec_Intensity ("Spec_Intensity", Range(0, 9)) = 0
        _Light_color ("Light_color", Color) = (1,1,1,1)
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Emssion_Texture_player1; uniform float4 _Emssion_Texture_player1_ST;
            uniform float _Emission_Intensity_player1;
            uniform sampler2D _Diffuse_Texture; uniform float4 _Diffuse_Texture_ST;
            uniform float4 _Light_color;
            uniform float _Spec_Power;
            uniform float _Spec_Intensity;
            uniform float4 _Diffuse_tint;
            uniform float _Metallic;
            uniform float _Glosssiness;
            uniform sampler2D _Emssion_Texture_player2; uniform float4 _Emssion_Texture_player2_ST;
            uniform float _Emission_Intensity_player2;
            uniform float _CityClip;
            uniform float4 _Color1;
            uniform float4 _Color2;
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
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
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
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glosssiness;
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
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Diffuse_Texture_var = tex2D(_Diffuse_Texture,TRANSFORM_TEX(i.uv0, _Diffuse_Texture));
                float3 diffuseColor = (_Diffuse_Texture_var.rgb*_Diffuse_tint.rgb); // Need this for specular when using metallic
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
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += (_LightColor0.rgb*attenuation*((_Light_color.rgb*max(0,dot(normalDirection,lightDirection)))*(pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(_Spec_Power))*_Spec_Intensity))); // Diffuse Ambient Light
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _Emssion_Texture_player1_var = tex2D(_Emssion_Texture_player1,TRANSFORM_TEX(i.uv0, _Emssion_Texture_player1));
                float node_7561_if_leA = step(i.uv0.g,_CityClip);
                float node_7561_if_leB = step(_CityClip,i.uv0.g);
                float node_5528 = lerp((node_7561_if_leA*_Color2.rgb)+(node_7561_if_leB*_Color1.rgb),_Color2.rgb,node_7561_if_leA*node_7561_if_leB).r;
                float4 _Emssion_Texture_player2_var = tex2D(_Emssion_Texture_player2,TRANSFORM_TEX(i.uv0, _Emssion_Texture_player2));
                float3 emissive = (((_Emssion_Texture_player1_var.rgb*_Color1.rgb*_Emission_Intensity_player1)*(1.0 - node_5528))+(node_5528*(_Emssion_Texture_player2_var.rgb*_Color2.rgb*_Emission_Intensity_player2)));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Emssion_Texture_player1; uniform float4 _Emssion_Texture_player1_ST;
            uniform float _Emission_Intensity_player1;
            uniform sampler2D _Diffuse_Texture; uniform float4 _Diffuse_Texture_ST;
            uniform float4 _Diffuse_tint;
            uniform float _Metallic;
            uniform float _Glosssiness;
            uniform sampler2D _Emssion_Texture_player2; uniform float4 _Emssion_Texture_player2_ST;
            uniform float _Emission_Intensity_player2;
            uniform float _CityClip;
            uniform float4 _Color1;
            uniform float4 _Color2;
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
                UNITY_FOG_COORDS(9)
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
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glosssiness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Diffuse_Texture_var = tex2D(_Diffuse_Texture,TRANSFORM_TEX(i.uv0, _Diffuse_Texture));
                float3 diffuseColor = (_Diffuse_Texture_var.rgb*_Diffuse_tint.rgb); // Need this for specular when using metallic
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
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Emssion_Texture_player1; uniform float4 _Emssion_Texture_player1_ST;
            uniform float _Emission_Intensity_player1;
            uniform sampler2D _Diffuse_Texture; uniform float4 _Diffuse_Texture_ST;
            uniform float4 _Diffuse_tint;
            uniform float _Metallic;
            uniform float _Glosssiness;
            uniform sampler2D _Emssion_Texture_player2; uniform float4 _Emssion_Texture_player2_ST;
            uniform float _Emission_Intensity_player2;
            uniform float _CityClip;
            uniform float4 _Color1;
            uniform float4 _Color2;
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
                
                float4 _Emssion_Texture_player1_var = tex2D(_Emssion_Texture_player1,TRANSFORM_TEX(i.uv0, _Emssion_Texture_player1));
                float node_7561_if_leA = step(i.uv0.g,_CityClip);
                float node_7561_if_leB = step(_CityClip,i.uv0.g);
                float node_5528 = lerp((node_7561_if_leA*_Color2.rgb)+(node_7561_if_leB*_Color1.rgb),_Color2.rgb,node_7561_if_leA*node_7561_if_leB).r;
                float4 _Emssion_Texture_player2_var = tex2D(_Emssion_Texture_player2,TRANSFORM_TEX(i.uv0, _Emssion_Texture_player2));
                o.Emission = (((_Emssion_Texture_player1_var.rgb*_Color1.rgb*_Emission_Intensity_player1)*(1.0 - node_5528))+(node_5528*(_Emssion_Texture_player2_var.rgb*_Color2.rgb*_Emission_Intensity_player2)));
                
                float4 _Diffuse_Texture_var = tex2D(_Diffuse_Texture,TRANSFORM_TEX(i.uv0, _Diffuse_Texture));
                float3 diffColor = (_Diffuse_Texture_var.rgb*_Diffuse_tint.rgb);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Glosssiness;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
