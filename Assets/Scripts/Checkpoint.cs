using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public string playerTag = "Player";
	public int orderId = 0;
	public Sprite disableSprite;

	private bool avaible = true;
	private GameSetup gameSetup;

	void Start () {
		gameSetup = GameObject.Find("_GM").GetComponent<GameSetup> ();
		if (gameSetup) {
			gameSetup.CheckpointReach += CheckpointReach;
		}
	}

	private void CheckpointReach(int id) {
		if (id >= orderId) {
			DisableCheckpoint ();
		}
	}

	private void DisableCheckpoint() {
		avaible = false;
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer) {
			spriteRenderer.sprite = disableSprite;
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
				if (gameSetup) {
					gameSetup.OnCheckpoint(orderId);
				}
				player.SetCheckpointPosition(transform.position);
			}
		}
	}

}
