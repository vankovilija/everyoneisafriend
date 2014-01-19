using UnityEngine;
using System.Collections;

public class SpawnBuff : MonoBehaviour {

	private Transform[] buffSpawnPositions;

	private GameObject spawnedBuff;
	private Transform spawnPosition;

	private GameSetup setupObject;

	private float spawnTime = 20f;
	private float timerTime = 0f;

	// Use this for initialization
	void Start () {
		buffSpawnPositions = GetComponentsInChildren<Transform> ();
		setupObject = GameObject.Find ("_GM").GetComponent<GameSetup>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!spawnedBuff) {
			timerTime -= Time.deltaTime;
			if(timerTime <= 0){
				int l = buffSpawnPositions.Length;
				int selection = Random.Range (0, l - 1);

				spawnPosition = buffSpawnPositions [selection];
				int foodSelection = Random.Range (0, 1);

				switch (foodSelection) {
					case 0:
						spawnedBuff = Instantiate (setupObject.appleCollectable, spawnPosition.position, spawnPosition.rotation) as GameObject;
						break;
					case 1:
						spawnedBuff = Instantiate (setupObject.cupcakeCollectable, spawnPosition.position, spawnPosition.rotation) as GameObject;
						break;
				}
				timerTime = 0f;
			}
		}
	}

	void CollectedBuff(){
		spawnedBuff = null;
		spawnPosition = null;
		timerTime = spawnTime;
	}
}
