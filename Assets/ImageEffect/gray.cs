using UnityEngine;
using System.Collections;

public class gray : MonoBehaviour {
	// Use this for initialization
	public Material mat;
	public Material mat2;
	public RenderTexture tex;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnRenderImage(RenderTexture src,RenderTexture des)
	{
		RenderTexture t=RenderTexture.GetTemporary (Screen.width,Screen.width, 24, RenderTextureFormat.ARGB32);
		tex = t;
		Graphics.Blit (t, des,mat);
		RenderTexture rt = RenderTexture.GetTemporary (Screen.width,Screen.height, 24, RenderTextureFormat.ARGB32);
		Graphics.Blit (rt, des,mat2);
		RenderTexture.ReleaseTemporary (t);
		RenderTexture.ReleaseTemporary (rt);
	}
}
