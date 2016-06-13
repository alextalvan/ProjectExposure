// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:34725,y:32596,varname:node_3138,prsc:2|normal-7143-OUT,emission-9639-RGB,custl-9358-OUT,alpha-7892-OUT,refract-3399-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32926,y:32328,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Slider,id:7892,x:34682,y:33145,ptovrint:False,ptlb:Transparency,ptin:_Transparency,varname:node_7892,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5717335,max:1;n:type:ShaderForge.SFN_NormalVector,id:8560,x:31666,y:32485,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:533,x:31666,y:32669,varname:node_533,prsc:2;n:type:ShaderForge.SFN_Dot,id:9286,x:32275,y:32490,varname:node_9286,prsc:2,dt:1|A-8560-OUT,B-533-OUT;n:type:ShaderForge.SFN_Vector1,id:2007,x:32275,y:32643,varname:node_2007,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:586,x:32491,y:32490,varname:node_586,prsc:2|A-9286-OUT,B-2007-OUT;n:type:ShaderForge.SFN_Multiply,id:258,x:32717,y:32490,varname:node_258,prsc:2|A-586-OUT,B-2007-OUT;n:type:ShaderForge.SFN_Multiply,id:9341,x:32926,y:32490,varname:node_9341,prsc:2|A-258-OUT,B-258-OUT;n:type:ShaderForge.SFN_Multiply,id:9219,x:33152,y:32490,varname:node_9219,prsc:2|A-7241-RGB,B-9341-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:1708,x:33508,y:32770,varname:node_1708,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9358,x:33717,y:32743,varname:node_9358,prsc:2|A-9500-OUT,B-1708-OUT,C-7613-RGB;n:type:ShaderForge.SFN_LightColor,id:7613,x:33522,y:32912,varname:node_7613,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:4462,x:31666,y:32847,varname:node_4462,prsc:2;n:type:ShaderForge.SFN_Dot,id:1236,x:32275,y:32759,varname:node_1236,prsc:2,dt:1|A-533-OUT,B-4462-OUT;n:type:ShaderForge.SFN_Power,id:8464,x:32492,y:32759,varname:node_8464,prsc:2|VAL-1236-OUT,EXP-5837-OUT;n:type:ShaderForge.SFN_Exp,id:5837,x:32275,y:32959,varname:node_5837,prsc:2,et:0|IN-3816-OUT;n:type:ShaderForge.SFN_Slider,id:3816,x:31891,y:32960,ptovrint:False,ptlb:Soec_power,ptin:_Soec_power,varname:node_3816,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:4.139117,max:10;n:type:ShaderForge.SFN_Slider,id:7791,x:32451,y:32959,ptovrint:False,ptlb:Soec_Int,ptin:_Soec_Int,varname:_Soec_power_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:3.075472,max:10;n:type:ShaderForge.SFN_Multiply,id:5228,x:32717,y:32759,varname:node_5228,prsc:2|A-8464-OUT,B-7791-OUT;n:type:ShaderForge.SFN_Add,id:9500,x:33522,y:32487,varname:node_9500,prsc:2|A-9219-OUT,B-5228-OUT,C-4072-OUT;n:type:ShaderForge.SFN_Tex2d,id:2721,x:33711,y:32304,ptovrint:False,ptlb:Normal_map,ptin:_Normal_map,varname:node_2721,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4b8d081e9d114c7f1100f5ab44295342,ntxv:3,isnm:True|UVIN-872-OUT;n:type:ShaderForge.SFN_NormalVector,id:7677,x:32494,y:33131,prsc:2,pt:False;n:type:ShaderForge.SFN_Transform,id:2606,x:33136,y:33131,varname:node_2606,prsc:2,tffrom:0,tfto:3|IN-8907-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8432,x:33522,y:33135,varname:node_8432,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2606-XYZ;n:type:ShaderForge.SFN_Multiply,id:2590,x:34117,y:33119,varname:node_2590,prsc:2|A-8432-OUT,B-3002-OUT;n:type:ShaderForge.SFN_Slider,id:3002,x:33365,y:33339,ptovrint:False,ptlb:Refr_Scale,ptin:_Refr_Scale,varname:node_3002,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:-0.15,max:0.5;n:type:ShaderForge.SFN_Multiply,id:8907,x:32840,y:33133,varname:node_8907,prsc:2|A-7677-OUT,B-1302-OUT;n:type:ShaderForge.SFN_Slider,id:1302,x:32461,y:33355,ptovrint:False,ptlb:Refr,ptin:_Refr,varname:_Refr_Scale_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0.6154097,max:2;n:type:ShaderForge.SFN_Vector3,id:3570,x:33711,y:32487,varname:node_3570,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Lerp,id:7143,x:33921,y:32487,varname:node_7143,prsc:2|A-2721-RGB,B-3570-OUT,T-5949-OUT;n:type:ShaderForge.SFN_Slider,id:5575,x:33192,y:32770,ptovrint:False,ptlb:Normal_intensity,ptin:_Normal_intensity,varname:node_5575,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:-2,max:2;n:type:ShaderForge.SFN_Negate,id:5949,x:33713,y:32580,varname:node_5949,prsc:2|IN-5575-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4402,x:34117,y:32904,varname:node_4402,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7143-OUT;n:type:ShaderForge.SFN_Add,id:3399,x:34343,y:32904,varname:node_3399,prsc:2|A-4402-OUT,B-2590-OUT;n:type:ShaderForge.SFN_Fresnel,id:7022,x:32925,y:32012,varname:node_7022,prsc:2|NRM-8560-OUT,EXP-243-OUT;n:type:ShaderForge.SFN_Slider,id:243,x:32586,y:31937,ptovrint:False,ptlb:Falloff_amuont,ptin:_Falloff_amuont,varname:node_243,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0,max:10;n:type:ShaderForge.SFN_Multiply,id:9885,x:33154,y:32136,varname:node_9885,prsc:2|A-7022-OUT,B-9341-OUT;n:type:ShaderForge.SFN_Multiply,id:4072,x:33365,y:31955,varname:node_4072,prsc:2|A-8202-OUT,B-9885-OUT,C-7321-RGB;n:type:ShaderForge.SFN_Slider,id:8202,x:32586,y:31838,ptovrint:False,ptlb:Falloff_intensity,ptin:_Falloff_intensity,varname:_Falloff_amuont_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:20;n:type:ShaderForge.SFN_Color,id:7321,x:32743,y:31663,ptovrint:False,ptlb:Fresnel_Color,ptin:_Fresnel_Color,varname:node_7321,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8823529,c2:0.05839101,c3:0.05839101,c4:1;n:type:ShaderForge.SFN_Time,id:7777,x:33759,y:33022,varname:node_7777,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:4861,x:33316,y:32331,varname:node_4861,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:872,x:33522,y:32304,varname:node_872,prsc:2|A-6031-OUT,B-4861-UVOUT;n:type:ShaderForge.SFN_Multiply,id:6031,x:33522,y:32162,varname:node_6031,prsc:2|A-3598-OUT,B-3318-T;n:type:ShaderForge.SFN_Time,id:3318,x:33316,y:32162,varname:node_3318,prsc:2;n:type:ShaderForge.SFN_Vector2,id:3598,x:33316,y:32077,varname:node_3598,prsc:2,v1:0,v2:-0.01;n:type:ShaderForge.SFN_Tex2d,id:9639,x:34367,y:32349,ptovrint:False,ptlb:Overlay,ptin:_Overlay,varname:node_9639,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;proporder:7241-7892-3816-7791-2721-3002-1302-5575-243-8202-7321-9639;pass:END;sub:END;*/

Shader "Shader Forge/Gatu_shader6_Glass" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Transparency ("Transparency", Range(0, 1)) = 0.5717335
        _Soec_power ("Soec_power", Range(0.1, 10)) = 4.139117
        _Soec_Int ("Soec_Int", Range(0.1, 10)) = 3.075472
        _Normal_map ("Normal_map", 2D) = "bump" {}
        _Refr_Scale ("Refr_Scale", Range(-0.5, 0.5)) = -0.15
        _Refr ("Refr", Range(-2, 2)) = 0.6154097
        _Normal_intensity ("Normal_intensity", Range(-2, 2)) = -2
        _Falloff_amuont ("Falloff_amuont", Range(-5, 10)) = 0
        _Falloff_intensity ("Falloff_intensity", Range(0, 20)) = 2
        _Fresnel_Color ("Fresnel_Color", Color) = (0.8823529,0.05839101,0.05839101,1)
        _Overlay ("Overlay", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Transparency;
            uniform float _Soec_power;
            uniform float _Soec_Int;
            uniform sampler2D _Normal_map; uniform float4 _Normal_map_ST;
            uniform float _Refr_Scale;
            uniform float _Refr;
            uniform float _Normal_intensity;
            uniform float _Falloff_amuont;
            uniform float _Falloff_intensity;
            uniform float4 _Fresnel_Color;
            uniform sampler2D _Overlay; uniform float4 _Overlay_ST;
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
                float4 screenPos : TEXCOORD5;
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
                float4 node_3318 = _Time + _TimeEditor;
                float2 node_872 = ((float2(0,-0.01)*node_3318.g)+i.uv0);
                float3 _Normal_map_var = UnpackNormal(tex2D(_Normal_map,TRANSFORM_TEX(node_872, _Normal_map)));
                float3 node_7143 = lerp(_Normal_map_var.rgb,float3(0,0,1),(-1*_Normal_intensity));
                float3 normalLocal = node_7143;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (node_7143.rg+(mul( UNITY_MATRIX_V, float4((i.normalDir*_Refr),0) ).xyz.rgb.rg*_Refr_Scale));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
////// Emissive:
                float4 _Overlay_var = tex2D(_Overlay,TRANSFORM_TEX(i.uv0, _Overlay));
                float3 emissive = _Overlay_var.rgb;
                float node_2007 = 0.5;
                float node_258 = ((max(0,dot(normalDirection,lightDirection))+node_2007)*node_2007);
                float node_9341 = (node_258*node_258);
                float3 node_9358 = (((_Color.rgb*node_9341)+(pow(max(0,dot(lightDirection,viewReflectDirection)),exp(_Soec_power))*_Soec_Int)+(_Falloff_intensity*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_Falloff_amuont)*node_9341)*_Fresnel_Color.rgb))*attenuation*_LightColor0.rgb);
                float3 finalColor = emissive + node_9358;
                return fixed4(lerp(sceneColor.rgb, finalColor,_Transparency),1);
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers d3d11 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Transparency;
            uniform float _Soec_power;
            uniform float _Soec_Int;
            uniform sampler2D _Normal_map; uniform float4 _Normal_map_ST;
            uniform float _Refr_Scale;
            uniform float _Refr;
            uniform float _Normal_intensity;
            uniform float _Falloff_amuont;
            uniform float _Falloff_intensity;
            uniform float4 _Fresnel_Color;
            uniform sampler2D _Overlay; uniform float4 _Overlay_ST;
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
                float4 screenPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
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
                float4 node_3318 = _Time + _TimeEditor;
                float2 node_872 = ((float2(0,-0.01)*node_3318.g)+i.uv0);
                float3 _Normal_map_var = UnpackNormal(tex2D(_Normal_map,TRANSFORM_TEX(node_872, _Normal_map)));
                float3 node_7143 = lerp(_Normal_map_var.rgb,float3(0,0,1),(-1*_Normal_intensity));
                float3 normalLocal = node_7143;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (node_7143.rg+(mul( UNITY_MATRIX_V, float4((i.normalDir*_Refr),0) ).xyz.rgb.rg*_Refr_Scale));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_2007 = 0.5;
                float node_258 = ((max(0,dot(normalDirection,lightDirection))+node_2007)*node_2007);
                float node_9341 = (node_258*node_258);
                float3 node_9358 = (((_Color.rgb*node_9341)+(pow(max(0,dot(lightDirection,viewReflectDirection)),exp(_Soec_power))*_Soec_Int)+(_Falloff_intensity*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_Falloff_amuont)*node_9341)*_Fresnel_Color.rgb))*attenuation*_LightColor0.rgb);
                float3 finalColor = node_9358;
                return fixed4(finalColor * _Transparency,0);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
