Shader "Custom/CustomCutOff"
{
	Properties
	{
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_CoverTex ("Cover Texture", 2D) = "red" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_ValueX ("Value x", Range(0.0, 1.0)) = 1.0
		_ValueY ("Value y", Range(0.0, 1.0)) = 1.0
		_CoverUvRangeV ("Cover Uv Range V", Range(0.0, 30.0)) = 1.0
		_CoverUvRangeU ("Cover Uv Range U", Range(0.0, 30.0)) = 1.0
		_SpeedUpTime ("Speed Up Time", float) = 5.0

	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#pragma shader_feature ETC1_EXTERNAL_ALPHA
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;
			sampler2D _MainTex;
			sampler2D _CoverTex;
			sampler2D _AlphaTex;
			float _ValueX;
			float _ValueY;
			float _CoverUvRangeV;
			float _CoverUvRangeU;
			float _SpeedUpTime;

			v2f vert(appdata_t IN)
			{
				v2f OUT;


				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;

				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}



			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv.rg);

						#if ETC1_EXTERNAL_ALPHA // get the color from an external texture (usecase: Alpha support for ETC1 on android)
				
				color.a = tex2D (_AlphaTex, uv).r;	

						#endif //ETC1_EXTERNAL_ALPHA


				return color;
			}

			fixed4 SampleCoverTexture (float2 uv)
			{


            	//uv.r *= _CoverUvRangeU;
            	//uv.g *= _CoverUvRangeV - abs(_Time.r*_SpeedUpTime);

				fixed4 cover = tex2D (_CoverTex, (uv.r, uv.g*_CoverUvRangeV - abs(_Time.r*_SpeedUpTime)));
			
				//if (uv.g =1) uv.g=0;

						#if ETC1_EXTERNAL_ALPHA // get the color from an external texture (usecase: Alpha support for ETC1 on android)
				
				cover.a = tex2D (_AlphaTex, uv).rg;	

						#endif //ETC1_EXTERNAL_ALPHA

				return cover;
			}



			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = fixed4(0,0,0,0);
				fixed4 e = fixed4(0,0,0,0);
				if (IN.texcoord.x < _ValueX && IN.texcoord.y < _ValueY) {
					c = (SampleSpriteTexture (IN.texcoord) * IN.color) ;
					c.rgb *= c.a;
					e = (SampleCoverTexture (IN.texcoord) * IN.color) ;
					e.rgb *= e.a;

				}

				return c+e*c.a;
			}
		ENDCG
		}
	}
}
