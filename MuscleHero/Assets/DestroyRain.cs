using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRain : MonoBehaviour 
{
	void Update () 
	{
		if(transform.position.y < 0 || transform.position.y > 20)
			Destroy(gameObject);
	}
}
