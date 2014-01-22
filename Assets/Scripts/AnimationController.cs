using UnityEngine;
using System.Collections;

public enum AnimationState {
	noanimation,
	run,
	death,
	spawn
}

public class AnimationController : MonoBehaviour {

	private Animator anim;

	public delegate void EventHandler (AnimationState state);
	public event EventHandler AnimationStart;
	public event EventHandler AnimationEnd;
	
	private AnimationState currentState;

	// Use this for initialization
	void Start () {
		StartAnimation (AnimationState.spawn);
	}
	
	// Update is called once per frame
	void Update () {

		switch (currentState) {
		case AnimationState.death:
			if (!animation.isPlaying) {
				StartAnimation(AnimationState.spawn);
			}
			break;
		case AnimationState.spawn:
			if (!animation.isPlaying) {
				StartAnimation(AnimationState.run);
			}
			break;
		}

	}

	public void RunSpeed(float speed) {
		animation["Run"].speed = speed;
	}

	public void Die() {
		StartAnimation (AnimationState.death);
	}

	private string NameForState(AnimationState state) {
		switch (state) {
		case AnimationState.death:
			return "Death";
		case AnimationState.spawn:
			return "Spawn";
		case AnimationState.run:
			return "Run";
		}
		return "";
	}

	private void StartAnimation(AnimationState state) {
		EndAnimaiton (currentState);
		currentState = state;
		animation.Play (NameForState (state), PlayMode.StopAll);
		if (AnimationStart != null) {
			AnimationStart(state);
		}
	}

	private void EndAnimaiton(AnimationState state) {
		if (AnimationEnd != null) {
			AnimationEnd (state);
		}
	}
	
}
