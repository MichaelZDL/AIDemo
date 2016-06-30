using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
	Material mat;
	TEST_SAMPLE ts;
	// Use this for initialization
	void Start () {
		mat = Instantiate (GetComponent<MeshRenderer> ().material);
		GetComponent<MeshRenderer> ().material = mat;
		ts	= transform.parent.parent.GetComponent<TEST_SAMPLE> ();
	}
	
	// Update is called once per frame
	void Update () {
		mat.color = ts.DesecionCol;
	}
}
