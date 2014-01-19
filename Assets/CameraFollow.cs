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
	private float widthHalf	;
	private float heightHalf;
	
	void Start () {
		heightHalf = camera.orthographicSize;
		widthHalf = heightHalf * camera.aspect;
	}
	
	void FixedUpdate () {
		
		float newX = transform.position.x;
		float newY = transform.position.y;
		
		if (target)
		{
			newX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothTime);
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

		Debug.Log (newX + " - " + newY);

		transform.position = new Vector3(newX, newY, transform.position.z);
		
	}
}
