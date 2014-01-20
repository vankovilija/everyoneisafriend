using UnityEngine;
using System.Collections;

public class FriendScript : MonoBehaviour {

	public Sprite happyFace;
	public Sprite angryFace;
	
	public FoodType foodType;

	public float happyMovementSpeed;
	public float angryMovementSpeed;
	public float veryAngryMovementSpeed;

	public float veryAngryTime;

	private enum FriendState {
		happy,
		angry,
		veryAngry
	};

	private FriendState state;
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

		if (state != FriendState.happy) {
			state = FriendState.happy;
			movement.moveSpeed = happyMovementSpeed;
			render.sprite = happyFace;
			timeInState = 0;
			if(gameObject.GetComponent<DeathOnTouch>() != null)
				Destroy(gameObject.GetComponent<DeathOnTouch>());
		}

	}

	void goAngry() {

		if (state != FriendState.angry) {
			state = FriendState.angry;
			movement.moveSpeed = angryMovementSpeed;
			render.sprite = angryFace;
			timeInState = 0;
			gameObject.AddComponent<DeathOnTouch>();
		}

	}

	void goVeryAngry() {

		if (state != FriendState.veryAngry) {
			state = FriendState.veryAngry;
			movement.moveSpeed = veryAngryMovementSpeed;
			render.sprite = angryFace;
			timeInState = 0;
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
