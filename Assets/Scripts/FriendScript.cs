﻿using UnityEngine;
using System.Collections;

public class FriendScript : MonoBehaviour {

	public Sprite happyFace;
	public Sprite angryFace;
	
	public FoodType foodType;

	public float happyMovementSpeed;
	public float angryMovementSpeed;
	public float angryPushForce = 20.0f;
	public float veryAngryMovementSpeed;

	public float veryAngryTime;

	public delegate void EventHandler (GameObject friend, FriendState state);
	public event EventHandler ChangeState;

	private FriendState _state;
	internal FriendState state{
		get{
			return _state;
		}
		set {
			if(ChangeState != null)
				ChangeState(gameObject, value);
			_state = value;
		}
	}
	private float timeInState;

	private SpriteRenderer render;
	private FriendMovementScript movement;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		movement = GetComponent<FriendMovementScript> ();
		goAngry ();
	}
	
	// Update is called once per frame
	void Update () {

		timeInState += Time.deltaTime;
		if (state == FriendState.veryAngry && timeInState > veryAngryTime) {
			goAngry();
		}

	}

	void goHappy() {
		timeInState = 0;
		if (state != FriendState.happy) {
			state = FriendState.happy;
			movement.moveSpeed = happyMovementSpeed;
			render.sprite = happyFace;
			if(gameObject.GetComponent<DeathOnTouch>() != null)
				Destroy(gameObject.GetComponent<DeathOnTouch>());
			if(gameObject.GetComponent<PushOnTouch>() != null)
				Destroy(gameObject.GetComponent<PushOnTouch>());
		}

	}

	void goAngry() {
		timeInState = 0;
		if (state != FriendState.angry) {
			state = FriendState.angry;
			movement.moveSpeed = angryMovementSpeed;
			render.sprite = angryFace;
			if(gameObject.GetComponent<DeathOnTouch>() != null)
				Destroy(gameObject.GetComponent<DeathOnTouch>());
			gameObject.AddComponent<PushOnTouch>().pushForce = angryPushForce;
		}

	}

	void goVeryAngry() {
		timeInState = 0;
		if (state != FriendState.veryAngry) {
			state = FriendState.veryAngry;
			movement.moveSpeed = veryAngryMovementSpeed;
			render.sprite = angryFace;
			if(gameObject.GetComponent<PushOnTouch>() != null)
				Destroy(gameObject.GetComponent<PushOnTouch>());
			gameObject.AddComponent<DeathOnTouch>();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			FoodType bulletType = coll.gameObject.GetComponent<Bullet> ().type;
			if (bulletType == foodType) {
				goHappy();
			} else {
				goVeryAngry();
			}
		}
	}
	
	
}
