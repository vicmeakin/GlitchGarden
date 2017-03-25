using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	//return true if destroyed
	public bool DamageMe(float dmg, GameObject healthParent){
		currentHealth -= dmg;
		
		if (currentHealth <= 0) {
			//if something has been destroyed, check if we need some stars as a reward for it
			GetStarReward (healthParent);
			Destroy (healthParent);
			return true;
		}
		return false;
	}

	void GetStarReward (GameObject healthParent)
	{
		//if we've destroyed an attacker, we want some stars
		if (healthParent.GetComponent<Attacker> ()) {
			starDisplay.AddStars (20);
		}
		//if we're on easy difficulty, we want more stars when a defender is destroyed too
		int difficulty = Mathf.RoundToInt (PlayerPrefsManager.GetDifficulty ());
		if (difficulty == 1 && healthParent.GetComponent<Defender> ()) {
			starDisplay.AddStars (50);
		}
	}
}
