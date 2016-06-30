using UnityEngine;
using System.Collections;

public class HUDPlayer : MonoBehaviour {
	public PlayerInfo playerInfo;
	public FuzzyBoard fuzzy;
	public SkillManager skill;
	// Use this for initialization
	void Awake () {
		if (transform.FindChild ("PlayerInfo") != null) {
			playerInfo = transform.FindChild ("PlayerInfo").GetComponent<PlayerInfo> ();
			//playerInfo.BindPlayer (GameObject.Find ("Player" + transform.name));
		}
		if (transform.FindChild ("FuzzyBoard") != null) {
			fuzzy = transform.FindChild ("FuzzyBoard").GetComponent<FuzzyBoard> ();
			//fuzzy.BindData (GameObject.Find ("Player" + transform.name).GetComponent<TEST_SAMPLE> ());
		}
		if (transform.FindChild ("Skill") != null) {
			skill = transform.FindChild ("Skill").GetComponent<SkillManager> ();
			//skill.BindPlayer (GameObject.Find ("Player" + transform.name));
		}

	}
	public void BindPlayer(GameObject player)
	{
		if(playerInfo!=null)
			playerInfo.BindPlayer (player);
		if(fuzzy!=null)
			fuzzy.BindData (player.GetComponent<TEST_SAMPLE>());
		if (skill != null)
			skill.BindPlayer (player);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
