using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class UIPlayerConfig:MonoBehaviour {
	InputField lifeField;
	InputField rangeField;
	InputField speedField;
	InputField damageField;
	Dropdown controlDrop;
	public PlayerInitData initData;
	void Start()
	{
		initData = new PlayerInitData ();
		lifeField = transform.FindChild ("life/InputField").GetComponent<InputField> ();
		rangeField = transform.FindChild ("range/InputField").GetComponent<InputField> ();
		speedField = transform.FindChild ("speed/InputField").GetComponent<InputField> ();
		damageField = transform.FindChild ("damage/InputField").GetComponent<InputField> ();
		controlDrop = transform.FindChild ("control/Dropdown").GetComponent<Dropdown> ();
		lifeField.onEndEdit.AddListener(delegate{StopInput(lifeField,out initData.life);});
		rangeField.onEndEdit.AddListener(delegate{StopInput(rangeField,out initData.range);});
		speedField.onEndEdit.AddListener(delegate{StopInput(speedField,out initData.speed);});
		damageField.onEndEdit.AddListener(delegate{StopInput(damageField,out initData.damage);});
		controlDrop.onValueChanged.AddListener(delegate{StopInput(controlDrop,out initData.controlMode);});
	}
	void StopInput(InputField _input,out float output)
	{  
		output = float.Parse(_input.text);
	}
	void StopInput(Dropdown _input,out int output)
	{  
		output = _input.value;
	}
}
