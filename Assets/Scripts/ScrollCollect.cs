using UnityEngine;
using System.Collections;

public class ScrollCollect : MonoBehaviour {

	public int scrollID = 1;
	private GameSetup gameSetup;

	// Use this for initialization
	void Start () {
		gameSetup = GameObject.Find ("_GM").GetComponent<GameSetup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D obj){
	
		if (obj.tag == "Player") {
			gameSetup.PickupScroll(gameObject);
			Destroy(this.gameObject);
		}
	}
}
