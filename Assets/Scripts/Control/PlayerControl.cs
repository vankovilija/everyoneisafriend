using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	static public string PLAYER_TAG = "Player";

	internal bool disabled = false;

	public string[] platformLayers;
	public string[] passTroughLayers;
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 10f;	
	public float jumpForce = 1000f;

	internal RaycastHit2D ground;
	internal bool grounded = true;
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

	private AnimationController animationController;

	private Vector2 _spawnPosition;
	public Vector2 spawnPosition{
		get{
			return _spawnPosition;
		}
	}
	private Animator anim;

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

		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void FixedUpdate() {
		int layerMaskGround = 0;
		for (int i = 0; i < platformLayers.Length; i++) {
			layerMaskGround = layerMaskGround | (1 << LayerMask.NameToLayer(platformLayers[i]));
		}
		Vector3 bottomLeftScaled = new Vector3 (bottomLeft.x * transform.lossyScale.x, bottomLeft.y * transform.lossyScale.y, bottomLeft.z * transform.lossyScale.z);
		Vector3 bottomRightScaled = new Vector3 (bottomRight.x * transform.lossyScale.x, bottomRight.y * transform.lossyScale.y, bottomRight.z * transform.lossyScale.z);
		Vector3 topRightScaled = new Vector3 (topRight.x * transform.lossyScale.x, topRight.y * transform.lossyScale.y, topRight.z * transform.lossyScale.z);
		Vector3 topLeftScaled = new Vector3 (topLeft.x * transform.lossyScale.x, topLeft.y * transform.lossyScale.y, topLeft.z * transform.lossyScale.z);

		Vector3 groundRaycastPoint = transform.position + bottomLeftScaled - singleUnitVerticalVector;
		Vector3 tempPoint = transform.position + bottomRightScaled - singleUnitVerticalVector;
		Vector3 direction = (groundRaycastPoint - singleUnitVerticalVector) - groundRaycastPoint;
		ground = Physics2D.Raycast(groundRaycastPoint, direction); 
		RaycastHit2D tempHit = Physics2D.Raycast (tempPoint, direction); 
		if (Vector2.Distance (groundRaycastPoint, ground.point) > Vector2.Distance (tempHit.point, tempPoint)) {
			ground = tempHit;
			groundRaycastPoint = tempPoint;
		}

		int layerMask = 0;
		for (int i = 0; i < passTroughLayers.Length; i++) {
			layerMask = layerMask | (1 << LayerMask.NameToLayer(passTroughLayers[i]));
		}

		Vector3 skyRaycastPoint = transform.position + topLeftScaled + singleUnitVerticalVector - singleUnitHorizontalVector;
		tempPoint = transform.position + topRightScaled + singleUnitVerticalVector + singleUnitHorizontalVector;
		direction = ((skyRaycastPoint + singleUnitVerticalVector) - skyRaycastPoint).normalized;
		sky = Physics2D.Raycast (skyRaycastPoint, direction);		
		tempHit = Physics2D.Raycast (tempPoint, direction);			
		if (Vector2.Distance (skyRaycastPoint, sky.point) > Vector2.Distance (tempHit.point, tempPoint)) {
			sky = tempHit;
			skyRaycastPoint = tempPoint;
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

		double distanceToGround = Vector2.Distance (ground.point, groundRaycastPoint);

		if (ground && ground.collider.gameObject.tag != "Bullet" && (distanceToGround < 0.2f || distanceToGround < Mathf.Abs( rigidbody2D.velocity.y * Time.deltaTime ))) {
			MoveSpeedEventDispatcher newDispatcher = ground.collider.gameObject.GetComponent<MoveSpeedEventDispatcher> ();
			if (newDispatcher != currentGroundMoveSpeedEventDispatcher) {
					if (currentGroundMoveSpeedEventDispatcher != null)
							currentGroundMoveSpeedEventDispatcher.MoveSpeedChange -= OnGroundSpeedChange;
					currentGroundMoveSpeedEventDispatcher = newDispatcher;
					if (currentGroundMoveSpeedEventDispatcher != null)
							currentGroundMoveSpeedEventDispatcher.MoveSpeedChange += OnGroundSpeedChange;

					UpdateGroundVelocity ();
					UpdatePlayerMoveSpeed ();
			}
			if((layerMaskGround >> ground.collider.gameObject.layer) % 2 == 1){
				Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer ("player"), LayerMask.NameToLayer ("platforms"), false);
				grounded = true;
			}else
				grounded = false;
		} else {
			grounded = false;
		}

		if (sky && sky.collider.gameObject.layer == LayerMask.NameToLayer("platforms") && (layerMask >> sky.collider.gameObject.layer) % 2 == 1 && Vector2.Distance(sky.point, skyRaycastPoint) < rigidbody2D.velocity.y * Time.deltaTime) {
			Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("player"), sky.collider.gameObject.layer);
		}
				
		Flip ();
	}

	void UpdatePlayerMoveSpeed(){
		if (disabled)
			return;

		Vector2 moveSpeed = new Vector2(axisDirection * maxSpeed, 0f);

		moveSpeed += groundVelocity;	
		
		rigidbody2D.velocity = new Vector2 (moveSpeed.x, rigidbody2D.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs(moveSpeed.x));

	}

	void OnGroundSpeedChange(GameObject groundObject){
		UpdateGroundVelocity ();
		UpdatePlayerMoveSpeed ();
	}

	void UpdateGroundVelocity(){
		if (ground && ground.collider.gameObject.rigidbody2D != null)
			groundVelocity = ground.collider.gameObject.rigidbody2D.velocity;
		else
			groundVelocity = new Vector2 (0f, 0f);
	}
	
	void Flip(){			
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		
		if (axisDirection > 0)
			theScale.x = Mathf.Abs(theScale.x);
		else if(axisDirection < 0)
			theScale.x = Mathf.Abs(theScale.x) * -1;
		
		transform.localScale = theScale;
	}

	public void SetCheckpointPosition(Vector2 position) {
		_spawnPosition = position;
	}

}
