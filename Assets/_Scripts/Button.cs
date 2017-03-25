using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	private Button[] buttonArray;
	public static GameObject selectedDefender;

	void Start(){
		buttonArray = GameObject.FindObjectsOfType<Button>();
	}

	void OnMouseDown(){
		foreach (Button tempButton in buttonArray){
			tempButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
	
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
