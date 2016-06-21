using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	public int direction;
	public float speed=0.2f;
	public bool mobile;
	/// <summary>
	/// Moves the camera.according to clock,example:9 for left,12 for up,10 for left and up
	/// </summary>
	/// <param name="direction">Move Direction.</param>
	/// <param name="speed">Move Speed.</param>
	public void MoveCamera(int direction, float speed)
	{
		switch(direction)
		{
		case 9:
			transform.Translate (-1 * speed, 0, 0,Space.World);
			break;
		case 10:
			transform.Translate (-0.72f * speed, 0, 0.72f*speed,Space.World);
			break;
		case 12:
			transform.Translate (0, 0, 1*speed,Space.World);
			break;
		case 1:
			transform.Translate (0.72f * speed, 0, 0.72f * speed,Space.World);
			break;
		case 3:
			transform.Translate (1 * speed, 0, 0,Space.World);
			break;
		case 4:
			transform.Translate (0.72f * speed, 0, -0.72f,Space.World);
			break;
		case 6:
			transform.Translate (0, 0, -1*speed,Space.World);
			break;
		case 7:
			transform.Translate (-0.72f * speed, 0, -0.72f*speed,Space.World);
			break;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
