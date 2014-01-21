using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	static public string PLAYER_TAG = "Player";

	[HideInInspector]
	public float jump = 0;

	public string[] platformLayers;
	public string[] passTroughLayers;
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 10f;	
	public float jumpForce = 1000f;

	private RaycastHit2D grounded;
	private RaycastHit2D sky;

	private Vector3 topLeft;
	private Vector3 topRight;
	private Vector3 bottomLeft;
	private Vector3 bottomRight;
	
	private Vector3 singleUnitHorizontalVector;
	private Vector3 singleUnitVerticalVector;
	
	private bool leftPressed;
	private bool rightPressed;
	private int axisDirection;

	private MoveSpeedEventDispatcher currentGroundMoveSpeedEventDispatcher;
	private Vector2 groundVelocity = new Vector2(0f,0f);

	private Vector2 _spawnPosition;
	public Vector2 spawnPosition{
		get{
			return _spawnPosition;
		}
	}

	void Start()
	{
		gameObject.tag = PLAYER_TAG;
		BoxCollider2D colider = GetComponent<BoxCollider2D> ();
		topLeft = new Vector3 (colider.center.x - colider.size.x / 2, colider.center.y + colider.size.y / 2, 0f);
		topRight = new Vector3 (colider.center.x + colider.size.x / 2, colider.center.y + colider.size.y / 2, 0f);
		bottomLeft = new Vector3 (colider.center.x - colider.size.x / 2, colider.center.y - colider.size.y / 2, 0f);
		bottomRight = new Vector3 (colider.center.x + colider.size.x / 2, colider.center.y - colider.size.y / 2, 0f);
		
		singleUnitHorizontalVector = new Vector3 (0.3f, 0f, 0f);
		singleUnitVerticalVector = new Vector3 (0f, 0.1f, 0f);
		_spawnPosition = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && grounded && grounded.collider.gameObject.tag != "Bullet")
			jump = 1;
	}
	
	void FixedUpdate() {
		int layerMask = 0;
		for (int i = 0; i < platformLayers.Length; i++) {
			layerMask = layerMask | (1 << LayerMask.NameToLayer(platformLayers[i]));
		}
		grounded = Physics2D.Linecast(transform.position + bottomLeft - singleUnitVerticalVector, transform.position + bottomRight - singleUnitVerticalVector, layerMask); 		

		layerMask = 0;
		for (int i = 0; i < passTroughLayers.Length; i++) {
			layerMask = layerMask | (1 << LayerMask.NameToLayer(passTroughLayers[i]));
		}
		sky = Physics2D.Linecast(transform.position + topLeft + singleUnitVerticalVector * 2 - singleUnitHorizontalVector, transform.position + topRight + singleUnitVerticalVector * 2 + singleUnitHorizontalVector, layerMask); 		
					
		if (sky && sky.collider.gameObject.layer == LayerMask.NameToLayer("platforms")) {
			Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("player"), LayerMask.NameToLayer("platforms"));
		}

		if (grounded && grounded.collider.gameObject.tag != "Bullet") {
			MoveSpeedEventDispatcher newDispatcher = grounded.collider.gameObject.GetComponent<MoveSpeedEventDispatcher> ();
			if (newDispatcher != currentGroundMoveSpeedEventDispatcher) {
				if (currentGroundMoveSpeedEventDispatcher != null)
						currentGroundMoveSpeedEventDispatcher.MoveSpeedChange -= OnGroundSpeedChange;
				currentGroundMoveSpeedEventDispatcher = newDispatcher;
				if (currentGroundMoveSpeedEventDispatcher != null)
						currentGroundMoveSpeedEventDispatcher.MoveSpeedChange += OnGroundSpeedChange;

				UpdateGroundVelocity();
				UpdatePlayerMoveSpeed();
			}
			Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("player"), LayerMask.NameToLayer("platforms"), false);
		}

		leftPressed = Input.GetButton ("Left");
		rightPressed = Input.GetButton ("Right");

		if (leftPressed) {
			axisDirection = -1;
		} else if (rightPressed) {
			axisDirection = 1;
		} else {
			axisDirection = 0;
		}

		UpdatePlayerMoveSpeed ();
				
		Flip ();
	}

	void UpdatePlayerMoveSpeed(){
		Vector2 moveSpeed = new Vector2(axisDirection * maxSpeed, jump * jumpForce);
		jump = 0;

		moveSpeed += groundVelocity;	
		
		rigidbody2D.velocity = new Vector2 (moveSpeed.x, moveSpeed.y + rigidbody2D.velocity.y);
	}

	void OnGroundSpeedChange(GameObject groundObject){
		UpdateGroundVelocity ();
		UpdatePlayerMoveSpeed ();
	}

	void UpdateGroundVelocity(){
		if (grounded && grounded.collider.gameObject.rigidbody2D != null)
			groundVelocity = grounded.collider.gameObject.rigidbody2D.velocity;
		else
			groundVelocity = new Vector2 (0f, 0f);
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
