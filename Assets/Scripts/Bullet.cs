using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public FoodType type;
	public float destroyTime = 5f;

	private bool destroy = false;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Friends")) {
			Destroy(gameObject);
			return;
		}

		if (!destroy) {
			Destroy (gameObject, destroyTime);
		}

		destroy = true;

	}
}
