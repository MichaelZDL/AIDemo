using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoolDown : MonoBehaviour {
	float cooldownTime;
	float t;
	Material mat;
	// Use this for initialization
	void Awake () {
		mat = Instantiate (GetComponent<RawImage> ().material);
		GetComponent<RawImage> ().material = mat;
	}
	public void SetCoolDownTime(float value)
	{
		cooldownTime = value;
		t = value;
		//print (gameObject.name);
		mat.SetFloat ("_amount", 1 - t / cooldownTime);
	}
	public void BeginCoolDown()
	{
		t = 0;

	}
	// Update is called once per frame
	void Update () {
		if (t < cooldownTime) {
			t += Time.deltaTime;
			mat.SetFloat ("_amount", 1 - t / cooldownTime);
		}
	}
}
