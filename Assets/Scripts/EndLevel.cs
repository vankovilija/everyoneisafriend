using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	public string playerTag = "Player";
		
	public float timerForNextLevel;

	private float time = 0;
	private bool nextLevel = false;
	private GameSetup gameSetup;

	void Start() {
		gameSetup = GameObject.Find("_GM").GetComponent<GameSetup>();
	}

	// Update is called once per frame
	void Update () {
		if (nextLevel) {
			time += Time.deltaTime;
			if (time >= timerForNextLevel) {
				LoadNextLevel ();
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		ObjectOnFinishLine (col.gameObject);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		ObjectOnFinishLine (col.gameObject);
	}

	private void ObjectOnFinishLine (GameObject obj) {
		if (obj.tag == playerTag) {
			if(gameSetup.totalConfidence < 50){
				Vector3 showPoint = transform.position;
				showPoint.y += GetComponent<BoxCollider2D>().size.y / 2f;
				Camera.main.GetComponent<MenuCamera>().dialogs.showMoreConfidenceAt(showPoint);
				Debug.Log(showPoint);
			}else{
				if (!nextLevel) {
					gameSetup.StopCountLevelTime ();

					obj.GetComponentInChildren<Animator> ().SetTrigger("NextLevel");
					obj.GetComponent<PlayerControl> ().disabled = true;

					Rigidbody2D playerBody = obj.GetComponent<Rigidbody2D> ();
					playerBody.velocity = new Vector2 (0.0f, playerBody.velocity.y);

					nextLevel = true;

					if(Application.loadedLevel == Application.levelCount - 1){
						Application.LoadLevel(0);
					}else{
						Application.LoadLevel(Application.loadedLevel + 1);
					}
				}
			}

		}
	}

	private void LoadNextLevel() {
		Debug.Log("Next Level!!!");
//		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
