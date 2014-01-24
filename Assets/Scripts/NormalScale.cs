using UnityEngine;
using System.Collections;

public class NormalScale : MonoBehaviour {

	public float normalScale;
	public float normalMass;
	public float interpolationTime = 1.0f;

	private VectorInterpolator interpolatorPosition;
	private VectorInterpolator interpolatorScale;

	void Start () {
		interpolatorPosition = new VectorInterpolator ();
		interpolatorScale = new VectorInterpolator ();
	}
	
	// Update is called once per frame
	void Update () {
		if( Mathf.Abs(transform.localScale.x) != normalScale && interpolatorScale.Finished ()) {
			Vector3 endPosition = transform.position;
			Vector3 endScale = transform.localScale;
			BoxCollider2D collider = GetComponent<BoxCollider2D> ();
			if (collider) {
				float offset = ((normalScale * collider.size.y) - (transform.localScale.x * collider.size.y)) / 2.0f;
				endPosition = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
			}
			endScale = new Vector3(Mathf.Sign(transform.localScale.x) * normalScale, Mathf.Sign(transform.localScale.y) * normalScale, transform.localScale.z);
			interpolatorPosition.setInterpolator(transform.position, endPosition, interpolationTime);
			interpolatorScale.setInterpolator(transform.localScale, endScale, interpolationTime);
		}
		if (rigidbody2D) {
			rigidbody2D.mass = normalMass;
		}
		if (!interpolatorScale.Finished ()) {
			interpolatorScale.Update(Time.deltaTime);
			interpolatorPosition.Update(Time.deltaTime);
			transform.localScale = interpolatorScale.CurrentPosition ();
			transform.position = interpolatorPosition.CurrentPosition ();
		}
	}
}
