using UnityEngine;
using System.Collections;


public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
	
	void OnLevelWasLoaded(int level){
		//audio.whatever also works
		//audio.clip=levelMusicChangeArray[Application.loadedLevel];
		//audio.Play();
		AudioClip thisLevelsMusic = levelMusicChangeArray[Application.loadedLevel];
		
		//check to make sure thisLevelsMusic has a clip, and if it does, set that playing
		//also check if next level clip is the same as the current clip - only start clip playing if it's different
		//this way the music will continue betweek levels without restarting when the song doesn't change
		if (thisLevelsMusic && thisLevelsMusic != audioSource.clip){
			audioSource.clip=thisLevelsMusic;
			audioSource.loop=true;
			audioSource.Play ();		
		}
	}

	// Use this for initialization
	void Start () {
		//AudioSource.PlayClipAtPoint(levelMusicChangeArray[Application.loadedLevel],transform.position);
		//audio.clip=levelMusicChangeArray[Application.loadedLevel];
		//audio.Play();
		audioSource = GetComponent<AudioSource>();
	}

	public void ChangeVolume (float volume)
	{
		audioSource.volume=volume;
	}
}
