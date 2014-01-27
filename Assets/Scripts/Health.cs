using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public delegate void EventHandler ();
	public event EventHandler OnDeath;

	public float deathTime;

	private bool inited = false;
	private float timer = 0;
	private bool death = false;
	private PlayerControl player;

	void Start () {

		player = GetComponent<PlayerControl> ();

	}

	void Update() {
		if (!inited) {
			inited = true;
		}
		if (death) {
			timer += Time.deltaTime;
			if (timer >= deathTime) {
				respawn ();
			}
		}
	}

	void die() {
		if (!death) {
			player.disabled = true;
			rigidbody2D.velocity = new Vector2 (0f, 0f);
	//		GetComponent<BoxCollider2D> ().enabled = false;
			GetComponentInChildren<Animator> ().SetTrigger("Die");
			death = true;
			timer = 0;
			if (OnDeath != null)
				OnDeath ();

			LimitedTimeComponent[] limitedComponents = GetComponents<LimitedTimeComponent>();
			for(int i = 0; i < limitedComponents.Length; i++){
				limitedComponents[i].ExpireComponent();
			}
		}
	}

	void respawn() {
		player.disabled = false;
		transform.position = GetComponent<PlayerControl> ().spawnPosition;
//		GetComponent<BoxCollider2D> ().enabled = true;
		GetComponentInChildren<Animator>().SetTrigger("Respawn");
		death = false;
	}
}
