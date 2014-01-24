using UnityEngine;
using System.Collections;

public class PlayerScale : LimitedTimeComponent {

	private VectorInterpolator interpolatorPosition;
	private VectorInterpolator interpolatorScale;

	void Start () {

	}

	void Update () {
		base.Update ();
		if (!interpolatorScale.Finished ()) {
			interpolatorScale.Update(Time.deltaTime);
			interpolatorPosition.Update(Time.deltaTime);
			transform.localScale = interpolatorScale.CurrentPosition ();
			transform.position = interpolatorPosition.CurrentPosition ();
		}
	}

	public void init(float timeLimit, MonoBehaviour restoreScript, float scale, float mass, float interpolationTime)
	{
		base.init(timeLimit, restoreScript);
		interpolatorPosition = new VectorInterpolator ();
		interpolatorScale = new VectorInterpolator ();
		Vector3 endPosition = transform.position;
		Vector3 endScale = transform.localScale;
		BoxCollider2D collider = GetComponent<BoxCollider2D> ();
		if (collider) {
			float offset = ((scale * collider.size.y) - collider.size.y) / 2.0f;
			endPosition = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
		}
		endScale = new Vector3(Mathf.Sign(transform.localScale.x) * scale, Mathf.Sign(transform.localScale.y) * scale, transform.localScale.z);
		if (rigidbody2D) {
			rigidbody2D.mass = mass;
		}
		interpolatorPosition.setInterpolator(transform.position, endPosition, interpolationTime);
		interpolatorScale.setInterpolator(transform.localScale, endScale, interpolationTime);

	}

}
