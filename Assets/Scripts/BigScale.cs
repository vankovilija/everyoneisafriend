using UnityEngine;
using System.Collections;

public class BigScale : Scale {

	public override void init(float timeActive) {
		base.init(timeActive, GetComponent<NormalScale> ());
	}

	protected override void Setup () {
		scaleValue = 2f;
		massValue = 5000.0f;
	}
}
