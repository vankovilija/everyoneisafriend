using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	void die() {
		transform.position = GetComponent<PlayerControl> ().spawnPosition;
		rigidbody2D.velocity = new Vector2 (0f, 0f);
	}
}
