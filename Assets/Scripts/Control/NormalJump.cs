using UnityEngine;
using System.Collections;

public class NormalJump : Jump {

	private float previous = 0;

	public override void init(float timeActive) {
		
	}

	protected override void Setup() {

	}

	protected override void DoJump() {

		GetComponent<AudioSource>().Play();		
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);


	}

}
