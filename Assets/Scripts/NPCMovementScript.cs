using UnityEngine;
using System.Collections;

public class NPCMovementScript : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public int minTimer = 1;
	public int maxTimer = 5;
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
	private bool timing = false;
	private bool changeDirection = false;
	private bool settingUp = true;

	private int direction = 1;
	private int wait = 1;
	private float coutdown;

	private Vector2 previousVelocity;

	private float previousPositionX;

	private bool walking = true;

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

	public void StopWalking(){
		if (!walking) return;
		walking = false;
		rigidbody2D.velocity = new Vector2(0f,0f);
	}
	
	public void ContinueWalking(){
		if (walking) return;
		walking = true;
		rigidbody2D.velocity = previousVelocity;
	}

	void Update(){
	
		if (timing) {

			coutdown -= Time.deltaTime;
			if(coutdown <= 0){
				changeDirection = true;
				timing = false;
				wait = 1;
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		if (!walking) return;

		int layerMask = 0;
		for (int i = 0; i < platformLayers.Length; i++) {
			layerMask = layerMask | (1 << LayerMask.NameToLayer(platformLayers[i]));
		}

		fallingLeft = !(Physics2D.Linecast(transform.position, transform.position + bottomLeft - singleUnitHorizontalVector - singleUnitVerticalVector, layerMask));
		fallingRight = !(Physics2D.Linecast(transform.position, transform.position + bottomRight + singleUnitHorizontalVector - singleUnitVerticalVector, layerMask));
		hitLeft = Physics2D.Linecast (transform.position + topLeft - singleUnitHorizontalVector, transform.position + bottomLeft - singleUnitHorizontalVector, layerMask);
		hitRight = Physics2D.Linecast (transform.position + topRight + singleUnitHorizontalVector, transform.position + bottomRight + singleUnitHorizontalVector, layerMask);

		if (settingUp && !fallingLeft && !fallingRight)
				settingUp = false;

		if (changeDirection) {
			direction *= -1;
			changeDirection = false;
		}else{
			if (!settingUp && ((direction == 1 && (fallingRight || hitRight)) || (direction == -1 && (fallingLeft || hitLeft)) || Mathf.Abs(previousPositionX - transform.position.x) <= 0.001f)) {

				if(!timing){
					StartTimer(Random.Range(minTimer,maxTimer));
					wait = 0;
				}

			}
		}

		Vector2 newVelocity = new Vector2 (moveSpeed * direction * wait, rigidbody2D.velocity.y);
		rigidbody2D.velocity = newVelocity;

		if (previousVelocity != newVelocity) {
			MoveSpeedEventDispatcher dispatcher = GetComponent<MoveSpeedEventDispatcher> ();
			if (dispatcher != null) {
					dispatcher.onMoveSpeedChange ();
			}
		}

		previousVelocity = newVelocity;
		previousPositionX = transform.position.x;

		Flip ();
	}

	void Flip(){			
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		
		if (direction > 0 && theScale.x != -1) {
			theScale.x = -1;
		} else if (direction < 0 && theScale.x != 1) {
			theScale.x = 1;
		}
		
		transform.localScale = theScale;
	}

	void StartTimer(float time){

		timing = true;
		coutdown = time;
	}
}
