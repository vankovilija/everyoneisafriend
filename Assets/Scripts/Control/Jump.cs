using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	private PlayerControl player;
	private bool jump = false;

	public float jumpForce = 12;

	// Use this for initialization
	void Start () {

		player = GetComponent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && player.grounded) {
			jump = true;
		}
	}

	void FixedUpdate(){

		if (jump) {

			GetComponent<AudioSource>().Play();

			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);

			jump = false;
		}
	}
}
