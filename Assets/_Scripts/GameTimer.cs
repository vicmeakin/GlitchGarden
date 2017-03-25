using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
[RequireComponent (typeof(AudioSource))]
public class GameTimer : MonoBehaviour {

	public int levelTime = 10;
	private Slider countDown;
	private float endTime;
	private AudioSource winSound;
	private bool levelWon;
	private GameObject txtWin;
	private LevelManager lm;

	// Use this for initialization
	void Start () {
		SetupSlider ();
		FindWinLable ();
		winSound=GetComponent<AudioSource>();
		lm = FindObjectOfType<LevelManager>();
		levelWon=false;
	}

	void SetupSlider ()
	{
		countDown = GetComponent<Slider> ();
		countDown.maxValue = levelTime;
		countDown.value = levelTime;
		endTime = Time.time + levelTime;
	}

	void FindWinLable ()
	{
		txtWin = GameObject.Find ("txtWin");
		if(!txtWin){
			Debug.LogWarning ("txtWin not found, please create");
		}
		txtWin.SetActive (false);
		//txtWin.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!levelWon){  //checking if level won to stop it calling win level every update while win message is displayed
			float timeLeft = endTime-Time.time;
			
			if (timeLeft <= 0){
				WinLevel();
			} else {
				countDown.value=timeLeft;
			}
		}
	}

	void WinLevel ()
	{
		levelWon=true;
		winSound.Play ();
		txtWin.SetActive (true);
		Invoke ("LoadNext",winSound.clip.length);
	}
	
	void LoadNext(){
		lm.LoadNextLevel ();
	}
	
}
