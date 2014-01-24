using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	private PlayerControl player;
	private bool fly = false;

	public float flySpeed;
	public float fallSpeed;

	public Fly(){

		flySpeed = 2f;
		fallSpeed = -0.3f;
	}

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {

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
