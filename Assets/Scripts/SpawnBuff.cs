using UnityEngine;
using System.Collections;

public class SpawnBuff : MonoBehaviour {

	private Transform[] buffSpawnPositions;

	private GameObject spawnedBuff;
	private Transform spawnPosition;

	// Use this for initialization
	void Start () {
		buffSpawnPositions = GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		int l = buffSpawnPositions.Length;
		int selection = Random.Range (0, l - 1);

		spawnPosition = buffSpawnPositions [selection];

	}
}
