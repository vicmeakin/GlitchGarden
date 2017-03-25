using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {


	public int numStars = 500;
	private Text txtAmount;
	public enum Status {SUCCESS,FAILURE};

	void Start(){
		txtAmount=this.GetComponent<Text> ();
		UpdateDisplay();
	}
	
	public void AddStars(int amount){
		numStars += amount;
		UpdateDisplay();
	}
	
	public Status UseStars(int amount){
		//only use stars if we have enough. return true if they can use the stars, or false if not
		if (numStars >= amount){
			numStars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		txtAmount.text = numStars.ToString();
	}
}
