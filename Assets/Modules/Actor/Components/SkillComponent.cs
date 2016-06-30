using UnityEngine;
using System.Collections;
using System;
public class SkillComponent : MonoBehaviour {
	public bool healCoolDown;
	public bool shieldCooldown;
	public float healCoolDownTime;
	public float shieldCoolDownTime;
	public event EventHandler HealEvent;
	public event EventHandler ShieldEvent;
	public bool HealCoolDown
	{
		get{
			return healCoolDown;
		}
	}
	public bool ShieldCoolDown
	{
		get{
			return shieldCooldown;
		}
	}
	public bool Heal()
	{
		if (healCoolDown == true)
			return false;
		healCoolDown = true;

		HealEvent (gameObject, EventArgs.Empty);
		Invoke ("HealCooldown",healCoolDownTime);
		return true;
	}
	public void HealData()
	{
		GetComponent<HitComponent> ().Heal (35);
	}
	public bool Shield()
	{
		if (shieldCooldown == true)
			return false;
		
		shieldCooldown = true;
		ShieldEvent (gameObject, EventArgs.Empty);
		Invoke ("ShieldOff",7);
		Invoke ("ShieldCooldown",shieldCoolDownTime);
		return true;
	}
	public void ShieldData()
	{
		GetComponent<MoveActorComponent> ().ActorData.AddDefense (200);
	}
	void HealCooldown()
	{
		healCoolDown = false;
	}
	void ShieldOff()
	{
		GetComponent<MoveActorComponent> ().ActorData.AddDefense (-200);
	}
	void ShieldCooldown()
	{
		shieldCooldown = false;
	}

}

