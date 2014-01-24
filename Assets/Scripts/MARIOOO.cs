using UnityEngine;
using System.Collections;

public class MARIOOO : MonoBehaviour {
	float timeEnd = 5;
	float time = 0;
	bool a = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= timeEnd && a) {
			a = false;
			(gameObject.AddComponent<PlayerScale> () as PlayerScale).init(5.0f, GetComponent<NormalScale> (), 2.0f, 1.0f, 1.0f);
		}
	}
}
