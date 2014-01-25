using UnityEngine;
using System.Collections;

public class KillPlayerWithComponent : MonoBehaviour {

	public string deathTag = "Player";
	public Object killComponent;
	
	void OnTriggerEnter2D (Collider2D col) {

		KillObject (col.gameObject);

	}

	void OnTriggerStay2D (Collider2D col) {

		KillObject (col.gameObject);

	}
	
	void KillObject(GameObject obj){
		if (deathTag == obj.tag) {
			MonoBehaviour component = obj.GetComponent (killComponent.name) as MonoBehaviour;
			if (component && component.enabled) {
				//kill the object
				obj.SendMessage("die");
			}			
		}
	}

}
