using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;

public class CreateCSV : MonoBehaviour 
{
	private GameController gameController;
	private static string csvPath;
	private List<string[]> csvData = new List<string[]>();
	public float timeStart;
	public string timeText;
	public long countData;
	//private GameController gameController;
	void Start () 
	{
		print("CreateCSV start");
		/*
		GameObject gameControllerObject = GameObject.Find("GameController");
		if(gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController>();
		else
			Debug.Log("Cannot find 'GameController' script");
		*/

		// Create first line as header of each collumn
		string[] tempData = new string[12];
		tempData[0] = "Note Number";
		tempData[1] = "Time Sec.";
		tempData[2] = "Time Min.";
		tempData[3] = "Note";
		tempData[4] = "Activator 1";
		tempData[5] = "% Accurate 1";
		tempData[6] = "Activator 2";
		tempData[7] = "% Accurate 2";
		tempData[8] = "Activator 3";
		tempData[9] = "% Accurate 3";
		tempData[10] = "Total Score";
		tempData[11] = "Status";
		csvData.Add(tempData);

		countData = 0;
		timeStart = Time.time;
	}
	public void AddData(int note,int[] atvScore, int[] atvTotal, int score, string status)
	{
		timeText = Mathf.Floor((Time.time - timeStart) / 60).ToString("00") + " : "
        + Mathf.Floor((Time.time - timeStart) % 60).ToString("00");

		countData++;

		string[] tempData = new string[12];
		tempData[0] = countData.ToString();
		tempData[1] = (Time.time-timeStart).ToString();
		tempData[2] = timeText;
		tempData[3] = note.ToString();
		tempData[4] = atvScore[0].ToString();
		tempData[5] = ((float)atvScore[0]/(float)atvTotal[0]*100.0f).ToString();
		tempData[6] = atvScore[1].ToString();
		tempData[7] = ((float)atvScore[1]/(float)atvTotal[1]*100.0f).ToString();
		tempData[8] = atvScore[2].ToString();
		tempData[9] = ((float)atvScore[2]/(float)atvTotal[2]*100.0f).ToString();
		tempData[10] = score.ToString();
		tempData[11] = status;
		//print(gameController.atvScore[0]+" "+gameController.atvScore[1]+" "+gameController.atvScore[2]);
		csvData.Add(tempData);
	}
	public void SaveData(string saveName)
	{
		print(saveName);
		string[][] csvTable = new string[csvData.Count][];

        for(int i = 0; i < csvTable.Length; i++){
            csvTable[i] = csvData[i];
        }

        int length = csvTable.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, csvTable[index]));
        
        
        string filePath = @"D:\Work\BCI\iCreate_2019\MuscleHero\MuscleHero\log\"+saveName+".csv";

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
		Debug.Log("Saving completed");
	}
}
