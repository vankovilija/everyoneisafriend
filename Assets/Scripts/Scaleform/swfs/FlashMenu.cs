using System;
using System.Collections;
using UnityEngine;
using Scaleform;
using Scaleform.GFx;

public class FlashMenu : Movie {

	protected Value	theMovie = null;
	private MenuCamera parent = null;
	
	public FlashMenu(MenuCamera parent, SFManager sfmgr, SFMovieCreationParams cp) :
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
}
