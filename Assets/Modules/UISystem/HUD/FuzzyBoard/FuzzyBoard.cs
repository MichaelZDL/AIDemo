using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FuzzyBoard : MonoBehaviour {
	Text Desicion;
	Text Condition1;
	Text Condition2;
	TEST_SAMPLE fuzzy;
	public string condition1Show;
	public string condition2Show;
	void Start () {
	
	}
	public void BindData(TEST_SAMPLE t)
	{
		fuzzy = t;
		Desicion = transform.FindChild ("Desicion").GetComponent<Text> ();
		Desicion.text = "AI决策面板";
		Condition1 = transform.FindChild ("condition1").GetComponent<Text> ();
		Condition2 = transform.FindChild ("condition2").GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () {
		if (fuzzy != null) {
			//Desicion.text = "Desicion:" + fuzzy.Desicion.ToString ();
			Condition1.text = condition1Show + fuzzy.Condition1.ToString ();
			Condition2.text = condition2Show + fuzzy.Condition2.ToString ();
		}
	}
}
