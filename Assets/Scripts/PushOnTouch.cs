using UnityEngine;
using System.Collections;

public class PushOnTouch : MonoBehaviour {

	public string pushTag = "Player";
	public float pushForce = 100000.0f;
	
	void OnCollisionEnter2D (Collision2D col)
	{
		PushObjectIfTagMatch (col.gameObject);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		PushObjectIfTagMatch (col.gameObject);
	}
	
	void PushObjectIfTagMatch(GameObject obj) {
		if (pushTag == obj.tag) {
			PlayerAddForce player = obj.GetComponent<PlayerAddForce> ();
			if (player != null && player.rigidbody2D != null) {
				player.AddForce(player.rigidbody2D.velocity.normalized * pushForce);
			}

		}
	}
}
