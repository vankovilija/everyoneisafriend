using UnityEngine;
using System.Collections;

public class DialogNPC : MonoBehaviour {

	public Vector2 dialogOffset = new Vector2(0f,0f);
	public int NPCPowerUp = 1;
	public float NPCPowerUpTime = 10.0f;
	public float stopDistance = 0.2f;

	private GameObject player;

	private FlashDialogs dialogsInstance = null;

	private bool hasDialog = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Physics2D.IgnoreLayerCollision (gameObject.layer, player.layer);
		Camera.main.GetComponent<MenuCamera> ().Initialized += FlashInitialized;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.A) && hasDialog) {
			
			player.GetComponent<PlayerActivatePowerup> ().ActivatePowerup(Powerups.GetPowerup(NPCPowerUp), NPCPowerUpTime); 
			
		}

		Vector3 direction = (player.transform.position - transform.position).normalized;

		Vector3 rayPoint = transform.position;
		float coliderWidth = GetComponent<BoxCollider2D> ().size.x * 0.5f + 0.2f;
		float sign = Mathf.Sign (direction.x);
		rayPoint.x += sign * coliderWidth;
		RaycastHit2D hitToPlayer = Physics2D.Raycast(rayPoint, direction);

		BoxCollider2D npcColider = GetComponent<BoxCollider2D> ();
		BoxCollider2D playerColider = player.GetComponent<BoxCollider2D> ();

		if(hitToPlayer.collider != null && hitToPlayer.collider.tag != PlayerControl.PLAYER_TAG){
			Rect NPCBound = new Rect (transform.position.x + npcColider.center.x - (npcColider.size.x * 0.5f), transform.position.y + npcColider.center.y - (npcColider.size.y * 0.5f),
			                          npcColider.size.x, npcColider.size.y);
			
			Rect PLAYERBounds = new Rect (player.transform.position.x + playerColider.center.x - (playerColider.size.x * 0.5f), player.transform.position.y + playerColider.center.y - (playerColider.size.y * 0.5f),
			                              playerColider.size.x, playerColider.size.y);
			
			if(NPCBound.Overlaps(PLAYERBounds)){
				GetComponent<NPCMovementScript> ().StopWalking ();

				if(dialogsInstance != null){
					Vector3 spawnPosition = transform.position;
					spawnPosition.x += dialogOffset.x;
					spawnPosition.y += (npcColider.size.y * 0.5f) + dialogOffset.y;
					dialogsInstance.showDialogAt(spawnPosition, NPCPowerUp);
					hasDialog = true;
				}
			}else{
				GetComponent<NPCMovementScript> ().ContinueWalking ();
				if(hasDialog){
					dialogsInstance.removeDialog();
					hasDialog = false;
				}
			}
			return;
		}

		rayPoint = player.transform.position;
		coliderWidth = player.GetComponent<BoxCollider2D> ().size.x * 0.5f + 0.2f;
		direction *= -1;
		sign = Mathf.Sign (direction.x);
		rayPoint.x += sign * coliderWidth;
		RaycastHit2D hitToNPC = Physics2D.Raycast(rayPoint, direction);

		if (hitToNPC.collider != null && hitToNPC.collider.gameObject != gameObject) {
			Rect NPCBound = new Rect (transform.position.x + npcColider.center.x - (npcColider.size.x * 0.5f), transform.position.y + npcColider.center.y - (npcColider.size.y * 0.5f),
			                          npcColider.size.x, npcColider.size.y);
			
			Rect PLAYERBounds = new Rect (player.transform.position.x + playerColider.center.x - (playerColider.size.x * 0.5f), player.transform.position.y + playerColider.center.y - (playerColider.size.y * 0.5f),
			                              playerColider.size.x, playerColider.size.y);
			
			if(NPCBound.Overlaps(PLAYERBounds)){
				GetComponent<NPCMovementScript> ().StopWalking ();
				Debug.Log("stop");
				if(dialogsInstance != null){
					Vector3 spawnPosition = transform.position;
					spawnPosition.x += dialogOffset.x;
					spawnPosition.y += (npcColider.size.y * 0.5f) + dialogOffset.y;
					dialogsInstance.showDialogAt(spawnPosition, NPCPowerUp);
					hasDialog = true;
				}
			}else{
				GetComponent<NPCMovementScript> ().ContinueWalking ();
				if(hasDialog){
					dialogsInstance.removeDialog();
					hasDialog = false;
				}
			}
			return;
		}


		float distance = Vector3.Distance (hitToPlayer.point, hitToNPC.point);

		if (distance < stopDistance) {
			GetComponent<NPCMovementScript> ().StopWalking ();
			Debug.Log("stop");
			if(dialogsInstance != null){
				Vector3 spawnPosition = transform.position;
				spawnPosition.x += dialogOffset.x;
				spawnPosition.y += (npcColider.size.y * 0.5f) + dialogOffset.y;
				dialogsInstance.showDialogAt(spawnPosition, NPCPowerUp);
				hasDialog = true;
			}
		} else {
			Rect NPCBound = new Rect (transform.position.x + npcColider.center.x - (npcColider.size.x * 0.5f), transform.position.y + npcColider.center.y - (npcColider.size.y * 0.5f),
			                          npcColider.size.x, npcColider.size.y);
			
			Rect PLAYERBounds = new Rect (player.transform.position.x + playerColider.center.x - (playerColider.size.x * 0.5f), player.transform.position.y + playerColider.center.y - (playerColider.size.y * 0.5f),
			                              playerColider.size.x, playerColider.size.y);
			
			if(NPCBound.Overlaps(PLAYERBounds)){
				GetComponent<NPCMovementScript> ().StopWalking ();
				Debug.Log("stop");
				if(dialogsInstance != null){
					Vector3 spawnPosition = transform.position;
					spawnPosition.x += dialogOffset.x;
					spawnPosition.y += (npcColider.size.y * 0.5f) + dialogOffset.y;
					dialogsInstance.showDialogAt(spawnPosition, NPCPowerUp);
					hasDialog = true;
				}
			}else{
				GetComponent<NPCMovementScript> ().ContinueWalking ();
				if(hasDialog){
					dialogsInstance.removeDialog();
					hasDialog = false;
				}
			}
		}

	}

	void FlashInitialized(MenuCamera camera)
	{
		dialogsInstance = camera.dialogs;
	}
}
