using UnityEngine;
using System.Collections;

public class BigScale : Scale {

	public override void init(float timeActive) {
		base.init(timeActive, GetComponent<NormalScale> ());
	}

	protected override void Setup () {
		scaleValue = 1.5f;
		massValue = 350.0f;
	}
}
