using UnityEngine;
using System.Collections;

public class ammo:MonoBehaviour{
	public float speed=8;
	public float damage;
	public Transform target;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.position);
		transform.position += transform.forward*Time.deltaTime*speed;
		if (Vector3.Distance (target.position, transform.position) < 0.5f) {
			GetComponent<poolItem> ().objPool.GetComponent<ObjPool> ().PushGameObject (gameObject);
			target.GetComponent<HitComponent> ().Hurt (damage);
		}
	}
}
