using System;
using System.Collections;
using UnityEngine;
using Scaleform;
using Scaleform.GFx;

public class FlashDialogs : Movie 
{
	protected Value	theMovie = null;
	private MenuCamera parent = null;
	
	public FlashDialogs(MenuCamera parent, SFManager sfmgr, SFMovieCreationParams cp) :
		base(sfmgr, cp)
	{
		this.parent = parent;
		SFMgr = sfmgr;
		this.SetFocus(true);
	}
	
	
	public void OnRegisterSWFCallback(Value movieRef)
	{
		theMovie = movieRef;
	}
	
	public void hide(){		
		SFDisplayInfo info = theMovie.GetDisplayInfo ();
		info.Visible = false;
		theMovie.SetDisplayInfo (info);
	}
	
	public void show(){		
		SFDisplayInfo info = theMovie.GetDisplayInfo ();
		info.Visible = true;
		theMovie.SetDisplayInfo (info);
	}

	public void showDialogAt(Vector3 dialogPosition, int powerUp){
		Vector3 screenPos = parent.camera.ViewportToScreenPoint ( parent.camera.WorldToViewportPoint( dialogPosition ));
		object[] p = new object[3];
		p [0] = screenPos.x;
		p [1] = Screen.height - screenPos.y;
		p [2] = powerUp;
		theMovie.Invoke ("createDialogAt", p);
	}

	public void removeDialog(){
		theMovie.Invoke ("removeDialog");
	}

	public void activateDialogPowerup() {
		theMovie.Invoke ("takeDialogBuff");
	}
}

