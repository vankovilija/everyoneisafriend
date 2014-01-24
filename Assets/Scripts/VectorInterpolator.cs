using UnityEngine;
using System.Collections;

public class VectorInterpolator {

	private Vector3 start;
	private Vector3 end;
	private float timeSpend = 0;
	private float length = 0;

	public VectorInterpolator() {

	}

	public void setInterpolator(Vector3 start, Vector3 end, float length) {
		this.start = start;
		this.end = end;
		this.length = length;
		timeSpend = 0;
	}

	public void Update (float deltaTime) {
		timeSpend += deltaTime;
		if (timeSpend > length)
			timeSpend = length;
	}

	public Vector3 CurrentPosition() {
		return Vector3.Lerp(start, end, timeSpend/length);
	}

	public bool Finished() {
		return (timeSpend >= length);
	}
}
