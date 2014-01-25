﻿using UnityEngine;
using System.Collections;

public class NormalJump : Jump {

	public override void init(float timeActive) {
		
	}

	protected override void Setup() {

	}

	protected override void DoJump() {

		GetComponent<AudioSource>().Play();		
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);

	}

}
