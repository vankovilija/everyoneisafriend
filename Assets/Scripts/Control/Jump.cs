using UnityEngine;
using System.Collections;

public abstract class Jump : LimitedTimeComponent {

	private PlayerControl player;
	private bool jump = false;

	public float jumpForce = 12;

	// Use this for initialization
	void Start () {

		player = GetComponent<PlayerControl> ();
		Setup();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();
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

	protected abstract void Setup();
	protected abstract void DoJump();
}
