using UnityEngine;
using System.Collections;

public class ConfidenceCollectable : MonoBehaviour {

	private GameSetup gm;

	public enum ConfidenceType{
		Shard,
		Artifact
	};

	public ConfidenceType confidenceType;

	void Start(){
		gm = GameObject.Find ("_GM").GetComponent<GameSetup>();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		OnCollect (col.gameObject);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		OnCollect (col.gameObject);
	}
	
	void OnCollect(GameObject obj) {
		gm.CollectConfidence (confidenceType);
		Destroy (gameObject);
	}
}
