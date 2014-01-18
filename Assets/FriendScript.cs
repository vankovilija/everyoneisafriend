using UnityEngine;
using System.Collections;

public class FriendScript : MonoBehaviour {

	public Texture2D happyFace;
	public Texture2D angryFace;
	
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

	// Use this for initialization
	void Start () {
		state = FriendState.angry;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {

	}
	
	
}
