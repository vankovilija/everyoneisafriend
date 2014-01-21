using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D bulletType;
	public float speed = 2f;
	public float rotationSpeed = 100f;

	public bool shootContinusly = true;
	public float shootTime = 0.5f;

	public string FireButton = "Fire1";
	public string ShootPoint = "Gun";

	protected Transform gun;

	private bool shooting = false;

	private float timeFromLastShot = 0;
	
	void Start () {
		gun = transform.FindChild (ShootPoint);
		timeFromLastShot = shootTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (FireButton)) {
			shooting = true;
		}
		if (Input.GetButtonUp (FireButton)) {
			shooting = false;
		}

		if (shooting) {
			if(timeFromLastShot >= shootTime){
				if (transform.localScale.x > 0) {
					ShootBullet(1);				
				}else{
					ShootBullet(-1);
				}

				timeFromLastShot = 0;

				if(!shootContinusly){
					shooting = false;
				}
			}
		}

		timeFromLastShot += Time.deltaTime;
	}

	virtual protected void ShootBullet (int direction){
		//to be overriden
	}
}
