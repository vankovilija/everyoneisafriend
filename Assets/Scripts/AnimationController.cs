using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public const string DEATH = "Death";
	public const string RUN = "Run";
	public const string SPAWN = "Spawn";

	private Animator anim;

	public delegate void EventHandler (string animation);
	public event EventHandler AnimationStart;
	public event EventHandler AnimationEnd;
	
	private string currentAnimation;

	// Use this for initialization
	void Start () {
		StartAnimation (SPAWN);
	}
	
	// Update is called once per frame
	void Update () {

		switch (currentAnimation) {
		case DEATH:
			if (!animation.isPlaying) {
				StartAnimation(SPAWN);
			}
			break;
		case SPAWN:
			if (!animation.isPlaying) {
				StartAnimation(RUN);
			}
			break;
		}

	}

	public void RunSpeed(float speed) {
		animation[RUN].speed = speed;
	}

	public void Die() {
		StartAnimation (DEATH);
	}

	private void StartAnimation(string animationName) {
		EndAnimaiton (currentAnimation);
		currentAnimation = animationName;
		animation.Play ( animationName );
		if (AnimationStart != null) {
			AnimationStart ( animationName );
		}
	}

	private void EndAnimaiton(string animationName) {
		animation.Stop ();
		if (AnimationEnd != null) {
			AnimationEnd ( animationName );
		}
	}
	
}
