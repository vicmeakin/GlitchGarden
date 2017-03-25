using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	public void LoadLevel(string levelName){
		Application.LoadLevel (levelName);
	}

	public void QuitRequest(){
		Application.Quit ();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel (Application.loadedLevel+1);
	}
	
	public void GameOverMan(){
		Application.LoadLevel ("LoseScreen");
	}
}
