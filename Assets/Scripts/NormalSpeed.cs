using UnityEngine;
using System.Collections;

public class NormalSpeed : Speed {

	public override void init(float timeActive) {

		
	}

	protected override void Setup() {
			
		movementSpeed = 5f;

	}
	
	protected override void CheckMovementSpeed() {

		if (player.maxSpeed != movementSpeed)
			player.maxSpeed = movementSpeed;

	}
}
