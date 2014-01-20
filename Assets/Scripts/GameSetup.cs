using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	public static int happyCount = 0;
	public static int angryCount = 0;

	private Camera mainCam;

	private BoxCollider2D topWall;
	private BoxCollider2D bottomWall;
	private BoxCollider2D leftWall;
	private BoxCollider2D rightWall;

	void Start () {
		mainCam = Camera.main;
		
		topWall = transform.FindChild ("topWall").GetComponent<BoxCollider2D>();
		bottomWall = transform.FindChild ("bottomWall").GetComponent<BoxCollider2D>();
		leftWall = transform.FindChild ("leftWall").GetComponent<BoxCollider2D>();
		rightWall = transform.FindChild ("rightWall").GetComponent<BoxCollider2D>();

//		PositionWalls ();	
	}

	// Use this for initialization
	void PositionWalls () {	
//		topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (levelWidth * 2.0f, 0f, 0f)).x, 1f);
//		topWall.center = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, levelHeight, 0f)).y + 0.5f);
//
//		bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (levelWidth * 2.0f, 0f, 0f)).x, 1f);
//		bottomWall.center = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, 0f, 0f)).y - 0.5f);
//
//		leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (levelHeight * 2.0f, 0f, 0f)).x);
//		leftWall.center = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);
//
//		rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (levelHeight * 2.0f, 0f, 0f)).x);
//		rightWall.center = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(levelWidth, 0f, 0f)).x + 0.5f, 0f);
	}

}
