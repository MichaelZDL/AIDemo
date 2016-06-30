using UnityEngine;
using System.Collections;

public class MoveActor : MonoBehaviour {
	NavMeshAgent navMeshAgent;
	bool moving;
	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	public void SetTarget(Vector3 target)
	{
		moving = true;
		navMeshAgent.SetDestination (target);
	}
	public bool TargetApproach()
	{
		if(navMeshAgent.remainingDistance<.5f)
			return true;
		return false;
	}
	void Update () {
		if (moving == true) {
			if (TargetApproach ())
				moving = false;
		}
	}
}
