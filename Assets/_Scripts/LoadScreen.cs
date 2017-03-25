using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {

	private MusicManager musicManager;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		//when this starts, check if first run of game, and set defaults if it is
		PlayerPrefsManager.CheckKeys();

		//now that we've definitely got a volume set, get the volume, set our volume to it, and then play the clip
		float theVolume = PlayerPrefsManager.GetMasterVolume();
		
		//set the volume of the game music
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		musicManager.ChangeVolume(theVolume);
		
		//set the colume of the audiosource that plays the sound effect, then play it
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = theVolume;
		audioSource.Play ();
		
		//load the next screen in 3 seconds
		Invoke ("LoadMenu",3f);
	}
	
	void LoadMenu(){
		LevelManager lm = GameObject.FindObjectOfType<LevelManager>();
		lm.LoadNextLevel ();
	}

}
