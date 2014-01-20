using UnityEngine;
using System.Collections;

public class SpawnBuff : MonoBehaviour {

	public float spawnTime = 20f;

	private Transform[] buffSpawnPositions;

	private GameObject spawnedBuff;
	private Transform spawnPosition;

	private GameSetup setupObject;
	
	private float timerTime = 0f;

	// Use this for initialization
	void Start () {
		buffSpawnPositions = GetComponentsInChildren<Transform> ();
		System.Collections.Generic.List<Transform> list = new System.Collections.Generic.List<Transform> (buffSpawnPositions);
		list.Remove (transform);
		buffSpawnPositions = list.ToArray ();
		setupObject = GameObject.Find ("_GM").GetComponent<GameSetup>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!spawnedBuff) {
			timerTime -= Time.deltaTime;
			if(timerTime <= 0){
				int l = buffSpawnPositions.Length;
				int selection = Mathf.RoundToInt( Random.Range (-0.4f, l - 0.6f) );

				spawnPosition = buffSpawnPositions [selection];
				int foodSelection = Mathf.RoundToInt( Random.Range (0f, 1f) );

				switch (foodSelection) {
					case 0:
						spawnedBuff = Instantiate (setupObject.appleCollectable, spawnPosition.position, spawnPosition.rotation) as GameObject;
						break;
					case 1:
						spawnedBuff = Instantiate (setupObject.cupcakeCollectable, spawnPosition.position, spawnPosition.rotation) as GameObject;
						break;
				}
				spawnedBuff.GetComponent<BuffPickupScript>().PickedUpBuff += CollectedBuff;
				timerTime = 0f;
			}
		}
	}

	void CollectedBuff(FoodType type){
		spawnedBuff.GetComponent<BuffPickupScript>().PickedUpBuff -= CollectedBuff;
		spawnedBuff = null;
		spawnPosition = null;
		timerTime = spawnTime;
	}
}
