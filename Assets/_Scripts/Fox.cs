using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]		//this means we must have an attacker script on the component this script
											//is attached to, as we need to use it below. it makes no sense to have
											//a Fox, which is an attacker, that does not also have the Attackers component
											//so enforce this requirement with this check
public class Fox : MonoBehaviour {

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
		
		//so we know it's hit a defender, now we need to know how to handle that specific defender
		//for the gravestone, we want the fox to jump over. for others we want it to attack
		if (obj.GetComponent<Stone>()){
			myAnimator.SetTrigger ("FoxJump");
		} else {
			myAnimator.SetBool ("isAttacking",true);
			//for attacking use the standard 
			attacker.DoAttack (obj);
		}
	}
}
