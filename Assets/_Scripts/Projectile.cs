using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	//private Animator myAnimator;
	
	// Use this for initialization
	void Start () {
		//myAnimator = GetComponent<Animator>();
	}	
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed*Time.deltaTime);
	}
	
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;
		
		//only want to take action if we have collided with an attacker, return if not
		if (!obj.GetComponent<Attacker>()){
			return;
		}

		StrikeCurrentTarget (obj);
		Destroy (gameObject); //destroy the projectile when it hits something
	}
	
	//called from animator at the time of the actual attack
	public void StrikeCurrentTarget(GameObject theTarget) {
		//Find the health component of the current target, and tell it that it is being damaged
		if(theTarget){
			Health targetHealth = theTarget.GetComponent<Health>();
			if (targetHealth){
				//damageMe returns true or false for if target is destroyed. For projectile, we don't care as no need to act differently, so just use a temp variable for return
				bool tempBool = targetHealth.DamageMe (damage, theTarget);
				bool tempBool2 = tempBool; //not needed, but just to shut up the warning messages about it not being used
				tempBool = tempBool2;
			}
		}
	}
}
