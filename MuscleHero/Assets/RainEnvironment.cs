using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEnvironment : MonoBehaviour 
{
	public Rigidbody rain;
	private Vector3 spawnPosition;
	private float con, timeStart, spawnWait;
	private int inx, iny, inz;
	private int check;
	private bool isContinue;
	void Start () 
	{
		timeStart = Time.time;
		spawnWait = 0.8f;
		iny = 19;

		isContinue = false;
		check = 0;
	}
	void Update () 
	{
		if(check == 0 && Time.time - timeStart > 45.0f)
		{
			isContinue = true;
			StartCoroutine(RainWave1());
			StartCoroutine(RainWave2());
			StartCoroutine(RainWave3());
			StartCoroutine(RainWave4());
			check = 1;
		}
		else if(check == 1 && Time.time - timeStart > 73.0f && Time.time - timeStart < 91.0f)
		{
			iny = 3;
			check = 2;
		}
		else if(Time.time - timeStart > 91.0f && Time.time - timeStart < 105.0f)
			isContinue = false;
		else if(check == 2 && Time.time - timeStart > 105.0f && Time.time - timeStart < 136.0f)
		{
			isContinue = true;
			StartCoroutine(RainWave1());
			StartCoroutine(RainWave2());
			StartCoroutine(RainWave3());
			StartCoroutine(RainWave4());
			iny = 19;
			check = 3;
		}
		else if(check == 3 && Time.time - timeStart > 136.0f && Time.time - timeStart < 153.0f)
		{
			iny = 3;
			spawnWait = 0.7f;
			check = 4;
		}
		else if(check == 4 && Time.time - timeStart > 153.0f && Time.time - timeStart < 172.0f)
		{
			iny = 19;
			spawnWait = 0.3f;
			check = 5;
		}
		else if(check == 5 && Time.time - timeStart > 172.0f && Time.time - timeStart < 188.0f)
		{
			iny = 3;
			spawnWait = 0.3f;
			check = 6;
		}
	}
	IEnumerator RainWave1()
	{
		while(isContinue)
		{
			inx = Random.Range(-15, 0);
			inz = Random.Range(7, 28);
			spawnPosition = new Vector3(inx, iny, inz);
			Quaternion spawnRotaion = Quaternion.identity;
			Instantiate(rain, spawnPosition, spawnRotaion);
			yield return new WaitForSeconds(spawnWait);
		}
	}
	IEnumerator RainWave2()
	{
		while(isContinue)
		{
			inx = Random.Range(0, 16);
			inz = Random.Range(7, 28);
			spawnPosition = new Vector3(inx, iny, inz);
			Quaternion spawnRotaion = Quaternion.identity;
			Instantiate(rain, spawnPosition, spawnRotaion);
			yield return new WaitForSeconds(spawnWait);
		}
	}
	IEnumerator RainWave3()
	{
		while(isContinue)
		{
			inx = Random.Range(-15, 0);
			inz = Random.Range(28, 49);
			spawnPosition = new Vector3(inx, iny, inz);
			Quaternion spawnRotaion = Quaternion.identity;
			Instantiate(rain, spawnPosition, spawnRotaion);
			yield return new WaitForSeconds(spawnWait);
		}
	}
	IEnumerator RainWave4()
	{
		while(isContinue)
		{
			inx = Random.Range(0, 16);
			inz = Random.Range(28, 46);
			spawnPosition = new Vector3(inx, iny, inz);
			Quaternion spawnRotaion = Quaternion.identity;
			Instantiate(rain, spawnPosition, spawnRotaion);
			yield return new WaitForSeconds(spawnWait);
		}
	}
}
