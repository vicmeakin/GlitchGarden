using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesDisplay : MonoBehaviour {

	private Text txtLives;
	private int maxAttackersThrough;
	private int attackersLeft;
	private LevelManager lm;
	
	void Start(){
		lm = GameObject.FindObjectOfType<LevelManager>();
		txtLives=this.GetComponent<Text> ();
		
		//set how many attackers can get through based on selected difficulty
		int difficulty = Mathf.RoundToInt(PlayerPrefsManager.GetDifficulty());
		
		switch (difficulty)
		{
		case 1:
			maxAttackersThrough = 15;
			break;
		case 2:
			maxAttackersThrough = 10;
			break;
		case 3:
			maxAttackersThrough = 5;
			break;
		default:
			maxAttackersThrough = 10;
			break;
		}
		
		attackersLeft=maxAttackersThrough;
		UpdateDisplay();
	}
	
	private void UpdateDisplay(){
		txtLives.text = attackersLeft.ToString();
	}
	
	public void OneGotThrough(){
		attackersLeft -= 1;
		
		UpdateDisplay();
		
		//if we've reached the max number through, we have lost :(
		if (attackersLeft<=0){
			lm.LoadLevel ("LoseScreen");
		}
	}
}
