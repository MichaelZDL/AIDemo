using UnityEngine;
using System.Collections;
using System;
public class SkillManager : MonoBehaviour {
	CoolDown shieldCoolDown;
	CoolDown healCoolDown;
	SkillComponent playerSkill;
	// Use this for initialization
	void Start () {
		
	}
	public void BindPlayer(GameObject player)
	{
		playerSkill = player.GetComponent<SkillComponent> ();
		playerSkill.HealEvent += PullHeal;
		playerSkill.ShieldEvent += PullShield;
		healCoolDown = transform.FindChild("heal").GetComponent<CoolDown> ();
		shieldCoolDown = transform.FindChild ("shield").GetComponent<CoolDown> ();
		healCoolDown.SetCoolDownTime (playerSkill.healCoolDownTime);
		shieldCoolDown.SetCoolDownTime (playerSkill.shieldCoolDownTime);

	}
	void PullShield(object sender,EventArgs e)
	{
		shieldCoolDown.BeginCoolDown ();
	}
	void PullHeal(object sender,EventArgs e)
	{
		healCoolDown.BeginCoolDown ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
