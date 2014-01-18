using UnityEngine;
using System.Collections;

public class FriendMovementScript : MonoBehaviour {

	public float moveSpeed = 5.0f;

	private Transform leftPoint;
	private Transform rightPoint;
	private Transform bottomLeftPoint;
	private Transform bottomRightPoint;

	private bool fallingLeft;
	private bool fallingRight;
	private bool hitLeft;
	private bool hitRight;

	private int direction = 1;

	// Use this for initialization
	void Start () {
		leftPoint = transform.FindChild ("leftCheckPoint").transform;
		rightPoint = transform.FindChild ("rightCheckPoint").transform;
		bottomLeftPoint = transform.FindChild ("bottomLeftCheckPoint").transform;
		bottomRightPoint = transform.FindChild ("bottomRightCheckPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {

		fallingLeft = !(Physics2D.Linecast(transform.position, bottomLeftPoint.position, 1 << LayerMask.NameToLayer("platforms")));
		fallingRight = !(Physics2D.Linecast(transform.position, bottomRightPoint.position, 1 << LayerMask.NameToLayer("platforms")));
		hitLeft = Physics2D.Linecast (transform.position, leftPoint.position, 1 << LayerMask.NameToLayer ("platforms"));
		hitRight = Physics2D.Linecast (transform.position, rightPoint.position, 1 << LayerMask.NameToLayer ("platforms"));

		if ((direction == 1 && (fallingRight || hitRight)) || (direction == -1 && (fallingLeft || hitLeft))) {
			direction *= -1;
		}

		rigidbody2D.velocity = new Vector2 (moveSpeed * direction, rigidbody2D.velocity.y);
	}
}
