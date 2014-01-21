using UnityEngine;
using System.Collections;

public class RotationBulletGun : Gun
{
	override protected GameObject ShootBullet (int direction){
		GameObject bullet = Instantiate (bulletType, gun.transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
		if (bullet.rigidbody2D != null) {
			bullet.rigidbody2D.velocity = new Vector2 (direction * speed, 0f);				
			bullet.rigidbody2D.angularVelocity = -1 * direction * rotationSpeed;
		}
		return bullet;
	}
}

