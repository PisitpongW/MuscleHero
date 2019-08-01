using System.Collections;
using UnityEngine;

public class NoteController : MonoBehaviour 
{
    public GameObject noteColor;
	public GameObject noteLeft, noteMiddle, noteRight;
	public Vector3 spawnValue;
	public float spawnWait;
	public float waitBefore;
	public float con;
	public int index;
	private bool gameOver;
	private Color col;
	void Start () 
	{
		gameOver = false;
		StartCoroutine(NoteWave());
	}

	IEnumerator NoteWave()
	{
		yield return new WaitForSeconds(waitBefore);
		while(true)
		{
			index = Random.Range(1,4);
			if(index == 1){spawnValue.x = -3.71f; noteColor = noteLeft;}
			else if(index == 2) {spawnValue.x = -0.275f; noteColor = noteMiddle;}
			else if(index == 3) {spawnValue.x = 3.16f; noteColor = noteRight;}
			Vector3 spawnPosition = spawnValue;
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(noteColor, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(spawnWait);
			if(gameOver) break;
		}
		print("End note spawning");
	}
	public void GameOver()
	{
		gameOver = true;
	}
}
