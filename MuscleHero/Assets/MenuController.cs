using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuController : MonoBehaviour 
{
	public CanvasGroup settingCanvas;
	public Dropdown musicDropdown;
	public int musicIndex;
	public static string musicName;
	public Dropdown levelDropdown;
	public int levelIndex;
	public static string levelName;

	public Button startButton;
	public Button exitButton;
	public static bool isContinue;
	 
	void Start () 
	{
		print("MenuController start");

		startButton.onClick.AddListener(() => StartOnClick());
		exitButton.onClick.AddListener(() => ExitOnClick());

		musicDropdown.onValueChanged.AddListener(delegate {
			musicDropdownValueChanged(musicDropdown);
		});
		levelDropdown.onValueChanged.AddListener(delegate {
			levelDropdownValueChanged(levelDropdown);
		});
		
	}
	void Update () 
	{

	}
	void StartOnClick()
	{
		print("Start button is clicked");
		
		// When the system have more songs, 
		// change to use array to approach each scene
		if(musicIndex == 1)
			SceneManager.LoadScene("LavaScene");
		else if(musicIndex == 2)
			SceneManager.LoadScene("TinyForestScene");
	}
	void musicDropdownValueChanged(Dropdown musicTarget)
	{
		musicIndex = musicTarget.value;
		print("Music Index : " + musicIndex + ">>" + musicTarget.options[musicIndex].text);
	}
	void levelDropdownValueChanged(Dropdown levelTarget)
	{
		levelIndex = levelTarget.value;
		print("Level Index : " + levelIndex + ">>" + levelTarget.options[levelIndex].text);
	}
	void ExitOnClick()
	{
		print("Quit button is clicked");
		Application.Quit();
	}
}
