using UnityEngine;
using System.Collections;

public class NormalScale : Scale {

	public override void init(float timeActive) {

	}

	protected override void Setup () {
		scaleValue = 1.0f;
		massValue = 250.0f;
	}

}
