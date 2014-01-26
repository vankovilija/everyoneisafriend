using UnityEngine;
using System.Collections;

public class BigScale : Scale {

	public override void init(float timeActive) {
		base.init(timeActive, GetComponent<NormalScale> ());
	}

	protected override void Setup () {
		scaleValue = 0.4f;
		massValue = 250.0f;
	}
}
