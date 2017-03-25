using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesDisplay : MonoBehaviour {

	private Text txtLives;
	public int maxAttackersThrough = 1;
	private int attackersLeft;
	private LevelManager lm;
	
	void Start(){
		lm = GameObject.FindObjectOfType<LevelManager>();
		attackersLeft=maxAttackersThrough;
		txtLives=this.GetComponent<Text> ();
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
