using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnvironment : MonoBehaviour 
{
	private int con;
	private Vector3 rotation;
	private float timeStart, rotationspeed;
	private int prehook,hook;
	void Start()
	{
		con = Random.Range(30,40);
		rotationspeed = (float)con;
		rotation = new Vector3(0, Random.Range(0, 2)*2-1, 0);
		timeStart = Time.time;
		prehook = 0;
		hook = 0;
	}
	void Update () 
	{
		if(Time.time - timeStart > 16.0f)
			transform.Rotate(rotation, rotationspeed * Time.deltaTime);
		if(prehook == 0 && Time.time - timeStart > 30.5f)
		{
			rotation *= -1.0f;
			rotationspeed *= 2.0f;
			prehook = 1;
		}
		else if(prehook == 1 && Time.time - timeStart > 45.0f)
		{
			rotation *= -1.0f;
			rotationspeed *= 0.2f;
			prehook = 2;
		}
		else if(prehook == 2 && Time.time - timeStart > 59.5f)
		{
			rotation *= -1.0f;
			rotationspeed *= 10.0f;
			prehook = 3;
		}
		else if(prehook == 3 && Time.time - timeStart > 74.52f)
		{
			rotation *= -1.0f;
			rotationspeed *= 2.0f;
			prehook = 4;
		}
		else if(prehook == 4 && Time.time - timeStart > 92.3f)
		{
			rotation *= -1.0f;
			rotationspeed /= 2.0f;
			prehook = 5;
		}
		else if(prehook == 5 && Time.time - timeStart > 107.0f)
		{
			rotation *= -1.0f;
			rotationspeed /= 10.0f;
			prehook = 6;
		}
		else if(prehook == 6 && Time.time - timeStart > 121.4f)
		{
			rotation *= -1.0f;
			rotationspeed *= 10.0f;
			prehook = 7;
		}
		else if(prehook == 7 && Time.time - timeStart > 136f)
		{
			rotation *= -1.0f;
			rotationspeed *= 2.0f;
			prehook = 8;
		}
		else if(prehook == 8 && Time.time - timeStart > 154.4f)
		{
			rotation *= -1.0f;
			rotationspeed *= 0f;
			prehook = 9;
		}
		else if(prehook == 9 && Time.time - timeStart > 172.5f)
		{
			rotation *= -1.0f;
			rotationspeed = (float)con * 8.0f;
			prehook = 10;
		}
		else if(prehook == 10 && Time.time - timeStart > 179.5f)
		{
			rotation *= -1.0f;
			rotationspeed *= 1.5f;
			prehook = 11;
		}
		else if(prehook == 11 && Time.time - timeStart > 187.0f)
		{
			rotation *= -1.0f;
			rotationspeed *= 0f;
			prehook = 12;
		}
	}
}
