using UnityEngine;
using System.Collections;

public class CameraScale : MonoBehaviour {

	private float startScale;
	private CameraFollow cameraFollow;

	void Start () {
		startScale = Camera.main.fieldOfView;
		cameraFollow = GetComponent<CameraFollow> ();
	}
	
	public void SetCameraScale(float scale) {
		Camera.main.fieldOfView = startScale * scale;

		cameraFollow.heightHalf = Mathf.Tan(0.5f * ((Mathf.PI * camera.fieldOfView) / 180)) * camera.transform.position.z;
		cameraFollow.heightHalf = Mathf.Abs(cameraFollow.heightHalf);// / 5;
		cameraFollow.widthHalf = cameraFollow.heightHalf * camera.aspect;
		Debug.Log (cameraFollow.widthHalf + " - " + cameraFollow.heightHalf);
	}
}
