using UnityEngine;
using System.Collections;

public class CameraScale : MonoBehaviour {

	private float startScale;

	void Start () {
		startScale = Camera.main.fieldOfView;
	}
	
	public void SetCameraScale(float scale) {
		Camera.main.fieldOfView = startScale * scale;
	}
}
