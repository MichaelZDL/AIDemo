using UnityEngine;
using System.Collections;

public class glow : MonoBehaviour {
	public Material mat;
	public RenderTexture GlowRt;
	public RenderTexture t;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnRenderImage (RenderTexture src,RenderTexture des) {
		Graphics.Blit (GlowRt, t,mat,0);
		mat.SetTexture ("_GlowMap",t);
		Graphics.Blit (src, des,mat,1);
	}
}
