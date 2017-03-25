using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	//private GameObject attackerParent;
	public GameObject[] theAttackers;
	//private Animator myAnimator;
	
	//Use this for initialization
	//void Start () {
	//	attackerParent = GameObject.Find("Attackers");
	//	if (!attackerParent){
	//		attackerParent = new GameObject("Attackers");
	//	}
	//}
	
	// Update is called once per frame
	void Update () {
		//GameObject newAttacker = Instantiate (theAttackers[1],transform.position, Quaternion.identity) as GameObject;
		//newAttacker.transform.parent=attackerParent.transform;
		foreach (GameObject thisAttacker in theAttackers){
			if (isTimeToSpawn(thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}

	bool isTimeToSpawn (GameObject thisAttacker)
	{
		Attacker attacker = thisAttacker.GetComponent<Attacker>();
		float averageSpawnDelay = attacker.seenEveryXSecs;
		float spawnsPerSecond = 1/ averageSpawnDelay;
		
		if (Time.deltaTime > averageSpawnDelay){
			Debug.LogWarning ("spawn rate capped by frame rate");
		}
		
		float threshhold = spawnsPerSecond * Time.deltaTime /5; //divide by 5 because 5 lanes of spawners
		if (Random.value < threshhold){
			return true;
		}
		
		return false;
	}
	
	void Spawn(GameObject theAttacker){
		GameObject newAttacker = Instantiate (theAttacker,transform.position, Quaternion.identity) as GameObject;
		//newAttacker.transform.parent=attackerParent.transform;	
		newAttacker.transform.parent=this.transform;	
		//newAttacker.SetMove(true);
	}
	
}
