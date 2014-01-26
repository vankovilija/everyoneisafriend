using UnityEngine;
using System.Collections;

public class SuperJump : Jump {

	public override void init(float timeActive) {

		base.init(timeActive, GetComponent<NormalJump> ());
		cloud = GetComponent<NormalJump> ().cloud;

	}	
	
	protected override void Setup() {

		jumpForce = 20;

	}

	protected override void DoJump() {

		GetComponent<AudioSource>().Play();		
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);

	}
}
