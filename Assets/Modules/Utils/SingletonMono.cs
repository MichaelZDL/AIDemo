using UnityEngine;
using System.Collections;
namespace Utils
{
	
	public class SingletonMono<T>  : MonoBehaviour where T:SingletonMono<T>{
		protected static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null) {
					_instance = FindObjectOfType<T> ();
				}
				if (_instance == null) {
					GameObject go = new GameObject (typeof(T).ToString()+"Singleton");
					_instance=go.AddComponent<T> ();
				}
				return _instance;
			}

		}
		public void Free()
		{
			_instance = null;

		}

	}
}
