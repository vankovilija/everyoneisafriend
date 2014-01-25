using UnityEngine;
using System.Collections;

public abstract class Jump : LimitedTimeComponent {

	internal PlayerControl player;
	private bool jump = false;

	public float jumpForce = 12;

	// Use this for initialization
	void Start () {

		player = GetComponent<PlayerControl> ();
		Setup();
	}
	
	// Update is called once per frame
	public new void Update () {
		base.Update ();
		if (Input.GetButtonDown ("Jump") && player.grounded) {
			jump = true;
		}
	}

	void FixedUpdate(){

		if (jump) {
			player.GetComponentInChildren<Animator>().SetTrigger("JumpUp");
			DoJump ();
			jump = false;
		}

	}

	protected abstract void Setup();
	protected abstract void DoJump();
}
