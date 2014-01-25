using UnityEngine;
using System.Collections;

public class LimitedTimeComponent : MonoBehaviour {

	private float timeLimit;
	private MonoBehaviour restoreScript;

	private float timeSpend;

	public void init(float timeLimit, MonoBehaviour restoreScript) {
		this.timeLimit = timeLimit;
		if (restoreScript) {
			if (restoreScript is LimitedTimeComponent) {
				restoreScript = (restoreScript as LimitedTimeComponent).restoreScript;
			}
			restoreScript.enabled = false;
		}
		this.restoreScript = restoreScript;
		timeSpend = 0;
	}

	public void Update () {
		timeSpend += Time.deltaTime;
		if (timeLimit > 0 && timeSpend >= timeLimit) {
			if (restoreScript) {
				restoreScript.enabled = true;
			}
			Destroy(this);
		}
	}
}
