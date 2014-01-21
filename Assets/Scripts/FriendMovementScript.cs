using UnityEngine;
using System.Collections;

public class FriendMovementScript : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public string[] platformLayers;

	private Vector3 topLeft;
	private Vector3 topRight;
	private Vector3 bottomLeft;
	private Vector3 bottomRight;

	private Vector3 singleUnitHorizontalVector;
	private Vector3 singleUnitVerticalVector;

	private bool fallingLeft;
	private bool fallingRight;
	private bool hitLeft;
	private bool hitRight;

	private int direction = 1;

	private Vector2 previousVelocity;

	// Use this for initialization
	void Start () {
		BoxCollider2D colider = GetComponent<BoxCollider2D> ();
		topLeft = new Vector3 (colider.center.x - colider.size.x / 2, colider.center.y + colider.size.y / 2, 0f);
		topRight = new Vector3 (colider.center.x + colider.size.x / 2, colider.center.y + colider.size.y / 2, 0f);
		bottomLeft = new Vector3 (colider.center.x - colider.size.x / 2, colider.center.y - colider.size.y / 2, 0f);
		bottomRight = new Vector3 (colider.center.x + colider.size.x / 2, colider.center.y - colider.size.y / 2, 0f);

		singleUnitHorizontalVector = new Vector3 (0.3f, 0f, 0f);
		singleUnitVerticalVector = new Vector3 (0f, 0.1f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		int layerMask = 0;
		for (int i = 0; i < platformLayers.Length; i++) {
			layerMask = layerMask | (1 << LayerMask.NameToLayer(platformLayers[i]));
		}

		fallingLeft = !(Physics2D.Linecast(transform.position, transform.position + bottomLeft - singleUnitHorizontalVector - singleUnitVerticalVector, layerMask));
		fallingRight = !(Physics2D.Linecast(transform.position, transform.position + bottomRight + singleUnitHorizontalVector - singleUnitVerticalVector, layerMask));
		hitLeft = Physics2D.Linecast (transform.position + topLeft - singleUnitHorizontalVector, transform.position + bottomLeft - singleUnitHorizontalVector, layerMask);
		hitRight = Physics2D.Linecast (transform.position + topRight + singleUnitHorizontalVector, transform.position + bottomRight + singleUnitHorizontalVector, layerMask);

		if ((direction == 1 && (fallingRight || hitRight)) || (direction == -1 && (fallingLeft || hitLeft))) {
			direction *= -1;
		}

		Vector2 newVelocity = new Vector2 (moveSpeed * direction, rigidbody2D.velocity.y);
		rigidbody2D.velocity = newVelocity;

		if (previousVelocity != newVelocity) {
			MoveSpeedEventDispatcher dispatcher = GetComponent<MoveSpeedEventDispatcher> ();
			if (dispatcher != null) {
					dispatcher.onMoveSpeedChange ();
			}
		}

		previousVelocity = newVelocity;

		Flip ();
	}

	void Flip(){			
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		
		if (direction > 0)
			theScale.x = -1;
		else if(direction < 0)
			theScale.x = 1;
		
		transform.localScale = theScale;
	}
}
