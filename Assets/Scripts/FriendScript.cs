using UnityEngine;
using System.Collections;

public class FriendScript : MonoBehaviour {

	public Sprite happyFace;
	public Sprite angryFace;
	
	public FoodType[] foodTypes;

	public float happyMovementSpeed;
	public float angryMovementSpeed;
	public float veryAngryMovementSpeed;

	public float veryAngryTime;

	private enum FriendState {
		happy,
		angry,
		veryAngry
	};

	private FoodType currentFoodType;
	private FriendState state;
	private float timeInState;

	private SpriteRenderer render;
	private FriendMovementScript movement;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		state = FriendState.angry;
		movement = GetComponent<FriendMovementScript> ();
		currentFoodType = foodTypes[Random.Range(0, foodTypes.Length)];
	}
	
	// Update is called once per frame
	void Update () {

		timeInState += Time.deltaTime;
		if (state == FriendState.veryAngry && timeInState > veryAngryTime) {
			goAngry();
		}

	}

	void goHappy() {

		if (state == FriendState.angry) {
			state = FriendState.happy;
			movement.moveSpeed = happyMovementSpeed;
			render.sprite = happyFace;
			timeInState = 0;
		}

	}

	void goVeryAngry() {

		if (state == FriendState.angry) {
			state = FriendState.veryAngry;
			movement.moveSpeed = veryAngryMovementSpeed;
			render.sprite = happyFace;
			timeInState = 0;
		}

	}

	void goAngry() {

		if (state == FriendState.veryAngry) {
			state = FriendState.angry;
			movement.moveSpeed = angryMovementSpeed;
			render.sprite = happyFace;
			timeInState = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			FoodType bulletType = coll.gameObject.GetComponent<Bullet> ().type;
			if (bulletType == currentFoodType) {
				goHappy();
			} else {
				goVeryAngry();
			}
		}
	}
	
	
}
