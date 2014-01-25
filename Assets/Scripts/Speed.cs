using UnityEngine;
using System.Collections;

public abstract class Speed : LimitedTimeComponent {

	protected PlayerControl player;
	protected float movementSpeed;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerControl> ();
		Setup ();
	}
	
	// Update is called once per frame
	new public void Update () {
		base.Update();
		CheckMovementSpeed ();
	}

	protected abstract void Setup();	
	protected abstract void CheckMovementSpeed();

}
