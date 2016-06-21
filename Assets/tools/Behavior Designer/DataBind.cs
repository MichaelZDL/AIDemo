using UnityEngine;
using System.Collections;

public class DataBind : MonoBehaviour {
	public ActorData actorData;
	public ActorData enemyActorData;
	public BehaviorDesigner.Runtime.BehaviorTree behaviorTree;
	public Transform Home;
	public float selfLife;
	public float homeDistance;
	// Use this for initialization
	void Start () {
		actorData = GetComponent<MoveActorComponent> ().ActorData;
		enemyActorData = GetComponent<actorTest> ().testTarget.GetComponent<MoveActorComponent>().ActorData;
		behaviorTree = GetComponent<BehaviorDesigner.Runtime.BehaviorTree> ();
	}
	
	// Update is called once per frame
	void Update () {
		selfLife = actorData.Life;
		homeDistance = Vector3.Distance (Home.position, transform.position);
		behaviorTree.SetVariableValue ("selfLife", selfLife);
		behaviorTree.SetVariableValue ("killOdds", GetComponent<actorTest>().KillOdds());
	}
}
