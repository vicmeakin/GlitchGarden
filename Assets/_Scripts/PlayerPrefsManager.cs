using UnityEngine;
using System.Collections;
using System.Collections.Generic; //added for lists

public class PlayerPrefsManager : MonoBehaviour {
	//wrapper class for unity player prefs, to ensure the same keys are used everywhere
	//this will be a static class used on all levels
	
	//set up constants for the keys we will use
	const string MASTER_VOLUME_KEY = "master_volume";
	const string LEVEL_KEY = "level_unlocked_";
	const string DIFFICULTY_KEY = "difficulty";
	
	public static void CheckKeys(){
	//ths is called from load screen, as part of setting up the game
	
	/*
		List<string> keyList = new List<string>();
		keyList.Add(MASTER_VOLUME_KEY);
		keyList.Add(DIFFICULTY_KEY);
		keyList.Add(LEVEL_KEY+"2"); //using 2 as this is the ID of the first level in the game
		
		foreach (string keyToCheck in keyList){
			if (!PlayerPrefs.HasKey (keyToCheck)){
				//need to set defaults here, but not sure how to store them!
			}
		}	*/
		
		//instead of checking each key, we're going to check master volume, and if that doesn't exist 
		//we'll set defaults for all of them
		if (!PlayerPrefs.HasKey (MASTER_VOLUME_KEY)){
			SetDefaultMasterVolume();
			SetDefaultDifficulty();
			UnlockLevel(2);	//2 is the first level. 0 and 1 are load and start screens
		} 		
	}

	public static void SetDefaultMasterVolume ()
	{
		SetMasterVolume(1f);
	}

	public static void  SetDefaultDifficulty()
	{
		SetDifficulty(2f);
	}
	
	//set up functions to set and return each of the keys
	public static void SetMasterVolume(float volume){
		if (volume >=0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range.");
		}
	}
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel(int level){
		if(level <= Application.levelCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY+level.ToString(),1);
		} else {
			Debug.LogError("Trying to unlock invalid level");
		}
	}
	
	public static bool IsLevelUnlocked(int level){
		if (PlayerPrefs.GetInt (LEVEL_KEY+level.ToString ())==1){
			return true;
		}
		return false;
	}
	
	public static void DeleteKeys(){
		PlayerPrefs.DeleteAll ();
	}
	
	//set up functions to set and return each of the keys
	public static void SetDifficulty(float difficulty){
		if (difficulty >=1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range.");
		}
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}	
}
