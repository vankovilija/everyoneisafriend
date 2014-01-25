using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public Transform leftBound;
	public Transform rightBound;
	public Transform bottomBound;
	public Transform topBound;
	public float smoothTime = 0.3f;
	
	private Vector2 velocity = Vector2.zero;
	internal float widthHalf;
	internal float heightHalf;
	
	void Start () {
		heightHalf = Mathf.Tan(0.5f * ((Mathf.PI * camera.fieldOfView) / 180)) * camera.transform.position.z;
		heightHalf = Mathf.Abs(heightHalf);// / 5;
		widthHalf = heightHalf * camera.aspect;

	}
	
	void Update () {
		
		float newX = transform.position.x;
		float newY = transform.position.y;
		
		if (target)
		{
			newX = target.position.x;
			newY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothTime);
		}

		if (leftBound != null && newX - widthHalf < leftBound.position.x) {
			newX = leftBound.position.x + widthHalf;
		}
		if (rightBound != null && newX + widthHalf > rightBound.position.x) {
			newX = rightBound.position.x - widthHalf;
		}
		if (topBound != null && newY+ heightHalf > topBound.position.y) {
			newY = topBound.position.y - heightHalf;
		}
		if (bottomBound != null && newY - heightHalf < bottomBound.position.y) {
			newY = bottomBound.position.y + heightHalf;
		}

		transform.position = new Vector3(newX, newY, transform.position.z);
		
	}
}
