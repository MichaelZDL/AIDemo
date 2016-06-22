using UnityEngine;
using System.Collections;

public class SkillComponent : MonoBehaviour {
	public bool healCoolDown;
	public bool shieldCooldown;
	public void Heal()
	{
		if (healCoolDown == false) {
			healCoolDown = true;
			GetComponent<HitComponent> ().Heal (100);
			Invoke ("HealCoolDown", 15f);
		}
	}
	public void Shield()
	{
		if (shieldCooldown == false) {
			shieldCooldown = true;
			GetComponent<MoveActorComponent> ().ActorData.AddDefense (100);
			Invoke ("ShieldCooldown", 5f);
		}
	}
	void HealCooldown()
	{
		healCoolDown = false;
	}
	void ShieldCooldown()
	{
		shieldCooldown = false;
		GetComponent<MoveActorComponent> ().ActorData.AddDefense (-100);
	}

}

