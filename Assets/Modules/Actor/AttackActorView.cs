using UnityEngine;
using System.Collections;

public class AttackActorView : MonoBehaviour {
	public GameObject Weapon;
	public GameObject aimObj;
	public void Attack(Transform target)
	{
		aimObj.transform.LookAt (target.position);
		Weapon.GetComponent<WeaponView> ().Fire(target,GetComponent<AttackActorComponent>().AttackData.Damage);
	}
}
