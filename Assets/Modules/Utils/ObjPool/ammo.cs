using UnityEngine;
using System.Collections;

public class ammo:MonoBehaviour{
	public float speed=8;
	public float damage;
	public Transform target;
	bool en;
	// Use this for initialization
	void Start () {
		en = true;
	}
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.position+Vector3.up*.6f);
		transform.position += transform.forward*Time.deltaTime*speed;
		if (Vector3.Distance (target.position+Vector3.up*.6f, transform.position) < 1&&en==true) {
			target.GetComponent<HitComponent> ().Hurt (damage);
			en = false;
		}
	}
}
