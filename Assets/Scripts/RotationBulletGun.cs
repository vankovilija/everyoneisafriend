using UnityEngine;
using System.Collections;

public class RotationBulletGun : Gun
{
	override protected void ShootBullet (int direction){
		Rigidbody2D bullet = Instantiate (bulletType, gun.transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
		bullet.velocity = new Vector2(direction * speed, 0f);				
		bullet.angularVelocity = -1 * direction * rotationSpeed;
	}
}

