using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {
	private LivesDisplay ld;
	
	void Start(){
		ld = GameObject.FindObjectOfType<LivesDisplay>();
	}
	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
		
		ld.OneGotThrough ();
	}
}
