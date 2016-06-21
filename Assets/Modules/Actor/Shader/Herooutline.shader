Shader "Unlit/Herooutline"
{
	Properties
	{
		_MainTex ("SelfColor", Color) = (1,0,0,1)
		_OutLineColor("OutLineolor",Color)=(0,0,0,1)
		_lineWidth("OutlineWidth",float)=0.05

	}
	SubShader
	{
		Tags { 
		"RenderType"="Transparent"
		"Queue"="Transparent" 
		}
		LOD 200
		Pass
		{
		Cull front

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float3 normal:NORMAL;
			};
			float4 _OutLineColor;
			float _lineWidth;	
			v2f vert (appdata_base v)
			{
				v2f o;
				v.vertex.xyz+=v.normal*_lineWidth;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _OutLineColor;
			}
			ENDCG
		}
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal:NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float3 normal:NORMAL;
			};

			fixed4 _MainTex;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _MainTex;
			}
			ENDCG
		}
	}
}
