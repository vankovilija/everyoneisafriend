using UnityEngine;
using System.Collections;

public class FastSpeed : Speed {

	public override void init(float timeActive) {
		Debug.Log(timeActive);
		Debug.Log(GetComponent<NormalSpeed> ());
		base.init(timeActive, GetComponent<NormalSpeed> ());
	}
	
	protected override void Setup() {
		
		movementSpeed = 8f;
		
	}
	
	protected override void CheckMovementSpeed() {
		
		if (player.maxSpeed != movementSpeed)
			player.maxSpeed = movementSpeed;
		
	}
}
