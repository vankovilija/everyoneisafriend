using UnityEngine;
using System.Collections;

public class ScrollCollect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D obj){
	
		if (obj.tag == "Player") {
			Destroy(this.gameObject);
		}
	}
}
