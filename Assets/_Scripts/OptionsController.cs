using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;

	private LevelManager levelManager;
	private MusicManager musicManager;
	
	

	void Start () {
		//get the level and music managers
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		
		//on start, get the current user prefs, and set sliders to match	
		UpdateSliders ();
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		levelManager.LoadLevel("StartMenu");
	}

	public void RestoreDefaults(){
		PlayerPrefsManager.SetDefaultMasterVolume();
		PlayerPrefsManager.SetDefaultDifficulty();
		UpdateSliders();
	}

	void UpdateSliders ()
	{
		/*
		float volume;
		float difficulty;
	
		volume = PlayerPrefsManager.GetMasterVolume();
		difficulty = PlayerPrefsManager.GetDifficulty();
		
		volumeSlider.value=volume;
		difficultySlider.value=difficulty;
		*/
		
		volumeSlider.value=PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value=PlayerPrefsManager.GetDifficulty();
	}
	
	void Update(){
		musicManager.ChangeVolume(volumeSlider.value);
	}
}
