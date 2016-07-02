Shader "Custom/ProjectorMultiply" {
   Properties {
      _ShadowTex ("Cookie", 2D) = "gray" { TexGen ObjectLinear }
      _FalloffTex ("FallOff", 2D) = "white" { TexGen ObjectLinear   }
      _Color ("Color", Color) = (1,1,1,1)
   }

   Subshader {
      Tags { "RenderType"="Transparent-1" }
      Pass {
         ZWrite Off
         Fog { Color (1, 1, 1) }
         AlphaTest Greater 0
         ColorMask RGB
         Blend DstColor Zero
		 Offset -1, -1
         SetTexture [_ShadowTex] {
            combine texture, ONE - texture
            Matrix [_Projector]
         }
        // fixed4 _Color;
         SetTexture [_FalloffTex] {
            constantColor (1,1,1,0)
            combine previous lerp (texture) constant
            Matrix [_ProjectorClip]
         }
        SetTexture [_ShadowTex] {
           	constantColor[_Color]
            combine previous + constant
         }
      }
   }
}