using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour 
{
	public Rigidbody atv1, atv2, atv3;
	private float upPosition = 3.48f, downPosition = 0.59f;
	private bool active;
	private int press;
	private Vector3 prePos1, prePos2, prePos3;
	private Vector3 con, conv, conr, cona;
	private GameObject note;
	public GameObject waterEffect;
	private ReadUDP readUDP;
	public float data1, oldData1;
	public string data1utf8;
	private CreateCSV createCSV;
	void Start () 
	{
		GameObject checkGameObject = GameObject.FindGameObjectWithTag ("UDPReceiver");
        if (checkGameObject != null)
            readUDP = checkGameObject.GetComponent <ReadUDP>();
        else
            Debug.Log("Cannot find 'ReadUDP' script");

		GameObject createCSVobject = GameObject.Find("CreateCSV");
		if(createCSVobject != null)
			createCSV = createCSVobject.GetComponent<CreateCSV>();
		else
			Debug.Log("Cannot find 'CreateCSV' script");

		prePos1 = atv1.transform.position;
		prePos2 = atv2.transform.position;
		prePos3 = atv3.transform.position;
		active = false;
		press = 0;
		oldData1 = 0f;
	}
	void Update () 
	{
		data1 = readUDP.data1float;
		if(data1 != oldData1)
		{
			atv1.transform.position = prePos1;
			atv2.transform.position = prePos2;
			atv3.transform.position = prePos3;

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
		}

		if((press==0||press==1) && (Input.GetKey("a")||data1==1f))
		{
			press = 1;
			StartCoroutine(PressAcivator1());
		}
		else if((press==0||press==2) && (Input.GetKey("s")||data1==2f))
		{
			press = 2;
			StartCoroutine(PressAcivator2());
		}
		else if((press==0||press==3) && (Input.GetKey("d")||data1==3f))
		{
			press = 3;
			StartCoroutine(PressAcivator3());
		}

		press = 0;

		atv1.transform.position = prePos1;
		atv2.transform.position = prePos2;
		atv3.transform.position = prePos3;

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
	}
	public IEnumerator PressAcivator1()
	{
		if(press == 1)
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
			press = 0;
		}
	}
	public IEnumerator PressAcivator2()
	{
		if(press == 2)
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
			press = 0;
		}
	}
	public IEnumerator PressAcivator3()
	{
		if(press == 3)
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
			press = 0;
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
