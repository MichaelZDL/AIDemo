using UnityEngine;
using System.Collections;

public class actorTest : MonoBehaviour {
	public MoveActorComponent actorComponent;
	public AttackActorComponent attackController;
	public AttackActorComponent enemyAttack;
	public GameObject testTarget;
	public string panelName;
	float t;
	// Use this for initialization
	void Start () {
		enemyAttack = testTarget.GetComponent<AttackActorComponent> ();
		//transform.Find ("/Canvas/HUD/" + panelName).GetComponent<PlayerInfo> ().BindPlayer (gameObject);
		//if (GetComponent<SkillComponent> () != null) {
			//transform.Find ("/Canvas/HUD/Skill").GetComponent<SkillManager> ().BindPlayer (gameObject);
		//}
	}
	public bool TestAttack()
	{
		if (Vector3.Distance (testTarget.transform.position, transform.position) > attackController.AttackData.AttackRange) {
			TestMove (testTarget.transform.position);
			return false;
		} 
		else
			TestMove (transform.position+transform.forward*0.001f);
		if (t > attackController.AttackData.AttackRate) {
			attackController.Attack (testTarget.transform);
			t = 0;
		}
		return true;
	}
	public void MoveToEnemy()
	{
		TestMove (testTarget.transform.position);
	}
	public bool enemyInRange()
	{
		if (Vector3.Distance (testTarget.transform.position, transform.position) > attackController.AttackData.AttackRange)
			return false;
		else
			return true;
	}
	public void SimpleAttack()
	{
		if (t > attackController.AttackData.AttackRate) {
			if (Vector3.Angle (transform.forward, testTarget.transform.position - transform.position) > 1) {
				TestMove (transform.position + transform.forward * 0.001f);
				transform.LookAt (testTarget.transform.position);
			}
			if (Vector3.Distance (testTarget.transform.position, transform.position) <= attackController.AttackData.AttackRange) {
				attackController.Attack (testTarget.transform);
				t = 0;
			}
		}
	}
	public void AddAttack(float value)
	{
		attackController.AttackData.AddDamage (value);
	}
	public int KillOdds()
	{
		return (int)(testTarget.GetComponent<MoveActorComponent> ().ActorData.Life/attackController.damage)+1;
	}
	public int RealDamage()
	{
		return (int)(enemyAttack.AttackData.Damage*actorComponent.ActorData.CutDamage);
	}
	public bool TestMove(Vector3 pos)
	{
		actorComponent.Move (pos);
		return true;
	}
	public void FleeToHome()
	{
		TestMove (GetComponent<DataBind>().Home.position);
	}
	public bool TestShield()
	{
		if (GetComponent<SkillComponent> ().Shield ())
			return true;
		return false;
	}
	public bool TestHeal()
	{
		if (GetComponent<SkillComponent> ().Heal ())
			return true;
		return false;
	}
	// Update is called once per frame
	void Update () {
		if (t < 10)
			t += Time.deltaTime;
		
	}
}
