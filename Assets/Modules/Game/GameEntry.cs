using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEntry : Utils.SingletonMono<GameEntry> {
	public GameObject[] players;
	public void GameStart()
	{
		print ("GameEntry");
	}
	// Use this for initialization
	void Start () {
		players=new GameObject[InitData.Instance.playerCount];
		for (int i = 0; i < players.Length; i++) {
			GameObject tg=gameObject;
			if (i == 1) {
				tg=(GameObject)Instantiate (Resources.Load ("Actor/AliceBlue"), InitData.Instance.PlayerPos [i], Quaternion.Euler (0, 0, 0));
				tg.name = "PlayerBlue";
			}
			if (i == 0) {
				tg=(GameObject)Instantiate (Resources.Load ("Actor/AliceRed"), InitData.Instance.PlayerPos [i], Quaternion.Euler (0, 0, 0));
				tg.name = "PlayerRed";
			}
			players [i] = tg;
			tg.transform.position = InitData.Instance.PlayerPos [i];
			tg.transform.LookAt (Vector3.zero);
			CopyData (tg, InitData.Instance.playerData [i]);
		}
		//temp
		players [0].GetComponent<actorTest> ().testTarget = players [1];
		GameObject bhome=new GameObject();
		GameObject rhome=new GameObject();
		bhome.transform.position = new Vector3 (0, 0, 18);
		rhome.transform.position = new Vector3 (0, 0, -11);
		players [0].GetComponent<DataBind> ().Home = bhome.transform;
		players [1].GetComponent<DataBind> ().Home = rhome.transform;
		players [1].GetComponent<actorTest> ().testTarget = players [0];
		//temp end
		GameObject ui=(GameObject)Instantiate(Resources.Load("UI/Prefabs/HUD"));
		//temp
		ui.transform.parent=GameObject.Find("Canvas").transform;
		ui.GetComponent<RectTransform>().anchoredPosition=new Vector2(0,0);
		ui.transform.FindChild ("Blue").GetComponent<HUDPlayer> ().BindPlayer (players [1]);
		ui.transform.FindChild ("Red").GetComponent<HUDPlayer> ().BindPlayer (players [0]);
		ui.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		GameObject.Find ("bloodBarBlue").GetComponent<BloodBar> ().Player = players [1].transform;
		GameObject.Find ("bloodBarRed").GetComponent<BloodBar> ().Player = players [0].transform;

		//temp end
		GameObject scene=(GameObject)Instantiate(Resources.Load("Scene/Scene"));
		//temp
		GameObject.Find ("BlueHome").GetComponent<HomeComponent> ().SetPlayer (players [1].transform);
		GameObject.Find ("RedHome").GetComponent<HomeComponent> ().SetPlayer (players [0].transform);
		//temp end
	}
	
	// Update is called once per frame
	void CopyData(GameObject player,PlayerInitData data)
	{
		player.GetComponent<MoveActorComponent> ().ActorData.SetMax (data.life);
		player.GetComponent<NavMeshAgent> ().speed = data.speed;
		player.GetComponent<AttackActorComponent> ().AttackData.AddDamage (data.damage);
		player.GetComponent<AttackActorComponent> ().AttackData.SetRange (data.range);
		switch (data.controlMode) {
		case 0:
			player.AddComponent<TEST_SAMPLE> ();
			break;
		}
	}
	void Update () {
	
	}
}
