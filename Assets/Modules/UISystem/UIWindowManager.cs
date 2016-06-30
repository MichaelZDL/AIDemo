using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UIWindowManager : Utils.SingletonMono<UIWindowManager>{
	Dictionary<int,UIWindow> UIWindows;
	Stack<int> returnQueue;
	public bool OpenWindow(int value)
	{
		if (!UIWindows.ContainsKey (value))
			return false;
		UIWindows [value].Show ();
		return true;
	}
	public bool CloseWindow(int value)
	{
		if (!UIWindows.ContainsKey (value))
			return false;
		UIWindows [value].Show ();
		return true;
	}
}
