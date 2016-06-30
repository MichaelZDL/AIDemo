using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class InitData : Utils.SingletonMono<InitData> {
	void Awake()
	{
		print ("data awake");
		playerData = new List<PlayerInitData> ();
		PlayerPos = new List<Vector3> ();
		PlayerPos.Add (new Vector3 (0, 1, 17));
		PlayerPos.Add (new Vector3 (0, 0, -10));
		playerCount = 2;
	}
	public int playerCount;
	public List<PlayerInitData> playerData;
	public List<Vector3> PlayerPos;
}
[Serializable]
public class PlayerInitData
{
	public Color color;
	public float life;
	public float range;
	public float speed;
	public float damage;
	public int controlMode;
}