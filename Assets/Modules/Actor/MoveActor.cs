using UnityEngine;
using System.Collections;

public class MoveActor : MonoBehaviour {
	NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	public void SetTarget(Vector3 target)
	{
		navMeshAgent.SetDestination (target);
	}
	public bool TargetApproach()
	{
		if(Vector3.Distance(transform.position,navMeshAgent.destination)<.5f)
			return true;
		return false;
	}
	void Update () {
	}
}
