using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator myAnimator;
	private AttackerSpawner myLaneSpawner;

	//Use this for initialization
	void Start () {
		myAnimator = GameObject.FindObjectOfType<Animator>();
	
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		
		setMyLaneSpawner ();
	}

	void Update(){
		if (isAttackerInLane()){
			myAnimator.SetBool("isAttacking", true);
		} else{
			myAnimator.SetBool("isAttacking", false);
		}
	}

	private bool isAttackerInLane(){
		//float shooterY = this.transform.position.y;
		int numAttackersInLane = myLaneSpawner.transform.childCount;
		
		//find out if spawner has any children
		if(numAttackersInLane>0)
		{
			//there is an attacker - check if they are in sight, and have not already gone past the defender
			//loop through all children
			for(int i = 0; i < numAttackersInLane;i++){
				//check if child position is <= to right-most box 9, and still to the right of the defender
				float attackerPos = myLaneSpawner.transform.GetChild (i).transform.position.x;
				if ( attackerPos<= 9 && attackerPos > this.transform.position.x){
					return true;
				}
			}
		}
		
		//no children in lane
		return false;
	}

	void setMyLaneSpawner(){
		float shooterY = this.transform.position.y;
		
		AttackerSpawner[] allSpawners = GameObject.FindObjectsOfType<AttackerSpawner>();// as AttackerSpawner;
		
		foreach (AttackerSpawner thisSpawner in allSpawners){
			if (thisSpawner.transform.position.y==shooterY){
				myLaneSpawner = thisSpawner;
				return;
			}
		}
		
		if (!myLaneSpawner){
			Debug.LogError ("No spawner found for "+shooterY);
		}
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		//newProjectile.transform.position = transform.position;
		newProjectile.transform.parent=projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
		//myAnimator.SetBool ("isAttacking",false);
	}
}
