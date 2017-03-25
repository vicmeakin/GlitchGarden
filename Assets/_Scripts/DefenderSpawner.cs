using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	//public GameObject defender;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	//Use this for initialization
	void Start () {
		//see if a defenders game object already exists
		defenderParent = GameObject.Find("Defenders");
		//if not, create one, and put our newly spawned defenders in it (just to keep things neat in the unity hierarchy!)
		if (!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	void OnMouseDown() {
		Vector2 mousePos = CalculateWorldPointOfMouseClick(); //get raw world pos from mouse pos
		Vector2 gridPos = SnapToGrid(mousePos);  //convert raw pos to the grid pos we need to place the object
		
		//only want to let them place the defenders on first 7 squares so they can see attackers coming an plan for them (and also to stop attackers being able to attack them while they are off screen if they 			
		//are using a 4:3 screen to play the game as that doesn't have any extra space on the edge for the attacker to approach from)
		if (gridPos.x <9f){		
			GameObject defender = Button.selectedDefender;
			int defenderCost = defender.GetComponent<Defender>().starCost;
			if(CanWeAffordIt(defenderCost)){	
				SpawnDefender (gridPos);
			}
		}
	}

	void SpawnDefender (Vector2 gridPos)
	{
		GameObject newDefender = Instantiate (Button.selectedDefender, gridPos, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
	}
	
	bool CanWeAffordIt(int defenderCost){
		if(starDisplay.UseStars (defenderCost)==StarDisplay.Status.SUCCESS){
			return true;
		}
		return false;
	}
	
	Vector2 CalculateWorldPointOfMouseClick ()
	{
		//mouse give position in pixels, so we need to map these to world points before we can use them using screenToWorldPoint
		//Vector2 mousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos = myCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
		return mousePos;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos)
	{
		//get the grid position they clicked in by rounding the values
		//eg they clicked <3.7,2.1>, then we need to round this to <4,2> and put the defender there
		Vector2 gridPos = new Vector2();
		gridPos.x = Mathf.RoundToInt (rawWorldPos.x);
		gridPos.y = Mathf.RoundToInt (rawWorldPos.y);
		return gridPos;
	}
}
