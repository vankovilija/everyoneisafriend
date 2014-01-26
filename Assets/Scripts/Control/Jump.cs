﻿using UnityEngine;
using System.Collections;

public abstract class Jump : LimitedTimeComponent {

	internal PlayerControl player;
	private bool jump = false;

	public float jumpForce = 12;
	public GameObject cloud;

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

	public void FixedUpdate(){

		if (jump) {
			player.GetComponentInChildren<Animator>().SetTrigger("JumpUp");
			GameObject dust = Instantiate(cloud, player.transform.position, Quaternion.Euler(0f,0f,0f)) as GameObject;
			dust.transform.localScale = player.transform.localScale;
			DoJump ();
			GetComponent<PlayerControl>().ForceUpdate();
			jump = false;
		}

	}

	protected abstract void Setup();
	protected abstract void DoJump();
}
