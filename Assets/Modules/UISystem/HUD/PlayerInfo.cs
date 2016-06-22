using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	GameObject player;
	string name;
	Text nameText;
	float life;
	float maxLife;
	Text lifeText;
	float damage;
	Text damageText;
	BloodBar bloodBar;
	ActorData actorData;
	AttackActorData attackData;
	void Start()
	{
		nameText=transform.FindChild ("name").GetComponent<Text> ();
		lifeText = transform.FindChild ("life").GetComponent<Text> ();
		damageText = transform.FindChild ("damage").GetComponent<Text> ();
		bloodBar = transform.FindChild ("bloodBar").GetComponent<BloodBar> ();
	}
	void Update()
	{
        if (player != null)
        {
            life = actorData.Life;
            lifeText.text = "生命:" + life.ToString() + "/" + maxLife.ToString();
            bloodBar.SetBlood(life);
        }
	}
	public void BindPlayer(GameObject value)
	{
		print ("1");
		player = value;
		name = player.name;
		nameText.text = "PlayerName:"+value;
		actorData = player.GetComponent<MoveActorComponent> ().ActorData;
		attackData = player.GetComponent<AttackActorComponent> ().AttackData;
		maxLife = actorData.MaxLife;
		damage = attackData.Damage;
		damageText.text = "攻击:"+damage.ToString ();
		bloodBar.SetMax (maxLife);
	}
}
