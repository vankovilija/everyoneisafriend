using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public delegate void EventHandler ();
	public event EventHandler OnDeath;

	void die() {
		transform.position = GetComponent<PlayerControl> ().spawnPosition;
		rigidbody2D.velocity = new Vector2 (0f, 0f);
		if (OnDeath != null)
			OnDeath ();
	}
}
