using UnityEngine;
using System.Collections;

public class UIWindow : MonoBehaviour {
	int windowID;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Hide()
	{
		gameObject.SetActive (false);
	}
	void Show()
	{
		gameObject.SetActive (true);
	}
}
