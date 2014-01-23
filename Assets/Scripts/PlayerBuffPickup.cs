using UnityEngine;
using System.Collections;

public class PlayerBuffPickup : MonoBehaviour {

	public GameObject appleGun;
	public GameObject cupcakeGun;

	private GameObject currentGun;

	// Use this for initialization
	void Start () {
		SpawnBuff spawnBuff = GameObject.Find("_BuffSpawn").GetComponent<SpawnBuff> ();
		if (spawnBuff != null) {
			spawnBuff.PickedUpBuff += CollectedBuff;
		}
		currentGun = GetComponentInChildren<Gun>() .gameObject;
	}

	void CollectedBuff(FoodType type) {
		GameObject newGunType = null;
		if (type == FoodType.Apple) {
			newGunType = appleGun;
		}
		if (type == FoodType.Cupcake) {
			newGunType = cupcakeGun;
		}
		GameObject newGun = Instantiate (newGunType, currentGun.transform.position, currentGun.transform.rotation) as GameObject;
		newGun.transform.parent = transform;
		newGun.transform.localScale = new Vector3(1f,1f,1f);
		Destroy(currentGun);
		currentGun = newGun;

	}
}
