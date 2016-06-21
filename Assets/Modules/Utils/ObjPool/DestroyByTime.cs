using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float t;
	public float destroyTime;
	public float DestroyTime
	{
		set {
			t = 0;
			destroyTime = value;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (t >= destroyTime)
			GetComponent<poolItem> ().objPool.GetComponent<ObjPool> ().PushGameObject (gameObject);
	}
}
