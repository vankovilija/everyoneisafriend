using UnityEngine;
using System.Collections;

public class NormalJump : Jump {

	protected override void init() {
		jumpForce = 12.0f;
	}

	protected override void DoJump() {

		GetComponent<AudioSource>().Play();		
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);

	}

}
