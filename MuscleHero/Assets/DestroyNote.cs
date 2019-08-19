using UnityEngine;

public class DestroyNote : MonoBehaviour 
{
	public GameObject explosionEffect;
	public int scoreValue;
	private GameController gameController;
	private CreateCSV createCSV;
	void Start()
	{
		GameObject gameControllerObject = GameObject.Find("GameController");
		if(gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController>();
		else
			Debug.Log("Cannot find 'GameController' script");

		GameObject createCSVobject = GameObject.Find("CreateCSV");
		if(createCSVobject != null)
			createCSV = createCSVobject.GetComponent<CreateCSV>();
		else
			Debug.Log("Cannot find 'CreateCSV' script");

		scoreValue = 1;
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Activator")
		{
			int noteNumber;
			if(gameObject.name == "NoteCyan(Clone)") noteNumber = 1;
			else if(gameObject.name == "NoteOrange(Clone)") noteNumber = 2;
			else if(gameObject.name == "NoteRed(Clone)") noteNumber = 3;
			else noteNumber = 99;
			Instantiate(explosionEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			gameController.AddScore(scoreValue);
			//print("Note Lane : " + noteNumber);
			gameController.atvTotal[noteNumber-1]++;
			gameController.atvScore[noteNumber-1]++;
			//print("Pass activator update score : " + gameController.atvScore[noteNumber-1]);
			
			string noteStatus;
			noteStatus = "-";
			Debug.Log("Send a row of normal data");
			createCSV.AddData(noteNumber,gameController.atvScore, gameController.atvTotal, gameController.score, noteStatus);
		}
	}
	void Update()
	{
		if(transform.position.y < 2)
		{
			int noteNumber;
			if(gameObject.name == "NoteCyan(Clone)") noteNumber = 1;
			else if(gameObject.name == "NoteOrange(Clone)") noteNumber = 2;
			else if(gameObject.name == "NoteRed(Clone)") noteNumber = 3;
			else noteNumber = 99;
			Instantiate(explosionEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			gameController.atvTotal[noteNumber-1]++;

			string noteStatus;
			noteStatus = "miss";
			Debug.Log("Send a row of miss data");
			createCSV.AddData(noteNumber,gameController.atvScore, gameController.atvTotal, gameController.score, noteStatus);
		}
	}
}
