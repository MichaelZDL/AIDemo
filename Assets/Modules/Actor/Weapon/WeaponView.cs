using UnityEngine;
using System.Collections;

public class WeaponView : MonoBehaviour {
	public ObjPool ammoPack;
	// Use this for initialization
	void Start () {
	}

	public void Fire(Transform target,float damage)
	{
		ammo _ammo = ammoPack.GetObj ().GetComponent<ammo> ();
		_ammo.target=target;
		_ammo.damage = damage;
	}
}
