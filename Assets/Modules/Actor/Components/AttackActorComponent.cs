using UnityEngine;
using System.Collections;
using System;
public class AttackActorComponent : MonoBehaviour {
	public float Range;
	public float damage;
	AttackActorView actor;
	public bool test;
	AttackActorData attackData;
	Transform attackTarget;
	bool attack;
	int attackFrame;
	int attackEffectFrame=21;
	public delegate void AttackEventHandler(Vector3 dir);
	public event AttackEventHandler AttackEvent;
	public void Init()
	{
		actor = gameObject.GetComponent<AttackActorView> ();
		attackData = new AttackActorData ();
		if (test) {
			attackData.SetRange (Range);
			attackData.AddDamage (damage);
		}
	}
	public void SetDamage(float value)
	{
		attackData.AddDamage(value);
	}
	public AttackActorData AttackData
	{
		get{
			return attackData;
		}
	}
	void Awake()
	{
		Init ();
	}
	public bool Attack(Transform target)
	{
		attackTarget = target;
		if (Vector3.Distance (gameObject.transform.position,target.position) < attackData.AttackRange) {
			actor.transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
			AttackEvent (transform.forward);
			attack = true;
			return true;
		}
		return false;
	}
	public void atk()
	{
		//print ("atk");
		actor.Attack (attackTarget);
	}
	void Update()
	{
		if (attack) {
			if (attackFrame == attackEffectFrame) {
				//actor.Attack (attackTarget);
				attackFrame = 0;
				attack = false;
			}
			attackFrame += 1;
			if (Mathf.Abs(GetComponent<tempController>().state)!=1) {
				attackFrame = 0;
				attack = false;
			}
		}
	}
	/*
		if (Vector3.Distance (gameObject.transform.position, attackTarget.position) > attackData.AttackRange&&GetComponent<ActorView>()!=null) {
			InvokeRepeating ("CheckRange", 0, 0.1f);		
		}
		else
			actor.Attack (attackTarget.position);
		
	}

	void CheckRange()
	{
		GetComponent<ActorController> ().Move (attackTarget.position);
		if (Vector3.Distance (gameObject.transform.position, attackTarget.position) < attackData.AttackRange) {
			GetComponent<ActorController> ().Move (transform.position);
			actor.Attack (attackTarget.position);
			CancelInvoke ("CheckRange");
		}
	}
	*/
}
