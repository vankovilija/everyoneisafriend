using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public delegate void EventHandler ();
	public event EventHandler OnDeath;

	private bool inited = false;

	void Update() {
		if (!inited) {
			inited = true;
		}
	}

	void die() {
		rigidbody2D.velocity = new Vector2 (0f, 0f);
		GetComponent<BoxCollider2D> ().enabled = false;
		respawn ();
		if (OnDeath != null)
			OnDeath ();
	}

	void OnAnimationStart (string animationName) {
		if (animationName == AnimationController.SPAWN) {
			respawn();
		}
	}

	void respawn() {
		transform.position = GetComponent<PlayerControl> ().spawnPosition;
		GetComponent<BoxCollider2D> ().enabled = true;
	}
}
