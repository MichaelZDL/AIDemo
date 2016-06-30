using UnityEngine;
using System.Collections;

public class ActorData{
	Vector3 position;
	Vector3 rotation;
	Vector3 scale;
	float maxLife;
	float life;
	float moveSpeedInsp;//展示的速度
	float moveSpeedReal;//真实速度
	float defense=0;
	float cutDamage=0;
	public void BindPlayer(GameObject player)
	{
		player.GetComponent<HitComponent> ().HitEvent += CutLife;
		player.GetComponent<HitComponent> ().HealEvent += GainLife;
	}
	public Vector3 WorldPosition
	{
		//这个咋同步？
		get{
			return position;
		}
	}
	public Vector3 WorldRotation
	{
		get{
			return rotation;
		}
	}
	public float Life
	{
		get{
			return life;
		}
	}
	public float MaxLife
	{
		get{
			return maxLife;
		}
	}
	public float CutDamage
	{
		get{
			return 1-cutDamage;
		}
	}
	/// <summary>
	/// 面板数值.
	/// </summary>
	/// <value>The move speed.</value>
	public float MoveSpeed
	{
		get{
			return moveSpeedInsp;
		}
	}
	/// <summary>
	/// 真实的移动速度，给NavMesh用
	/// </summary>
	/// <value>The speed.</value>
	public float Speed
	{
		get {
			return moveSpeedReal;
		}
	}
	public float Defense
	{
		get {
			return defense;
		}
	}
	public void SetPosition(Vector3 value)
	{
		position = value;
	}
	public void SetRotation(Vector3 value)
	{
		
	}
	public void AddSpeed(float value)
	{
		float mid = 415;
		float high = 490;
		moveSpeedInsp += value;
		if (moveSpeedInsp < 415 && moveSpeedInsp > 325)
			moveSpeedReal = moveSpeedInsp / 325;
		else if (moveSpeedInsp < 490)
			moveSpeedReal = (415 + (moveSpeedInsp - 415) * 0.8f) / 325;
		else if (moveSpeedInsp > 490)
			moveSpeedReal = (490 + (moveSpeedInsp - 490) * 0.5f) / 325;
	}
	public void AddDefense(float value)
	{
		defense += value;
		//减伤率
		cutDamage = defense / (100 + defense);
	}
	public void CutLife(float value)
	{
		life= Mathf.Max (0, life - value * (1-cutDamage));
	}
	public void GainLife(float value)
	{
		life = Mathf.Min (maxLife, life + value);
	}
	public void SetLife(float value)
	{
		life = value;
	}
	public void SetMax(float value)
	{
		maxLife = value;
		life = value;
	}
}
