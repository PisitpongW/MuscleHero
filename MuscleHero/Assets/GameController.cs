using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	private NoteController noteController;
	private AudioController audioController;
	private CreateCSV createCSV;
	public CanvasGroup scoreCanvas;
	public Text scoreText, timeText, songText;
	public int score;
	public int[] atvScore = new int[3];
	public int[] atvTotal = new int[3];
	public float time,timeStart,limitTime;
	public CanvasGroup endCanvas;
	public Text endSongText, endScoreText, saveNameText;
	public Button mainmenuButton, saveButton;
	public float level;
	private bool isContinue;
	public string lavaName, tinyforestName, sceneName; // Change to array
	public string lavaMusic, tinyforestMusic, sceneMusic; // Change to array
	void Start () 
	{
		// For more scene in the future, please change to array
		lavaName = "LavaScene"; lavaMusic = "Kill This Love - Black Pink";
		tinyforestName = "TinyForestScene"; tinyforestMusic = "??? - ???";
		Scene scene = SceneManager.GetActiveScene();

		GameObject noteControllerObject = GameObject.Find("NoteController");
		noteController = noteControllerObject.GetComponent<NoteController>();

		GameObject audioControllerObject = GameObject.Find("AudioController");
		audioController = audioControllerObject.GetComponent<AudioController>();

		GameObject createCSVobject = GameObject.Find("CreateCSV");
		createCSV = createCSVobject.GetComponent<CreateCSV>();
		
		if(scene.name == lavaName)
		{
			print("Start 'LavaScene'");
			sceneName = lavaName;
			sceneMusic = lavaMusic;
			songText.text = lavaMusic;
			limitTime = 182f;
		}
		else if(scene.name == tinyforestName)
		{
			print("Start 'TinyForestScene'");
			sceneName = tinyforestName;
			sceneMusic = tinyforestMusic;
			songText.text = tinyforestMusic;
			limitTime = 60f;
		}
		
		mainmenuButton.onClick.AddListener(() => MainMenuOnClick());
		saveButton.onClick.AddListener(() => SaveOnClick());
		endCanvas.alpha = 0;
		endCanvas.interactable = false;
		endCanvas.blocksRaycasts = false;

		score = 0;
		timeStart = Time.time;
		isContinue = true;

		atvScore[0] = 0; atvScore[1] = 0; atvScore[2] = 0;
		atvTotal[0] = 0; atvTotal[1] = 0; atvTotal[2] = 0;
	}
	void Update () 
	{
		time = Time.time - timeStart;
		//print(time);
        timeText.text = Mathf.Floor((Time.time-timeStart) / 60).ToString("00") + " : "
        + Mathf.Floor((Time.time - timeStart) % 60).ToString("00");
		
		if(time > limitTime)
			noteController.isGameOver = true;
		if(time > limitTime + 7.0f)
		{
			print("End of the song");

			endCanvas.alpha = 1;
			endCanvas.interactable = true;
			endCanvas.blocksRaycasts = true;
			
			endSongText.text = sceneMusic;
			endScoreText.text = score.ToString();
		}

		// ESC pressing
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(endCanvas.alpha == 1)
			{
				endCanvas.alpha = 0;
				endCanvas.interactable = false;
				endCanvas.blocksRaycasts = false;
			}
			else
			{
				endCanvas.alpha = 1;
				endCanvas.interactable = true;
				endCanvas.blocksRaycasts = true;
				endSongText.text = sceneMusic;
				endScoreText.text = score.ToString();
			}
		}
	}
	public void AddScore(int scoreValue)
	{
		score += scoreValue;
		UpdateScore();
	}
	void UpdateScore()
	{
		scoreText.text = score.ToString();
	}
	void MainMenuOnClick()
	{
		print("Back to 'StartScene'");
		SceneManager.LoadScene("StartScene");
	}
	void SaveOnClick()
	{
		createCSV.SaveData((saveNameText.text).ToString());
		print("Save and Back to 'StartScene'");
		SceneManager.LoadScene("StartScene");
	}
}
