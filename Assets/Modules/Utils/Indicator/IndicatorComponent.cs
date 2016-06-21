using UnityEngine;
using System.Collections;

public class IndicatorComponent : MonoBehaviour {
	public AttackActorData attackData;
	public GameObject indicator;
	// Use this for initialization
	void Start () {
		attackData = GetComponent<AttackActorComponent> ().AttackData;
		indicator.transform.localScale=new Vector3(attackData.AttackRange*2,0.001f,attackData.AttackRange*2);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position,transform.forward*attackData.AttackRange);
	}
}
