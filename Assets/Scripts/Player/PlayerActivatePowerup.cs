using UnityEngine;
using System.Collections;

public class PlayerActivatePowerup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivatePowerup(string powerup, float timeActive) {

		if (GetComponent(powerup)) {
			(GetComponent(powerup) as LimitedTimeComponent).init(timeActive);
		} else {
			(gameObject.AddComponent(powerup) as LimitedTimeComponent).init(timeActive);
		}

		Vector3 canPos = transform.position;
		canPos.y += GetComponent<BoxCollider2D>().size.y + 0.2f;
		Camera.main.GetComponent<MenuCamera>().dialogs.showCanAt(canPos);

	}

}
