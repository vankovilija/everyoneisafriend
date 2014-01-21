using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	public static int happyCount = 0;
	public static int angryCount = 0;

	public int lifesLost = 0;

	private Camera mainCam;


	void Start () {

		GameObject.FindGameObjectWithTag (PlayerControl.PLAYER_TAG).GetComponent<Health>().OnDeath += PlayerDeathHandler;

	}

	void PlayerDeathHandler(){
		lifesLost ++;
		Debug.Log ("Lifes lost: " + lifesLost);
	}

}
