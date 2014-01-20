using UnityEngine;
using System.Collections;

public class BuffPickupScript : MonoBehaviour {

	public FoodType foodType;
	public GameObject spawnBuff;

	// Use this for initialization
	void Start () {
		spawnBuff = GameObject.Find ("_BuffSpawn");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == PlayerControl.PLAYER_TAG) {
			//pickup buff
			Destroy (gameObject);
			spawnBuff.SendMessage("CollectedBuff");
		}
	}
}
