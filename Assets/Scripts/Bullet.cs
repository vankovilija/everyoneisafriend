using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public string[] hitLayers;

	public FoodType type;
	public float destroyTime = 5f;

	private bool destroy = false;

	void OnCollisionEnter2D(Collision2D coll){
		bool hit = false;
		for (int i = 0; i < hitLayers.Length; i++) {
			hit = hit || coll.gameObject.layer == LayerMask.NameToLayer(hitLayers[i]);
		}

		if (hit) {
			Destroy(gameObject);
			return;
		}else
		if (!destroy) {
			Destroy (gameObject, destroyTime);
		}

		destroy = true;

	}
}
