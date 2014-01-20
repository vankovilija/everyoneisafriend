using UnityEngine;
using System.Collections;

public class MoveSpeedEventDispatcher : MonoBehaviour
{
	public delegate void EventHandler (GameObject e);

	public event EventHandler MoveSpeedChange;
	public void onMoveSpeedChange(){
		if (MoveSpeedChange != null) {
			MoveSpeedChange(gameObject);
		}
	}
}

