using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour 
{
	public float rotationSpeed;
	public Vector3 rotation;
	void Update () 
	{
		transform.Rotate(rotation, rotationSpeed * Time.deltaTime);
	}
}
