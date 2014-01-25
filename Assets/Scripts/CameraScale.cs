using UnityEngine;
using System.Collections;

public class CameraScale : MonoBehaviour {

	private float startScale;

	void Start () {
		startScale = Camera.main.orthographicSize;
	}
	
	public void SetCameraScale(float scale) {
		Camera.main.orthographicSize = startScale * scale;
	}
}
