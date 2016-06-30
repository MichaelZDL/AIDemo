Shader "Hidden/jingxiang"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BlurTex ("BTexture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				//o.uv.y=1-o.uv.y;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
			fixed4 col=fixed4(0,0,0,1);
			float2 _offset=float2(0.7,0.7)-i.uv;
			float dist=length(_offset);
			_offset/=dist;
			float2 iuv=i.uv;
			col+=0.11*tex2D(_MainTex,i.uv+_offset*0.01);
			col+=0.11*tex2D(_MainTex,i.uv+_offset*0.03);
			col+=0.11*tex2D(_MainTex,i.uv+_offset*0.05);
			col+=0.11*tex2D(_MainTex,i.uv+_offset*0.07);
			col+=0.1*tex2D(_MainTex,i.uv+_offset*0.09);
			col+=0.11*tex2D(_MainTex,i.uv-_offset*0.01);
			col+=0.11*tex2D(_MainTex,i.uv-_offset*0.03);
			col+=0.11*tex2D(_MainTex,i.uv-_offset*0.05);
			col+=0.11*tex2D(_MainTex,i.uv-_offset*0.07);
			col+=0.11*tex2D(_MainTex,i.uv-_offset*0.09);
			return col;
			}
			ENDCG
		}
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				//o.uv.y=1-o.uv.y;
				return o;
			}
			sampler2D _MainTex;
			sampler2D _BlurTex;
			fixed4 frag (v2f i) : SV_Target
			{
				fixed dist=length(fixed2(0.3,0.3)-i.uv);
				fixed4 col=tex2D(_MainTex,i.uv);
				fixed4 blur=tex2D(_BlurTex,i.uv);
				col=col+blur*0.5;
				return col;
			}
			ENDCG
		}
	}
}

