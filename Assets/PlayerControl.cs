using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	[HideInInspector]
	public bool jump = false;
	[HideInInspector]
	public int theScale;
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 10f;	
	public float jumpForce = 1000f;
	
	private Transform groundCheck0;
	private Transform groundCheck1;
	private bool grounded = false;
	
	private bool leftPressed;
	private bool rightPressed;
	private int axisDirection;
	

	void Awake()
	{
		// Setting up references.
		groundCheck0 = transform.Find("groundCheck0");
		groundCheck1 = transform.Find("groundCheck1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
		grounded = Physics2D.Linecast(groundCheck0.position, groundCheck1.position); 
		
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;

		leftPressed = Input.GetButton ("Left");
		rightPressed = Input.GetButton ("Right");

		if (leftPressed) {
			axisDirection = -1;
		} else if (rightPressed) {
			axisDirection = 1;
		} else {
			axisDirection = 0;
		}

		rigidbody2D.velocity = new Vector2 (axisDirection * maxSpeed, rigidbody2D.velocity.y);
		
		if (jump) {			
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		} 
		
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
