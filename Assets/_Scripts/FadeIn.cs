using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	private float fadeTime = 1f;
	private Image fadePanel;
	private Color currentColour = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		fadePanel.color = currentColour;
		//currentColour=fadePanel.color;
		
	}
	
	// Update is called once per frame
	void Update () {
		//fade out the panel over the number of seconds set for the fade in time
		if(Time.timeSinceLevelLoad < fadeTime){
			if (currentColour.a>0f){
				//currentColour.a-=0.005f;
				float alphaChange = Time.deltaTime/fadeTime;	//get percentage change needed for this frame (eg 2 second from and 2 second fade time = 100% change, or 1/10th second fram with a 2 second fade would need a 5% fade
				//currentColour.a -= ((currentColour.a/100)*alphaChange);
				currentColour.a -= alphaChange;
				//Debug.Log (currentColour.a);
				fadePanel.color=currentColour;
			}
		} else {
			//once faded in, disable the panel so that buttons can be clicked
			//fadePanel.enabled=false;
			gameObject.SetActive(false);
		}
			
	}
}
