using UnityEngine;
using System.Collections;

public abstract class Jump : LimitedTimeComponent {

	private PlayerControl player;
	private bool jump = false;

	public float jumpForce = 12;

	// Use this for initialization
	void Start () {

		player = GetComponent<PlayerControl> ();
		init();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && player.grounded) {
			jump = true;
		}
	}

	void FixedUpdate(){

		if (jump) {
			DoJump ();
			jump = false;
		}

	}

	protected abstract void init();
	protected abstract void DoJump();
}
