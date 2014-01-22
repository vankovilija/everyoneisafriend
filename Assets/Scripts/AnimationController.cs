using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponentInChildren<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", rigidbody2D.velocity.x);
	}
}
