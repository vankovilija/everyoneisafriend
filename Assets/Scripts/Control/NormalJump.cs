using UnityEngine;
using System.Collections;

public class NormalJump : Jump {

	private float previous = 0;

	public override void init(float timeActive) {
		
	}
	void Update(){
		base.Update ();
		if(rigidbody2D.velocity.y < 0 && !player.grounded)
			player.GetComponentInChildren<Animator>().SetTrigger("JumpDown");

	}
	protected override void Setup() {

	}

	protected override void DoJump() {

		GetComponent<AudioSource>().Play();		
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);


	}

}
