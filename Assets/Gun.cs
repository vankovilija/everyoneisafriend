using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D bulletType;
	public int speed = 20;

	private PlayerControl control;
	
	void Awake () {
		control = transform.root.GetComponent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			if (control.axisDirection > 0) {
				print ("desno");
				Rigidbody2D bullet = Instantiate (bulletType, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bullet.velocity = new Vector2(speed, 0);				
			}else{
				Rigidbody2D bullet = Instantiate (bulletType, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
				bullet.velocity = new Vector2(-speed, 0);				
			}

		}
	}
}
