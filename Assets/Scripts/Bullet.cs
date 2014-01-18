using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public FoodType type;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		Destroy (gameObject);
	}
}
