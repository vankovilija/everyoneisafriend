using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	void die() {
		transform.position = GetComponent<PlayerControl> ().spawnPosition;
	}
}
