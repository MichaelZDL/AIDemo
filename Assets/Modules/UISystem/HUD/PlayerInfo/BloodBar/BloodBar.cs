using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodBar : MonoBehaviour {
	private float bloodPercentage;
	private float maxBlood;
	private float bloodTweenSpeed;
	private Image bloodBar;
	public  Material bloodMat;
	public float t;
	public Transform player;
	CanvasScaler cScaler;
	// Use this for initialization
	void Start () {
		cScaler = GameObject.Find ("Canvas").GetComponent<CanvasScaler> ();
		bloodPercentage = 1;
		if (bloodBar == null) {
			bloodBar = GetComponent<Image> ();
			bloodBar.GetComponent<Image> ().material = Instantiate (bloodBar.GetComponent<Image> ().material);
			bloodMat = bloodBar.GetComponent<Image>().material;
		}
	}
	public Transform Player
	{
		set {
			player = value;
			SetMax (player.GetComponent<MoveActorComponent> ().ActorData.MaxLife);
		}
	}
	void Update()
	{
		if (player != null)
		{
			Vector2 pos=RectTransformUtility.WorldToScreenPoint (Camera.main, player.transform.position);
			GetComponent<RectTransform> ().anchoredPosition = pos;
			SetBlood (player.GetComponent<MoveActorComponent> ().ActorData.Life);
			//print (pos);
		}
	}
	void WorldToScene()
	{
	}
	public void SetMax(float value)
	{
		maxBlood = value;
	}
	public void SetBlood(float value)
	{
		
		bloodPercentage = value/maxBlood;
		bloodMat.SetFloat("_BloodPercentage",bloodPercentage);
	}
	public void AddBlood(float value)
	{
		bloodPercentage = Mathf.Clamp01 (bloodPercentage + value / maxBlood);
		bloodMat.SetFloat("_BloodPercentage",bloodPercentage);
	}
}
