using UnityEngine;
using System.Collections;

public abstract class Scale : LimitedTimeComponent {

	public float scaleValue;
	public float massValue;
	public float interpolationTime = 1.0f;

	private VectorInterpolator interpolatorPosition;
	private VectorInterpolator interpolatorScale;

	private Bounds bounds;

	void Start () {
		interpolatorPosition = new VectorInterpolator ();
		interpolatorScale = new VectorInterpolator ();
		Setup ();
	}
	
	// Update is called once per frame
	new public void Update () {
		base.Update ();
		if( Mathf.Abs(transform.localScale.x) != scaleValue && interpolatorScale.Finished ()) {
			Vector3 endPosition = transform.position;
			Vector3 endScale = transform.localScale;

			bounds = GameObjectBounds.GetBounds(gameObject);
			float offset = ((scaleValue * bounds.size.y / transform.localScale.y) - bounds.size.y) * (0.5f - bounds.center.y + transform.position.y);
			endPosition = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
			
			endScale = new Vector3(Mathf.Sign(transform.localScale.x) * scaleValue, Mathf.Sign(transform.localScale.y) * scaleValue, transform.localScale.z);
			
			interpolatorPosition.setInterpolator(transform.position, endPosition, interpolationTime);
			interpolatorScale.setInterpolator(transform.localScale, endScale, interpolationTime);
		}
		if (rigidbody2D) {
			rigidbody2D.mass = massValue;
		}
		if (!interpolatorScale.Finished ()) {
			interpolatorScale.Update(Time.deltaTime);
			interpolatorPosition.Update(Time.deltaTime);
			transform.localScale = interpolatorScale.CurrentPosition ();
			transform.position = interpolatorPosition.CurrentPosition ();
		}
	}

	protected abstract void Setup ();

}
