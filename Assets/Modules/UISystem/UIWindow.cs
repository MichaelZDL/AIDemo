using UnityEngine;
using System.Collections;

public class UIWindow : MonoBehaviour {
	public int windowID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public virtual void Hide()
	{
		gameObject.SetActive (false);
	}
	public  virtual void Show()
	{
		gameObject.SetActive (true);
	}
}
