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
		Vector3 screenPos = parent.camera.WorldToScreenPoint( dialogPosition );
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

	public void showCanAt(Vector3 canPosition, string text = "YES I CAN!"){
		Vector3 screenPos = parent.camera.WorldToScreenPoint( canPosition );
		object[] p = new object[3];
		p [0] = screenPos.x;
		p [1] = Screen.height - screenPos.y;
		p [2] = text;
		theMovie.Invoke ("showCan", p);
	}

	public void hideCan(){
		theMovie.Invoke ("hideCan");
	}
	
	public void showCantAt(Vector3 cantPosition, string text = "OPS I CAN'T!"){
		Vector3 screenPos = parent.camera.WorldToScreenPoint( cantPosition );
		object[] p = new object[3];
		p [0] = screenPos.x;
		p [1] = Screen.height - screenPos.y;
		p [2] = text;
		theMovie.Invoke ("showCant", p);
	}

	public void hideCant(){
		theMovie.Invoke ("hideCant");
	}

	public void showMoreConfidenceAt(Vector3 moreConfidencePosition){
		Vector3 screenPos = parent.camera.WorldToScreenPoint( moreConfidencePosition );
		object[] p = new object[2];
		p [0] = screenPos.x;
		p [1] = Screen.height - screenPos.y;
		theMovie.Invoke ("showMoreConfidenceAt", p);
	}
}

