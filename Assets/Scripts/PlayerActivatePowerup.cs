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

		(gameObject.AddComponent(powerup) as LimitedTimeComponent).init(timeActive);

	}

}
