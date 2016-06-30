using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using LitJson;
public class JsonRnW : MonoBehaviour {
	// Use this for initialization
	void Start () {
		/*
		JsonData data = new JsonData ();
		data ["PlayerBlue"] = new JsonData ();
		data ["PlayerBlue"]["life"]  = 100;
		data ["PlayerBlue"]["range"] = 3;
		data ["PlayerBlue"]["damage"] = 5;
		data ["PlayerBlue"]["speed"] = 2;
		data ["PlayerRed"] = new JsonData ();
		data ["PlayerRed"]["life"]  = 8888;
		data ["PlayerRed"]["range"] = 3;
		data ["PlayerRed"]["damage"] = 5;
		data ["PlayerRed"]["speed"] = 3;
		*/
		Dictionary<string,string>[] datas=new Dictionary<string,string>[2];
		Dictionary<string,string> data = new Dictionary<string,string> ();
		Dictionary<string,string> data1 = new Dictionary<string,string> ();
		datas [0] = data;
		data["life"]="123";
		data["range"]="4";
		data1["life"]="234";
		data1 ["range"] = "5";
		datas [1] = data1;
		JsonData jd=new JsonData();
		jd["player"]=JsonMapper.ToJson(datas);
		using (StreamWriter sw = new StreamWriter ("PlayerData.txt"))
			sw.Write (jd.ToJson());
	}

}
