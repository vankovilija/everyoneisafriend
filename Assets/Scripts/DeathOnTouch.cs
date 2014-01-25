using UnityEngine;
using System.Collections;

public class DeathOnTouch : MonoBehaviour
{	
	public string deathTag = "Player";

	void OnCollisionEnter2D (Collision2D col)
	{
		KillObjectIfTagMatch (col.gameObject);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		KillObjectIfTagMatch (col.gameObject);
	}

	void KillObjectIfTagMatch(GameObject obj){
		if (deathTag == obj.tag) {
			obj.GetComponentInChildren<Animator>().SetTrigger("Die");
				//kill the object
				obj.SendMessage("die");

		}
	}
}

