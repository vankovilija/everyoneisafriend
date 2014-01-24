using UnityEngine;
using System.Collections;

public class LimitedTimeComponent : MonoBehaviour {

	private float timeLimit;
	private MonoBehaviour restoreScript;

	private float timeSpend;

	public LimitedTimeComponent(float timeLimit, MonoBehaviour restoreScript) {
		this.timeLimit = timeLimit;
		if (restoreScript is LimitedTimeComponent) {
			restoreScript = (restoreScript as LimitedTimeComponent).restoreScript;
		}
		this.restoreScript = restoreScript;
		restoreScript.enabled = false;
		timeSpend = 0;
	}

	void Update () {
		timeSpend += Time.deltaTime;
		if (timeSpend >= timeLimit) {
			restoreScript.enabled = true;
			Destroy(this);
		}
	}
}
