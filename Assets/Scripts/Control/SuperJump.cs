using UnityEngine;
using System.Collections;

public class SuperJump : Jump {

	public override void init(float timeActive) {

		base.init(timeActive, GetComponent<NormalJump> ());
		cloud = GetComponent<NormalJump> ().cloud;

	}	

	void Update(){
		base.Update ();
		if(rigidbody2D.velocity.y < 0 && !player.grounded)
			player.GetComponentInChildren<Animator>().SetTrigger("JumpDown");
		
	}
	protected override void Setup() {

		jumpForce = 20;

	}

	protected override void DoJump() {

		GetComponent<AudioSource>().Play();		
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);

	}
}
