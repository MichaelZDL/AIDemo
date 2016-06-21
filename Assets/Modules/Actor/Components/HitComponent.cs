using UnityEngine;
using System.Collections;

public class HitComponent : MonoBehaviour {
	//public GameObject bloodBar;
	public HitView hitView;
	ActorData actorData;
	// Use this for initialization
	void Start () {
		if(GetComponent<HitView>()==null)
		hitView = GetComponent<HitView> ();
		actorData = GetComponent<MoveActorComponent> ().ActorData;
		//bloodBar.GetComponent<BloodBar> ().SetMax (actorData.MaxLife);
	}
	public void Heal(float value)
	{
		//bloodBar.GetComponent<BloodBar>().AddBlood (value);
		actorData.GainLife (value);
	}
	public void Hurt(float value)
	{
		//bloodBar.GetComponent<BloodBar>().AddBlood (-value*actorData.CutDamage);
		actorData.CutLife (value);
		hitView.Hit ();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
