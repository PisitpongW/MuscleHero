using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour 
{
	public Rigidbody atv1, atv2, atv3;
	private float upPosition = 3.48f, downPosition = 0.59f;
	private bool active;
	private bool press;
	private Vector3 prePos1, prePos2, prePos3;
	private Vector3 con, conv, conr, cona;
	private GameObject note;
	public GameObject waterEffect;
	void Start () 
	{
		prePos1 = atv1.transform.position;
		prePos2 = atv2.transform.position;
		prePos3 = atv3.transform.position;
		active = false;
		press = false;
	}
	void Update () 
	{
		if(Input.GetKey("a")||Input.GetKey("left"))
		{
			press = true;
			StartCoroutine(PressAcivator1());
		}
		if(Input.GetKey("s")||Input.GetKey("down"))
		{
			press = true;
			StartCoroutine(PressAcivator2());
		}
		if(Input.GetKey("d")||Input.GetKey("right"))
		{
			press = true;
			StartCoroutine(PressAcivator3());
		}
		if(press == false)
		{
			atv1.transform.position = prePos1;
			atv2.transform.position = prePos2;
			atv3.transform.position = prePos3;
		}

		conv = atv1.velocity;
		conv.x = 0f; conv.y = 0f; conv.z = 0f;
		atv1.velocity = conv;
		atv2.velocity = conv;
		atv3.velocity = conv;

		cona = atv1.angularVelocity;
		cona.x = 0f; cona.y = 0f; cona.z = 0f;
		atv1.angularVelocity = cona;
		atv2.angularVelocity = cona;
		atv3.angularVelocity = cona;

		conr = atv1.transform.eulerAngles;
		conr.x = 0f; conr.y = 0f; conr.z = 0f;
		atv1.transform.eulerAngles = conr;
		atv2.transform.eulerAngles = conr;
		atv3.transform.eulerAngles = conr;

		press = false;
	}
	public IEnumerator PressAcivator1()
	{
		if(press == true)
		{
			con = prePos1;
			Instantiate(waterEffect, atv1.transform.position, atv1.transform.rotation);
			while(con.y < upPosition)
			{
				con.y = con.y + 0.3f;
				yield return new WaitForSeconds(0.001f);
				atv1.transform.position = con;
				conr = atv1.transform.eulerAngles;
				conr.x = 0f; conr.y = 0f; conr.z = 0f;
				atv1.transform.eulerAngles = conr;
			}
			press = false;
		}
	}
	public IEnumerator PressAcivator2()
	{
		if(press == true)
		{
			con = prePos2;
			Instantiate(waterEffect, atv2.transform.position, atv2.transform.rotation);
			while(con.y < upPosition)
			{
				con.y = con.y + 0.3f;
				yield return new WaitForSeconds(0.001f);
				atv2.transform.position = con;
				conr = atv2.transform.eulerAngles;
				conr.x = 0f; conr.y = 0f; conr.z = 0f;
				atv2.transform.eulerAngles = conr;
			}
			press = false;
		}
	}
	public IEnumerator PressAcivator3()
	{
		if(press == true)
		{
			con = prePos3;
			Instantiate(waterEffect, atv3.transform.position, atv3.transform.rotation);
			while(con.y < upPosition)
			{
				con.y = con.y + 0.3f;
				yield return new WaitForSeconds(0.001f);
				atv3.transform.position = con;
				conr = atv3.transform.eulerAngles;
				conr.x = 0f; conr.y = 0f; conr.z = 0f;
				atv3.transform.eulerAngles = conr;
			}
			press = false;
		}
	}
	void OnTriggerEnter(Collider col)
	{
		active = true;
	}
	void OnTriggerExit(Collider col)
	{
		active = false;
	}
}
