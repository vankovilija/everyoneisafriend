using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public string playerTag = "Player";
	public int orderId = 0;
	public GameObject flame;

	private bool avaible = true;
	private GameSetup gameSetup;
	private Transform flamePosition;

	void Start () {
		gameSetup = GameObject.Find("_GM").GetComponent<GameSetup> ();
		if (gameSetup) {
			gameSetup.CheckpointReach += CheckpointReach;
		}
		flamePosition = transform.FindChild("FlamePosition").transform;
	}

	private void CheckpointReach(int id) {
		if (id >= orderId) {
			DisableCheckpoint ();
		}
	}

	private void DisableCheckpoint() {
		if (avaible) {
		avaible = false;
			if (flame) {
				GameObject flameObject = Instantiate(flame, flamePosition.position, Quaternion.Euler(0, 0, 0)) as GameObject;
				flameObject.transform.parent = gameObject.transform;
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		ObjectOnCheckpoint (col.gameObject);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		ObjectOnCheckpoint (col.gameObject);
	}

	void ObjectOnCheckpoint(GameObject obj) {
		if (obj.tag == playerTag && avaible) {
			PlayerControl player = obj.GetComponent<PlayerControl> ();
			if (player) {
				GetComponent<AudioSource>().Play();
				if (gameSetup) {
					gameSetup.OnCheckpoint(orderId);
				}
				player.SetCheckpointPosition(transform.position);
			}
		}
	}

}
