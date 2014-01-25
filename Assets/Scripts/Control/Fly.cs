using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	private PlayerControl player;
	private bool fly = false;
	private bool timingUp = false;
	private bool timingPush = false;
	private float countUp;

	public float upTime = 0.7f;
	public float pushTime = 0.7f;
	public float flySpeed = 5f;
	public float fallSpeed = -0.3f;


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
		if (timingUp) {

			countUp -= Time.deltaTime;
			if(countUp <= 0){
				timingUp = false;
			}
		}
		if (timingPush) {
			
			countUp -= Time.deltaTime;
			if(countUp <= 0){
				timingUp = true;
				timingPush = false;
			}
		}
	}

	void FixedUpdate(){

		fly = Input.GetButtonDown ("Jump");
		if (timingUp) {
			print ("LETA");
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, flySpeed);
		}else if(timingPush){
			print("PUSH");
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 2*fallSpeed);
		}else{
			if (fly) {
				if(player.ground){
					StartUpTimer();
				}else{
					StartPushTimer();
				}

			}else if(!player.grounded){

				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fallSpeed);
			}
		}

	}
	void StartUpTimer(){
		timingUp = true;
		countUp = upTime;
	}
	void StartPushTimer(){
		timingPush = true;
		countUp = pushTime;
	}
}
