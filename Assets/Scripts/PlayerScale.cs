using UnityEngine;
using System.Collections;

public class PlayerScale : LimitedTimeComponent {

	private VectorInterpolator interpolatorPosition;
	private VectorInterpolator interpolatorScale;

	void Start () {

	}

	new void Update () {
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

		if (rigidbody2D) {
			rigidbody2D.mass = mass;
		}

		interpolatorPosition = new VectorInterpolator ();
		interpolatorScale = new VectorInterpolator ();

		Vector3 endPosition = transform.position;
		Vector3 endScale = transform.localScale;

		Bounds bounds = GameObjectBounds.GetBounds(gameObject);
		Debug.Log(bounds.center.y - transform.position.y);

		float offset = ((scale * bounds.size.y / transform.localScale.y) - bounds.size.y) * (0.5f - bounds.center.y + transform.position.y);
		endPosition = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);

		endScale = new Vector3(Mathf.Sign(transform.localScale.x) * scale, Mathf.Sign(transform.localScale.y) * scale, transform.localScale.z);

		interpolatorPosition.setInterpolator(transform.position, endPosition, interpolationTime);
		interpolatorScale.setInterpolator(transform.localScale, endScale, interpolationTime);

	}

}
