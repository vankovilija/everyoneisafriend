using UnityEngine;
using System.Collections;

public class Fly : LimitedTimeComponent {

	private PlayerControl player;
	private bool fly = false;

	public float flySpeed;
	public float fallSpeed;

	void init(float timeLimit, MonoBehaviour restoreScript, float flySpeed, float fallSpeed){
		base.init(timeLimit, restoreScript);
		this.flySpeed = flySpeed;
		this.fallSpeed = fallSpeed;
	}

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	void FixedUpdate(){

		fly = Input.GetButton ("Jump");

		if (fly) {
		
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, flySpeed);

		}else if(!player.grounded){

			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fallSpeed);
		}

	}
}
