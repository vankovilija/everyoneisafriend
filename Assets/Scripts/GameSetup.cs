using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSetup : MonoBehaviour {
	

	internal int lifesLost = 0;
	internal int scrolls = 0;
	internal float levelTime = 0;

	internal float confidenceLevel = 0;

	private bool countTime = true;
	private Camera mainCam;
		

	public delegate void EventHandler (int orderId);
	public event EventHandler CheckpointReach;

	internal float totalConfidence = 0;

	private float shardValue = 50;
	private float artifactValue = 50;

	public void OnCheckpoint(int orderId) {
		if (CheckpointReach != null) {
			CheckpointReach(orderId);
		}
	}


	void Start () {

		GameObject.FindGameObjectWithTag (PlayerControl.PLAYER_TAG).GetComponent<Health>().OnDeath += PlayerDeathHandler;
		mainCam = Camera.main;
		Screen.showCursor = false;

		ConfidenceCollectable[] collectables = GameObject.FindObjectsOfType<ConfidenceCollectable> ();

		int artifactCount = 0;
		int shardCount = 0;

		for(int i = 0; i < collectables.Length; i++){
			if(collectables[i].confidenceType == ConfidenceCollectable.ConfidenceType.Artifact){
				artifactCount++;
			}else if(collectables[i].confidenceType == ConfidenceCollectable.ConfidenceType.Shard){
				shardCount++;
			}
		}

		artifactValue /= artifactCount;
		shardValue /= shardCount;

	}

	void Update () {
		if (countTime)
			levelTime += Time.deltaTime;
	}

	void PlayerDeathHandler(){
		lifesLost ++;
		Debug.Log ("Lifes lost: " + lifesLost);
	}

	public void PickupScroll(GameObject scrollObject){
		scrolls++;
		mainCam.GetComponent<MenuCamera> ().menu.pickupScroll (scrollObject.GetComponent<ScrollCollect>().scrollID);
	}

	public void StopCountLevelTime() {
		countTime = false;
	}

	public void CollectConfidence(ConfidenceCollectable.ConfidenceType type){
		if(type == ConfidenceCollectable.ConfidenceType.Artifact){
			totalConfidence += artifactValue;
		}else if(type == ConfidenceCollectable.ConfidenceType.Shard){
			totalConfidence += shardValue;
		}

		mainCam.GetComponent<MenuCamera> ().menu.updateConfidence (totalConfidence);
	}
}
