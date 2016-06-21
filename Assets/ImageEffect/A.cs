using UnityEngine;
using System.Collections;

public class A : MonoBehaviour {
	public Transform B;
	// Use this for initialization
	void Start () {
		print ("A:"+transform.position);
		print ("B:"+B.transform.position);
		print("B-A"+(B.transform.position-transform.position));
		print ("A+:" + (transform.position + (B.transform.position - transform.position).normalized));
	}
	
	// Update is called once per frame
	void Update () {
	}
}
