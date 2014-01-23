using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSetup : MonoBehaviour {

	public static List<GameObject> happyFriends = new List<GameObject>();
	public static List<GameObject> angryFriends = new List<GameObject>();

	public int lifesLost = 0;

	private Camera mainCam;


	void Start () {

		GameObject.FindGameObjectWithTag (PlayerControl.PLAYER_TAG).GetComponent<Health>().OnDeath += PlayerDeathHandler;

		FriendScript[] friends = GameObject.FindObjectsOfType<FriendScript> ();
		for(int i = 0; i < friends.Length; i++){
			friends[i].ChangeState += onFriendStateChange;
			onFriendStateChange(friends[i].gameObject, friends[i].state);
		}

	}

	void OnGUI(){
		GUI.Label (new Rect (10, 10, 200, 50), "Happy friends: " + happyFriends.Count);
		GUI.Label (new Rect (10, 22, 200, 50), "Lifes lost: " + lifesLost);
	}

	void PlayerDeathHandler(){
		lifesLost ++;
		Debug.Log ("Lifes lost: " + lifesLost);
	}

	void onFriendStateChange(GameObject friend, FriendState state){
		if (state == FriendState.happy) {
			if(happyFriends.IndexOf(friend) == -1)
				happyFriends.Add(friend);
			angryFriends.Remove(friend);
		} else if (state == FriendState.angry || state == FriendState.veryAngry) {
			if(angryFriends.IndexOf(friend) == -1)
				angryFriends.Add(friend);
			happyFriends.Remove(friend);
		}
		Debug.Log ("happy friends: " + happyFriends.Count + " angry friends: " + angryFriends.Count);
	}

}
