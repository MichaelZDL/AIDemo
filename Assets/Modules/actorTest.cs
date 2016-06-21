using UnityEngine;
using System.Collections;

public class actorTest : MonoBehaviour {
	public MoveActorComponent actorComponent;
	public AttackActorComponent attackController;
	public GameObject testTarget;
	float t;
	// Use this for initialization
	void Start () {

	}
	public void TestAttack()
	{
		if (Vector3.Distance (testTarget.transform.position, transform.position) > attackController.AttackData.AttackRange) {
			TestMove (testTarget.transform.position);
			return;
		} 
		else
			TestMove (transform.position);
		if (t > attackController.AttackData.AttackRate) {
			attackController.Attack (testTarget.transform);
			t = 0;
		}
	}
	public int KillOdds()
	{
		return (int)(testTarget.GetComponent<MoveActorComponent> ().ActorData.Life/attackController.damage)+1;
	}
	public void TestMove(Vector3 pos)
	{
		actorComponent.Move (pos);
	}
	public void FleeToHome()
	{
		
		TestMove (GetComponent<DataBind> ().Home.position);
	}

	// Update is called once per frame
	void Update () {
		if (t < 10)
			t += Time.deltaTime;
	}
}
