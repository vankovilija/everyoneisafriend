using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bulletType;
	public string bulletsLayer = "PlayerBullets";
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
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer ("player"), LayerMask.NameToLayer (bulletsLayer));
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
				GameObject bullet;
				if (transform.localScale.x > 0) {
					bullet = ShootBullet(1);				
				}else{
					bullet = ShootBullet(-1);
				}

				if(bullet != null){
					bullet.layer = LayerMask.NameToLayer(bulletsLayer);
					bullet.tag = "Bullet";
				}

				timeFromLastShot = 0;

				if(!shootContinusly){
					shooting = false;
				}
			}
		}

		timeFromLastShot += Time.deltaTime;
	}

	virtual protected GameObject ShootBullet (int direction){
		//to be overriden
		return null;
	}
}
