using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
public class InputWindow : UIWindow {
	PlayerInfoList infoList=new PlayerInfoList();
	public Button confirm;
	public Button load;
	// Use this for initialization
	void Start () {
		load.onClick.AddListener (
			delegate {
				using(StreamReader sr = new StreamReader("data.txt"))
				{
					string json=sr.ReadToEnd();
					print(json);
					PlayerInfoList pList=JsonUtility.FromJson<PlayerInfoList>(json);
					InitData.Instance.playerData=pList.list;
					GameEntry.Instance.GameStart();
					Hide();
				}
			}
		);
		confirm.onClick.AddListener (
			delegate {
				infoList.list.Add(transform.FindChild("PlayerBlue").GetComponent<UIPlayerConfig>().initData);
				infoList.list.Add(transform.FindChild("PlayerRed").GetComponent<UIPlayerConfig>().initData);
				transform.FindChild("PlayerBlue").GetComponent<UIPlayerConfig>().initData.color=Color.blue;
				transform.FindChild("PlayerBlue").GetComponent<UIPlayerConfig>().initData.color=Color.red;
				string json=JsonUtility.ToJson(infoList);
				using(StreamWriter sw = new StreamWriter("data.txt"))
				{
				sw.Write(json);
				PlayerInfoList pList=JsonUtility.FromJson<PlayerInfoList>(json);
				InitData.Instance.playerData=pList.list;
				GameEntry.Instance.GameStart();
				Hide();
				}
			}
		);
	}
}
[Serializable]
public class PlayerInfoList
{
	public PlayerInfoList(){list = new List<PlayerInitData> ();}
	public List<PlayerInitData> list;
}
