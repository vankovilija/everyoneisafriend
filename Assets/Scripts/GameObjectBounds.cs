using UnityEngine;
using System.Collections;

public class GameObjectBounds {

	public static Bounds GetBounds(GameObject gameObject) {


		Bounds bounds;
		SpriteRenderer parentRenderer = gameObject.GetComponent<SpriteRenderer> ();
		if (parentRenderer) {

			bounds = parentRenderer.bounds;

		} else {

			Vector3 center = Vector3.zero;
			int renderCount = 0;
			foreach (SpriteRenderer childRenderer in gameObject.GetComponentsInChildren<SpriteRenderer> ())
			{
				center += childRenderer.bounds.center;  
				renderCount++;
			}
			center /= renderCount; 

			bounds = new Bounds(center,Vector3.zero); 
		}
				
		foreach (SpriteRenderer childRenderer in gameObject.GetComponentsInChildren<SpriteRenderer> ())
		{
			bounds.Encapsulate(childRenderer.bounds); 
		}

		return bounds;

	}
}
