using UnityEngine;
using System.Collections;
using System;
public class ViewComponent : MonoBehaviour {
	MoveActorComponent m;
	AttackActorComponent atk;
	SkillComponent skill;
	public GameObject healObj;
	public GameObject shieldObj;
	void Start()
	{
		m = GetComponent<MoveActorComponent> ();
		atk = GetComponent<AttackActorComponent> ();
		skill = GetComponent<SkillComponent> ();
		m.moveStartEvent += DoMove;
		m.moveEndEvent += DoEndMove;
		atk.AttackEvent += DoAttack;
		skill.HealEvent += DoHeal;
		skill.ShieldEvent += DoShield;
	}
	void LoadModel()
	{
	}
	void DoMove(object sender,EventArgs e)
	{
		//print ("do animation");
		GetComponent<Animator> ().SetBool ("Run", true);
	}
	void DoEndMove(object sender,EventArgs e)
	{
		//print ("end animation");
		GetComponent<Animator> ().SetBool ("Run", false);
	}
	void DoIdle()
	{
		
	}
	void DoAttack(Vector3 direction)
	{
		GetComponent<Animator> ().SetBool ("MeleeAttack01", true);
		Invoke ("endAttack", 0.5f);
	}
	void endAttack()
	{
		GetComponent<Animator> ().SetBool ("MeleeAttack01", false);
	}
	void DoDie()
	{
	}
	void DoHurt()
	{
	}
	void DoDefense()
	{
	}
	void DoHeal(object sender,EventArgs e)
	{
		GetComponent<Animator> ().SetBool ("SpellCast02", true);
		Invoke ("endHeal", 1.5f);
	}
	public void HealParticle()
	{
		GameObject g=(GameObject)Instantiate (healObj, transform.position+transform.up*2, transform.rotation);
		g.transform.SetParent (transform);
	}
	void endHeal()
	{
		GetComponent<Animator> ().SetBool ("SpellCast02", false);
	}
	void DoShield(object sender,EventArgs e)
	{
		GetComponent<Animator> ().SetBool ("SpellCast01", true);
		Invoke ("endShield", 1.5f);
	}
	public void ShieldParticle()
	{
		GameObject g=(GameObject)Instantiate (shieldObj, transform.position+Vector3.up, transform.rotation);
		g.transform.SetParent (transform);
	}
	void endShield()
	{
		GetComponent<Animator> ().SetBool ("SpellCast01", false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
