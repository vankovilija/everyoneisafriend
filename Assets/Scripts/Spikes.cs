﻿using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	private GameObject downSpike;
	private GameObject upSpike;

	public float upTime = 1f;
	public float downTime = 2.5f;
	public float startTime = 0f;

	private int currentState = 0; // 0 - down, 1 - up
	private float currentTime = 0;
	private bool started = false;

	// Use this for initialization
	void Start () {

		downSpike = transform.FindChild ("DownSpike").gameObject;
		upSpike = transform.FindChild ("UpSpike").gameObject;

		upSpike.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(started){
			currentTime += Time.deltaTime;
			switch (currentState) {
			case 0:
				if(currentTime >= upTime){
					currentState = 1;
					currentTime = 0;
					ChangeSpike(currentState);
				}
				break;
			case 1:
				if(currentTime >= downTime){
					currentTime = 0;
					currentState = 0;
					ChangeSpike(currentState);
				}
				break;
			}
		}else{
			currentTime += Time.deltaTime;
			if(currentTime >= startTime){
				started = true;
				currentTime = 0;
			}
		}

	}

	void ChangeSpike(int state){

		switch (state) {
		case 0:
			upSpike.SetActive(true);
			downSpike.SetActive(false);
			break;
		case 1:
			upSpike.SetActive(false);
			downSpike.SetActive(true);
			break;
		}
	}
}
