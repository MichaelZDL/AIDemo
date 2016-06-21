using UnityEngine;
using System.Collections;

public class AttackActorComponent : MonoBehaviour {
	public float Range;
	public float damage;
	AttackActorView actor;
	AttackActorData attackData;
	Transform attackTarget;
	public void Init()
	{
		actor = gameObject.GetComponent<AttackActorView> ();
		attackData = new AttackActorData ();
		attackData.SetRange (Range);
		attackData.AddDamage(damage);
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
			actor.Attack (attackTarget);
			return true;
		}
		return false;
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
