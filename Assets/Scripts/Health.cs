using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public delegate void EventHandler ();
	public event EventHandler OnDeath;

	void Start() {
		GetComponentInChildren<AnimationController> ().AnimationStart += OnAnimationStart;
	}

	void die() {
		rigidbody2D.velocity = new Vector2 (0f, 0f);
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponentInChildren<AnimationController> ().Die ();
		if (OnDeath != null)
			OnDeath ();
	}

	void OnAnimationStart (AnimationState state) {
		if (state == AnimationState.spawn) {
			respawn();
		}
	}

	void respawn() {
		transform.position = GetComponent<PlayerControl> ().spawnPosition;
		GetComponent<BoxCollider2D> ().enabled = true;
	}
}
