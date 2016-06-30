using UnityEngine;
using System.Collections;
using System;
public class MoveActorComponent : MonoBehaviour {
	NavMeshAgent navMeshAgent;
	MoveActor actor;
	ActorData actorData;
	bool moving;
	Vector3 des;
	public float maxLife;
	public bool test;
	public event EventHandler moveStartEvent;
	public event EventHandler moveEndEvent;
	void Awake()
	{
		actorData = new ActorData();
		actor = GetComponent<MoveActor> ();
		actorData.BindPlayer (gameObject);
		if(test)
		actorData.SetMax (maxLife);
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	public void SetTarget(Vector3 target)
	{
		navMeshAgent.SetDestination (target);
		des = target;
		moving = true;
	}
	public bool TargetApproach()
	{
		if(Vector3.Distance(des,transform.position)<.2f)
			return true;
		return false;
	}
	public ActorData ActorData
	{
		get{
			//print (transform.name + "fetch actorData");
			return actorData;
		}
	}
	public void Move(Vector3 target)
	{
		SetTarget (target);
		transform.forward = (target - transform.position).normalized;
		moveStartEvent(gameObject,EventArgs.Empty);
	}
	void Update () {
		if (moving == true) {
			if (TargetApproach ()) {
				print ("end move");
				moving = false;
				moveEndEvent (gameObject, EventArgs.Empty);
			}
		}
	}
}
