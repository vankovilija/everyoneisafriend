using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	private PlayerControl player;


	public float flapTime = 0.1f;
	public float flapTimeDistance = 0.2f;
	public float flapLiftTime = 0.4f;
	public float fallSpeed = 0.05f;

	public float flapForce = 10f;

	private bool fly;

	private float currentTime = 0;
	private int currentState = 0; //0 - stand, 1 - flap up, 2 - flap down, 3 - flap break

//	void init(float timeLimit, MonoBehaviour restoreScript, float flySpeed, float fallSpeed){
//		base.init(timeLimit, restoreScript);
//		this.flySpeed = flySpeed;
//		this.fallSpeed = -fallSpeed;
//	}

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		//base.Update ();
//		if (timingUp) {
//			countUp -= Time.deltaTime;
//			if(countUp <= 0){
//				timingUp = false;
//			}
//		}
//		if (timingPush) {
//			
//			countUp -= Time.deltaTime;
//			if(countUp <= 0){
//				timingUp = true;
//				timingPush = false;
//			}
//		}
		currentTime += Time.deltaTime;
		switch (currentState) {
		case 1:
			if(currentTime >= flapTime){
				currentState = 2;
				currentTime = 0;
			}
			break;
		case 2:
			if(currentTime >= flapLiftTime){
				currentState = 3;
				currentTime = 0;
			}
			break;
		case 3:
			if(currentTime >= flapTimeDistance){
				currentState = 0;
				currentTime = 0;
			}
			break;
		}
		fly = Input.GetButton ("Jump");
		
		if (fly && currentState == 0) {
			currentState = 1;
			currentTime = 0;
		}
	}

	void FixedUpdate(){
//		if (fly) {
//			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, flySpeed);
//		}
//		if (timingUp) {
//			print ("LETA");
//			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, flySpeed);
//		}else if(timingPush){
//			print("PUSH");
//			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fallSpeed);
//		}else{
//			if (fly) {
//				if(player.grounded){
//					StartUpTimer();
//				}else{
//					StartPushTimer();
//				}
//
//			}else if(!player.grounded){
//
//				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -fallSpeed);
//			}
//		}

		switch (currentState) {
		case 0:
		case 3:
			if(!player.grounded){
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -fallSpeed);
			}
			break;
		case 1:
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -1.5f * fallSpeed);
			break;
		case 2:
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, flapForce);
			break;		
		}

	}
//
//	void StartUpTimer(){
//		timingUp = true;
//		timingPush = false;
//		countUp = upTime;
//	}
//
//	void StartPushTimer(){
//		timingPush = true;
//		timingUp = false;
//		countUp = pushTime;
//	}
}
