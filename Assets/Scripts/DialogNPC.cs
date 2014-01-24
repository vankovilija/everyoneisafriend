using UnityEngine;
using System.Collections;

public class DialogNPC : MonoBehaviour {

	public int NPCPowerUp = 0;
	public float stopDistance = 0.2f;

	private GameObject player;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Physics2D.IgnoreLayerCollision (gameObject.layer, player.layer);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = (player.transform.position - transform.position).normalized;

		RaycastHit2D hitToPlayer = Physics2D.Raycast(transform.position, direction);
		RaycastHit2D hitToNPC = Physics2D.Raycast(player.transform.position, direction * -1);

		float distance = Vector3.Distance (hitToPlayer.point, hitToNPC.point);

		if (distance < stopDistance) {
			GetComponent<NPCMovementScript> ().StopWalking ();
		} else {
			GetComponent<NPCMovementScript> ().ContinueWalking ();
		}
	}
}
