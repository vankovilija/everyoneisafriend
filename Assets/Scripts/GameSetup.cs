using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSetup : MonoBehaviour {
	

	internal int lifesLost = 0;
	internal int scrolls = 0;

	private Camera mainCam;

	public delegate void EventHandler (int orderId);
	public event EventHandler CheckpointReach;

	public void OnCheckpoint(int orderId) {
		if (CheckpointReach != null) {
			CheckpointReach(orderId);
		}
		mainCam = Camera.main;
	}


	void Start () {

		GameObject.FindGameObjectWithTag (PlayerControl.PLAYER_TAG).GetComponent<Health>().OnDeath += PlayerDeathHandler;

	}

	void PlayerDeathHandler(){
		lifesLost ++;
		Debug.Log ("Lifes lost: " + lifesLost);
	}

	public void PickupScroll(GameObject scrollObject){
		scrolls++;
		mainCam.GetComponent<MenuCamera> ().menu.pickupScroll (scrollObject.GetComponent<ScrollCollect>().scrollID);
	}
}
