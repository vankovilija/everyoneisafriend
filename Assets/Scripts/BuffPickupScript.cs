using UnityEngine;
using System.Collections;

public class BuffPickupScript : MonoBehaviour {

	public FoodType foodType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer ("player")) {
			//pickup buff
		}
	}
}
