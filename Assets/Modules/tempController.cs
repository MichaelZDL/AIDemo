using UnityEngine;
using System.Collections;

public class tempController : MonoBehaviour {
	public int state;
	int addIndex;
	Vector3 targetPos;
	public bool locked;
	public bool human;
	TEST_SAMPLE fuzzy;
	// Use this for initialization
	void Start () {
		if (GetComponent<TEST_SAMPLE> () != null) {
			fuzzy = GetComponent<TEST_SAMPLE> ();
			human = false;
		}
		state = 1;
		targetPos = Vector3.zero;
	}
	public void ReleaseLock()
	{
		locked = false;
	}
	// Update is called once per frame
	void Update () {
		if (locked)
			return;
		if (human)
			humanInputControl ();
		else
			FuzzyInputControl ();
	}
	void humanInputControl()
	{
		if (Input.GetKeyDown (KeyCode.W)) {
			switch (addIndex) {
			case 0:
				GameObject.Find ("PlayerRed").GetComponent<MoveActorComponent> ().ActorData.SetLife (35);
				GetComponent<AttackActorComponent> ().AttackData.AddDamage (-GetComponent<AttackActorComponent> ().AttackData.Damage + 6);
				addIndex = 1;
				break;
			case 1:
				GameObject.Find ("PlayerRed").GetComponent<MoveActorComponent> ().ActorData.SetLife (43);
				GetComponent<AttackActorComponent> ().AttackData.AddDamage (-GetComponent<AttackActorComponent> ().AttackData.Damage + 8);
				addIndex = 2;
				break;
			case 2:
				GameObject.Find ("PlayerRed").GetComponent<MoveActorComponent> ().ActorData.SetLife (100);
				GetComponent<AttackActorComponent> ().AttackData.AddDamage (-GetComponent<AttackActorComponent> ().AttackData.Damage + 20);
				addIndex = 3;
				break;
			case 3:
				GameObject.Find ("PlayerRed").GetComponent<MoveActorComponent> ().ActorData.SetLife (100);
				GetComponent<AttackActorComponent> ().AttackData.AddDamage (-GetComponent<AttackActorComponent> ().AttackData.Damage + 34);
				addIndex = 0;
				break;
			}
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			state = 3;
			//transform.LookAt (new Vector3 (targetPos.x, transform.position.y, targetPos.z));
		}	
		if (Input.GetKeyDown (KeyCode.K)) {
			state = 4;
			//transform.LookAt (new Vector3 (targetPos.x, transform.position.y, targetPos.z));
		}	
		if (Input.GetMouseButtonDown (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				//print (hit.transform.tag);
				if (hit.transform.tag == "Player") {
					state = 1;
					targetPos = hit.transform.position;
				} else if (hit.transform.tag == "Ground") {
					state = 0;
					targetPos = hit.point;
				}
				//transform.LookAt (new Vector3 (targetPos.x, transform.position.y, targetPos.z));
			}	

		}
		switch (state) {
		case 0:
			if (Vector3.Distance (transform.position, targetPos) > 0.5f)
				GetComponent<actorTest> ().TestMove (targetPos);
			state = -9;
			break;
		case 1:
			if (GetComponent<actorTest> ().enemyInRange ()) {
				GetComponent<actorTest> ().SimpleAttack ();
			} else
				state = -2;
			break;
		case -2:
			if (!GetComponent<actorTest> ().enemyInRange ())
				GetComponent<actorTest> ().MoveToEnemy ();
			else
				state = -1;
			break;
		case 3:
			if (GetComponent<actorTest> ().TestHeal ()) {
				GetComponent<actorTest> ().TestMove (transform.position + transform.forward * .1f);
				locked = true;
				state = -3;
			}
			break;
		case 4:
			if (GetComponent<actorTest> ().TestShield ()) {
				GetComponent<actorTest> ().TestMove (transform.position + transform.forward * .1f);
				locked = true;
				state = -4;
			}
			break;
		}
	}
	public void Lock()
	{
		print ("lock");
		locked = true;
	}
	void FuzzyInputControl()
	{
		state = fuzzy.MakeDisicion ();
		if (state == 3)
			state = 1;
		switch (state) {
		case 0:
			if (GetComponent<actorTest> ().enemyInRange ())
				GetComponent<actorTest> ().SimpleAttack ();
			else
				GetComponent<actorTest> ().MoveToEnemy ();
			break;
		case 1:
			print ("heal");
			if (!GetComponent<SkillComponent> ().healCoolDown) {
				locked = true;
				GetComponent<actorTest> ().TestMove (transform.position + transform.forward * .001f);
				GetComponent<actorTest> ().TestHeal ();
				state = -1;
			} else
				GetComponent<actorTest> ().FleeToHome ();
			break;
		case -1:
			if(!locked)
			GetComponent<actorTest> ().FleeToHome ();
			break;
		case 2:
			if (!GetComponent<SkillComponent> ().ShieldCoolDown) {
				locked = true;
				GetComponent<actorTest> ().TestMove (transform.position + transform.forward * .001f);
				GetComponent<actorTest> ().TestShield ();
				state = -1;
			} else {
				if(!locked)
				GetComponent<actorTest> ().FleeToHome ();
			}
			break;
		}
	}
}
