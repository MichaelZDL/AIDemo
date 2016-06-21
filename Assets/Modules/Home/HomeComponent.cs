using UnityEngine;
using System.Collections;

public class HomeComponent : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < 1.5)
			player.GetComponent<HitComponent> ().Heal (20);
	}
}
