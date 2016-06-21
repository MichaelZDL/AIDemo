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
	// Use this for initialization
	void Start () {
		bloodPercentage = 1;
		if (bloodBar == null) {
			bloodBar = GetComponent<Image> ();
			bloodBar.GetComponent<Image> ().material = Instantiate (bloodBar.GetComponent<Image> ().material);
			bloodMat = bloodBar.GetComponent<Image>().material;
		}
	}
	void Update()
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
