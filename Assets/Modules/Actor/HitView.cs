using UnityEngine;
using System.Collections;

public class HitView : MonoBehaviour {
	Vector3 oriSize;
	public Transform target;
	// Use this for initialization
	void Start () {
		oriSize = target.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Hit()
	{
		if (oriSize==target.transform.localScale) {
			target.transform.localScale = oriSize*0.9f;
			Invoke ("Back", 0.12f);
		}
	}
	void Back()
	{
		target.transform.localScale = oriSize;
	}

}
