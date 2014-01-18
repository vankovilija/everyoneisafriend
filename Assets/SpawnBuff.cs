using UnityEngine;
using System.Collections;

public class SpawnBuff : MonoBehaviour {

	private Transform[] buffSpawns;

	private GameObject spawnedBuff;
	private Transform spawnPosition;

	// Use this for initialization
	void Start () {
		buffSpawns = GetComponentInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
