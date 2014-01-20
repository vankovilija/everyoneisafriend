using UnityEngine;
using System.Collections;

public class SpawnBuff : MonoBehaviour {

	public GameObject[] collectableObjects;
	public float spawnTime = 20f;

	private Transform[] buffSpawnPositions;

	private GameObject spawnedBuff;
	private Transform spawnPosition;

	private float timerTime = 0f;

	// Use this for initialization
	void Start () {
		buffSpawnPositions = GetComponentsInChildren<Transform> ();
		System.Collections.Generic.List<Transform> list = new System.Collections.Generic.List<Transform> (buffSpawnPositions);
		list.Remove (transform);
		buffSpawnPositions = list.ToArray ();
	}
	
	// Update is called once per frame
	void Update () {

		if (spawnedBuff == null) {
			timerTime -= Time.deltaTime;
			if(timerTime <= 0){
				int l = buffSpawnPositions.Length;
				int selection = Mathf.RoundToInt( Random.Range (-0.4f, l - 0.6f) );

				spawnPosition = buffSpawnPositions [selection];
				int foodSelection = Mathf.RoundToInt( Random.Range (-0.4f, collectableObjects.Length - 0.6f) );
				spawnedBuff = Instantiate (collectableObjects[foodSelection], spawnPosition.position, spawnPosition.rotation) as GameObject;
						
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
