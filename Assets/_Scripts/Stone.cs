using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
	}
	
	void OnTriggerStay2D(Collider2D col){
		GameObject obj = col.gameObject;
		
		//if an attacker has collided with us, we want to trigger the animation for being attacked
		if (obj.GetComponent<Attacker>()){
			myAnimator.SetTrigger("UnderAttack");
		}	
	}
}
