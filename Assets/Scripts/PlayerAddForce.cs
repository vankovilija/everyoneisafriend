using UnityEngine;
using System.Collections;

public class PlayerAddForce : MonoBehaviour {

	public float movementDisableTime = 0.05f;

	private bool disableMovement = false;
	private float timeSpend = 0.0f;
	private PlayerControl player;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerControl> ();
	}

	void Update ()
	{
		if (disableMovement)
		{
			timeSpend += Time.deltaTime;
			if (timeSpend >= movementDisableTime)
			{
				disableMovement = false;
				player.enabled = true;
			}
		}
	}

	public void AddForce(Vector2 force) 
	{
		if (player.enabled) {
			player.enabled = false;
			disableMovement = true;
			timeSpend = 0.0f;
			if (rigidbody2D != null) {
				rigidbody2D.AddForce(force);
			}
		}
	}
}
