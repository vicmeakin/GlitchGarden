using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]		//this means we must have an attacker script on the component this script
//is attached to, as we need to use it below. it makes no sense to have
//a Fox, which is an attacker, that does not also have the Attackers component
//so enforce this requirement with this check
public class Lizard : MonoBehaviour {
	
	private Animator myAnimator;
	private Attacker attacker;
	
	
	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;
		
		//only want to take action if we have collided with a defender, return if not
		if (!obj.GetComponent<Defender>()){
			return;
		}

		//fox has special attacks for different defenders. Lizard attacks all the same way
		myAnimator.SetBool ("isAttacking",true);
		//for attacking use the standard 
		attacker.DoAttack (obj);

		
	}
}
