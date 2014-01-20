using UnityEngine;
using System.Collections;

public class FriendMovementScript : MonoBehaviour {

	public float moveSpeed = 5.0f;

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

	// Use this for initialization
	void Start () {
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

		fallingLeft = !(Physics2D.Linecast(transform.position, transform.position + bottomLeft - singleUnitHorizontalVector - singleUnitVerticalVector, 1 << LayerMask.NameToLayer("platforms")));
		fallingRight = !(Physics2D.Linecast(transform.position, transform.position + bottomRight + singleUnitHorizontalVector - singleUnitVerticalVector, 1 << LayerMask.NameToLayer("platforms")));
		hitLeft = Physics2D.Linecast (transform.position + topLeft - singleUnitHorizontalVector, transform.position + bottomLeft - singleUnitHorizontalVector, 1 << LayerMask.NameToLayer ("platforms"));
		hitRight = Physics2D.Linecast (transform.position + topRight + singleUnitHorizontalVector, transform.position + bottomRight + singleUnitHorizontalVector, 1 << LayerMask.NameToLayer ("platforms"));

		if ((direction == 1 && (fallingRight || hitRight)) || (direction == -1 && (fallingLeft || hitLeft))) {
			direction *= -1;
		}

		rigidbody2D.velocity = new Vector2 (moveSpeed * direction, rigidbody2D.velocity.y);
	}
}
