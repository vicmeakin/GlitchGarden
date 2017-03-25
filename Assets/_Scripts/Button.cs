using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	private Button[] buttonArray;
	public static GameObject selectedDefender;
	private Text txtCost;

	void Start(){
		buttonArray = GameObject.FindObjectsOfType<Button>();
		
		txtCost=GetComponentInChildren<Text>();
		txtCost.text = defenderPrefab.GetComponent<Defender>().starCost.ToString ();
	}

	void OnMouseDown(){
		foreach (Button tempButton in buttonArray){
			tempButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
	
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
