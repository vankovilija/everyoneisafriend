using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {

	static private string[] powerups = new string[]{"SuperJump", "BigScale"};


	static public string GetPowerup(int powerup) {
		return powerups[powerup - 1];
	}


}
