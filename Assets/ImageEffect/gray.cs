using UnityEngine;
using System.Collections;

public class gray : MonoBehaviour {
	// Use this for initialization
	public Material mat;
	public Material mat2;
	RenderTexture rt;

	void Start () {
		rt =new RenderTexture(Screen.width,Screen.height,24,RenderTextureFormat.ARGB32);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnRenderImage(RenderTexture src,RenderTexture des)
	{
		RenderTexture t=RenderTexture.GetTemporary (Screen.width,Screen.width, 24, RenderTextureFormat.ARGB32);
		RenderTexture rt2=RenderTexture.GetTemporary (Screen.width,Screen.width, 24, RenderTextureFormat.ARGB32);;
		rt2.filterMode = FilterMode.Bilinear;
		rt.filterMode = FilterMode.Bilinear;
		Graphics.Blit (t, rt2, mat);
		Graphics.Blit (rt2, rt,mat2,0);
		Graphics.Blit (rt, rt2,mat2,0);
		Graphics.Blit (rt2, rt,mat2,0);
		Graphics.Blit (rt, rt2,mat2,0);
		Graphics.Blit (rt2, rt,mat2,0);
		Graphics.Blit (rt, rt2,mat2,0);
		Graphics.Blit (rt2, rt,mat2,0);

		mat2.SetTexture ("_BlurTex", rt);
		Graphics.Blit (src, rt2, mat);
		Graphics.Blit (rt2, rt2, mat);
		//Graphics.Blit (src, des, mat2, 1);
		Graphics.Blit(rt2,des,mat2,1);
		RenderTexture.ReleaseTemporary (t);
		RenderTexture.ReleaseTemporary (rt2);
	}
}
