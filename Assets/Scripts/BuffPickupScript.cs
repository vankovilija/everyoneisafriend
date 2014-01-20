using UnityEngine;
using System.Collections;

public class BuffPickupScript : MonoBehaviour {

	public FoodType foodType;
	public delegate void EventHandler (FoodType type);

	public event EventHandler PickedUpBuff;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == PlayerControl.PLAYER_TAG) {
			//pickup buff
			Destroy (gameObject);
			PickedUpBuff(foodType);
		}
	}
}
