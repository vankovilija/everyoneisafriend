using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	[HideInInspector]
	public float jump = 0;
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 10f;	
	public float jumpForce = 1000f;

	private RaycastHit2D grounded;

	private Vector3 topLeft;
	private Vector3 topRight;
	private Vector3 bottomLeft;
	private Vector3 bottomRight;
	
	private Vector3 singleUnitHorizontalVector;
	private Vector3 singleUnitVerticalVector;
	
	private bool leftPressed;
	private bool rightPressed;
	private int axisDirection;

	void Start()
	{
		gameObject.tag = "Player";
		BoxCollider2D colider = GetComponent<BoxCollider2D> ();
		topLeft = new Vector3 (colider.center.x - colider.size.x / 2, colider.center.y + colider.size.y / 2, 0f);
		topRight = new Vector3 (colider.center.x + colider.size.x / 2, colider.center.y + colider.size.y / 2, 0f);
		bottomLeft = new Vector3 (colider.center.x - colider.size.x / 2, colider.center.y - colider.size.y / 2, 0f);
		bottomRight = new Vector3 (colider.center.x + colider.size.x / 2, colider.center.y - colider.size.y / 2, 0f);
		
		singleUnitHorizontalVector = new Vector3 (0.3f, 0f, 0f);
		singleUnitVerticalVector = new Vector3 (0f, 0.3f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && grounded)
			jump = 1;
	}
	
	void FixedUpdate() {
		grounded = Physics2D.Linecast(transform.position + bottomLeft - singleUnitVerticalVector, transform.position + bottomRight - singleUnitVerticalVector); 		

		leftPressed = Input.GetButton ("Left");
		rightPressed = Input.GetButton ("Right");

		if (leftPressed) {
			axisDirection = -1;
		} else if (rightPressed) {
			axisDirection = 1;
		} else {
			axisDirection = 0;
		}

		float moveSpeedX = axisDirection * maxSpeed;
		float moveSpeedY = jump * jumpForce;
		jump = 0;
		if (grounded && grounded.collider.gameObject.rigidbody2D) {
			moveSpeedX += grounded.collider.gameObject.rigidbody2D.velocity.x;
			moveSpeedY += grounded.collider.gameObject.rigidbody2D.velocity.y;
		}

		rigidbody2D.velocity = new Vector2 (moveSpeedX, moveSpeedY + rigidbody2D.velocity.y);
				
		Flip ();
	}
	
	void Flip(){			
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		
		if (axisDirection > 0)
			theScale.x = 1;
		else if(axisDirection < 0)
			theScale.x = -1;
		
		transform.localScale = theScale;
	}
}
