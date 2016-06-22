using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coolDown : MonoBehaviour {
	float cooldownTime;
	float t;
	Material mat;
	// Use this for initialization
	void Start () {
		mat = GetComponent<Image> ().material;
	}
	public void SetCoolDownTime(float value)
	{
		cooldownTime = value;
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
