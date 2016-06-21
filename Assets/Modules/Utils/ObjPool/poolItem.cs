using UnityEngine;
using System.Collections;

public class poolItem : MonoBehaviour {
	public GameObject objPool;
	public void Init(GameObject _objPool)
	{
		transform.parent = _objPool.transform;
		objPool = _objPool;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.Euler (0, 0, 0);
	}
	// Use this for initialization
	void Start () {
		
	}
	void OnReuse()
	{
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
