﻿Shader "Hidden/DPLayout/TextureArrayIcon"
{
	Properties
	{
		[PerRendererData] _MainTex ("Texture", 2D) = "white" {}
		[PerRendererData] _MainTexArr("Texture Array", 2DArray) = "white" {}
		_Index("Index", Float) = 0 
		
		_Roundness ("Roundness", Range(0.0, 1.0)) = 0.25
		_Borders ("Borders", Range(0.0, 1.0)) = 0.05
		_Crispness ("Crispness", Float) = 40
		[Gamma] _GammaGray("Gray", Range(0.0, 1.0)) = 0.5 //use uniform float4 _MainTex_HDR instead?
	}
	SubShader
	{
		Cull Off
		Lighting Off
		ZWrite Off
		ZTest[unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex   : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				float2 texcoord  : TEXCOORD0;
				float4 worldPosition : TEXCOORD1;
			};


			sampler2D _MainTex;
			Texture2DArray _MainTexArr;
			SamplerState sampler_MainTexArr;
			float _Index;
			float _Roundness;
			float _Borders;
			float _Crispness;
			float _GammaGray;
			uniform int _IsLinear;

			v2f vert (appdata v)
			{
				v2f o;
				o.worldPosition = v.vertex;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = _MainTexArr.Sample(sampler_MainTexArr, float3(i.texcoord, _Index));

				if (_IsLinear ==1) col.rgb = LinearToGammaSpace(col.rgb);

				float2 halfUV = i.texcoord;
				if (i.texcoord.x > 0.5) halfUV.x = 1 - i.texcoord.x;
				if (i.texcoord.y > 0.5) halfUV.y = 1 - i.texcoord.y;
				
				float dist = min(halfUV.x, halfUV.y);

				//roundness
				if (halfUV.x < _Roundness && halfUV.y < _Roundness)
				{
					float2 roundnessPivot = float2(_Roundness, _Roundness);
					float roundnessDist = distance(halfUV, roundnessPivot);
					dist = _Roundness-roundnessDist;
				}
				col.a = saturate(dist*_Crispness);

				//borders
				col.rgb = col.rgb * saturate((dist-_Borders)*_Crispness);

				//clipping
				col.a *= step(0, i.worldPosition.y);
				clip(col.a - 0.001);

				return col;
			}
			ENDCG
		}
	}
}

