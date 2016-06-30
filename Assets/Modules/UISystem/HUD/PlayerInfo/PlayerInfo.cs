using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	public GameObject player;
	float defense;
	Text defenseText;
	float life;
	float maxLife;
	Text lifeText;
	float damage;
	Text damageText;
	Text Gplayer;
	//BloodBar bloodBar;
	bool dataReady;
	public ActorData actorData;
	AttackActorData attackData;
	void Awake()
	{
		defenseText=transform.FindChild ("defense").GetComponent<Text> ();
		lifeText = transform.FindChild ("life").GetComponent<Text> ();
		damageText = transform.FindChild ("damage").GetComponent<Text> ();
		//bloodBar = transform.FindChild ("bloodBar").GetComponent<BloodBar> ();
	}
	void Update()
	{
		if (dataReady)
        {
			defense = actorData.Defense;
			defenseText.text = "防御:"+defense.ToString ();
            life = actorData.Life;
            lifeText.text = "生命:" + life.ToString() + "/" + maxLife.ToString();
			damage = attackData.Damage;
			damageText.text = "攻击:"+damage.ToString ();
            //bloodBar.SetBlood(life);
			//bloodBar.GetComponent<RectTransform> ().anchoredPosition = RectTransformUtility.WorldToScreenPoint (Camera.main, player.transform.position);
        }
	}
	public void BindPlayer(GameObject value)
	{
		//print ("1");
		player = value;
		Invoke ("BindData", 0);

	}
	void BindData()
	{
		print ("Binding data");
		actorData = player.GetComponent<MoveActorComponent> ().ActorData;
		attackData = player.GetComponent<AttackActorComponent> ().AttackData;
		if (actorData == null || attackData == null)
			Invoke ("BindData", 0.2f);
		else {
			maxLife = actorData.MaxLife;
			defense = actorData.Defense;
			defenseText.text = "防御:"+defense.ToString ();
			damage = attackData.Damage;
			damageText.text = "攻击:"+damage.ToString ();
			//bloodBar.SetMax (maxLife);
			dataReady = true;
		}
	}
}
