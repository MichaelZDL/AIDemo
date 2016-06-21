using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjPool : MonoBehaviour {
	public List<GameObject> Objpool;
	public int size;
	public GameObject poolObj;
	public bool itemDestroyByTime;
	int index;
	public void Start()
	{
		for (int i = 0; i < size; i++) {
			PushGameObject ((GameObject)Instantiate (poolObj, Vector3.zero, Quaternion.Euler(0,0,0)));
		}
	}
	public GameObject GetObj()
	{
		GameObject  rt= Objpool[0];
		Objpool.Remove (rt);
		rt.SetActive (true);
		rt.transform.SetParent (null);
		return rt;
	}
	public void PushGameObject(GameObject obj)
	{
		if (obj.GetComponent<poolItem> () == null)
			obj.AddComponent<poolItem> ();
		if(itemDestroyByTime){
			if (obj.GetComponent<DestroyByTime> () == null)
				obj.AddComponent<DestroyByTime> ();
			obj.GetComponent<DestroyByTime> ().DestroyTime = 1.5f;
		}
		Objpool.Add (obj);
		obj.GetComponent<poolItem> ().Init(gameObject);
		obj.SetActive (false);
	}
}
