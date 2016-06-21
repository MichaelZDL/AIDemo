using UnityEngine;
using System.Collections;

public class AttackActorData{
	float damage;
	float attackRate=1;
	float attackRange;
	public float Damage
	{
		get{
			return damage;
		}
	}
	public float AttackRate
	{
		get {
			return attackRate;
		}
	}
	public float AttackRange
	{
		get{
			return attackRange;
		}
	}
	public void AddDamage(float value)
	{
		damage += value;
	}
	public void SetRange(float Range)
	{
		attackRange = Range;
	}
	/// <summary>
	/// Muitis the attack rate.只传百分比
	/// </summary>
	/// <param name="value">Value.</param>
	public void MuitiAttackRate(float value)
	{
		attackRate += attackRate * value;
	}
}
