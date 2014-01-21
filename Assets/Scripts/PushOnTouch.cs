using UnityEngine;
using System.Collections;

public class PushOnTouch : MonoBehaviour {

	public string pushTag = "Player";
	public float pushForce = 20.0f;
	
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

				Vector2 forceDirection = (player.transform.position - transform.position);
				Debug.Log(forceDirection.y);
				if(forceDirection.y <= -0.5f){
					forceDirection.y = 0f;
				}else if(forceDirection.y <= 0){
					forceDirection.y = 2f;
				}

				player.AddImpulse(forceDirection.normalized * pushForce);
			}

		}
	}
}
