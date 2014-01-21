using UnityEngine;
using System.Collections;

public class PlayerAddForce : MonoBehaviour {
	public float pushTime = 0.5f;

	private bool disableMovement = false;
	private PlayerControl player;

	private Vector2 frictionVelocity;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerControl> ();
	}

	void FixedUpdate ()
	{
		if (disableMovement)
		{
			Vector2 newVelocity = new Vector2(Mathf.SmoothDamp(rigidbody2D.velocity.x, 0, ref frictionVelocity.x, pushTime), 
			                                  Mathf.SmoothDamp(rigidbody2D.velocity.y, 0, ref frictionVelocity.y, pushTime));
			rigidbody2D.velocity = newVelocity;
			if ((rigidbody2D.velocity.x <= 1 && rigidbody2D.velocity.y <= 1) && 
			    (rigidbody2D.velocity.x >= -1 && rigidbody2D.velocity.y >= -1))
			{
				disableMovement = false;
				player.disabled = false;
				collider2D.sharedMaterial.friction = 0f;
			}
		}
	}

	public void AddImpulse(Vector2 force) 
	{
		if (player.enabled) {
			player.disabled = true;
			disableMovement = true;
			if (rigidbody2D != null) {
				rigidbody2D.velocity = force;
				collider2D.sharedMaterial.friction = 0.5f;
				float aproxFramesForTime = (25 * pushTime);
				frictionVelocity = new Vector2(force.x / aproxFramesForTime, force.y / aproxFramesForTime);
			}
		}
	}
}
