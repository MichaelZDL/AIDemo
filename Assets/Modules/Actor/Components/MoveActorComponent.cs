using UnityEngine;
using System.Collections;

public class MoveActorComponent : MonoBehaviour {
	MoveActor actor;
	ActorData actorData;
	public float maxLife;
	void Awake()
	{
		actorData = new ActorData ();
		actor = GetComponent<MoveActor> ();
		actorData.SetMax (maxLife);
	}
	public ActorData ActorData
	{
		get{
			return actorData;
		}
	}
	public void Move(Vector3 target)
	{
		actor.SetTarget (target);
	}
}
