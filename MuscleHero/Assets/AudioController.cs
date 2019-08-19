using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour 
{
	//private NoteController noteController;
	private AudioSource ad;
	private int ran;
	public AudioClip startAudio1, startAudio2, startAudio3, startAudio4;
	public AudioClip lavaAudio, tinyforestAudio; // Change to array
	public string startName, lavaName, tinyforestName; // Change to array
	void Start () 
	{
		// For more scene in the future, please change to array
		startName = "StartScene";
		lavaName = "LavaScene";
		tinyforestName = "TinyForestScene";
		Scene scene = SceneManager.GetActiveScene();

		//GameObject noteControllerObject = GameObject.Find("NoteController");
		//noteController = noteControllerObject.GetComponent<NoteController>();

		ad = gameObject.GetComponent<AudioSource>();
		if(scene.name == startName)
		{
			ran = Random.Range(1,5);
			if(ran == 1) ad.clip = startAudio1;
			else if(ran == 2) ad.clip = startAudio2;
			else if(ran == 3) ad.clip = startAudio3;
			else if(ran == 4) ad.clip = startAudio4;
			ad.Play(); print("Play 'StartAudio'");
		}
		else if(scene.name == lavaName)
		{
			ad.clip = lavaAudio;
			ad.Play(); print("Play 'KILL THIS LOVE'");
		}
		else if(scene.name == tinyforestName)
		{
			ad.clip = tinyforestAudio;
			ad.Play(); print("Play '???'");
		}
	}
}
