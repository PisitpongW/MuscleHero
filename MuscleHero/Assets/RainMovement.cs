using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMovement : MonoBehaviour 
{
	private GameController gameController;
	public Rigidbody rainObject;
	private float timePass;
	Vector3 rainSpeed;
	void Start () 
	{
		GameObject gameControllerObject = GameObject.Find("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
		timePass = gameController.time;
	}
	void Update () 
	{
		if(timePass > 45.0f && timePass < 73.0f)
		{
			rainSpeed.x = 1.0f;
			rainSpeed.y = -5.0f;
		}
		else if (timePass > 73.0f && timePass < 91.0f)
		{
			rainSpeed.x = 1.0f;
			rainSpeed.y = 4.0f;
		}
		else if(timePass > 105.0f && timePass < 136.0f)
		{
			rainSpeed.x = 1.0f;
			rainSpeed.y = -5.0f;
		}
		else if(timePass > 136.0f && timePass < 153.0f)
		{
			rainSpeed.x = 1.0f;
			rainSpeed.y = 7.0f;
		}
		else if(timePass > 153.0f && timePass < 172.0f)
		{
			rainSpeed.x = 0f;
			rainSpeed.y = -10.0f;
		}
		else if(timePass > 172.0f && timePass < 188.0f)
		{
			rainSpeed.x = 0f;
			rainSpeed.y = 12.0f;
		}
		else
		{
			rainSpeed.x = 0f;
			rainSpeed.y = 0f;
		}
		rainSpeed.z = 0f;
		rainObject.velocity = rainSpeed;
	}
}
