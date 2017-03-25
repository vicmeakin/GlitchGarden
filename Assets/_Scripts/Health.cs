using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	//return true if destroyed
	public bool DamageMe(float dmg, GameObject healthParent){
		currentHealth -= dmg;
		
		if (currentHealth <= 0) {
			Destroy (healthParent);
			return true;
		}
		return false;
	}

}
