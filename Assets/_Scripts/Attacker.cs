using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	//[Range (-1f,1.5f)] public float currentSpeed;  //range command makes unity display a slider and limits min and max values for this variable
	
	[Tooltip ("Set how frequently an attacker is spawned in each lane on average")]
	[Range (1f,60f)] public float seenEveryXSecs = 10f;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator myAnimator;
	
	// Use this for initialization
	void Start () {
		//add a rigid body to this attacker
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic=true;
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//if no current target, stop them attacking
		if(!currentTarget){ 
			myAnimator.SetBool ("isAttacking",false);
		}
		
		transform.Translate (Vector3.left * currentSpeed*Time.deltaTime);
	}
	
	public void setSpeed(float speed){
		currentSpeed = speed;
	}
	
	//called from animator at the time of the actual attack
	public void StrikeCurrentTarget(float damage) {
		//Find the health component of the current target, and tell it that it is being damaged
		if(currentTarget){
			Health targetHealth = currentTarget.GetComponent<Health>();
			if (targetHealth){
				//damageMe returns true if the target has been destroyed, so put attacker back in to walk mode
				if(targetHealth.DamageMe (damage, currentTarget)){
					myAnimator.SetBool ("isAttacking",false);
					currentTarget=null;
				}			
			}
		}
	}
	
	public void DoAttack(GameObject target){
		currentTarget = target;	
	}

}
