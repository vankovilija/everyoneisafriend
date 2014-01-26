using System;
using System.Collections;
using UnityEngine;
using Scaleform;
using Scaleform.GFx;

public class MainFlashMenu : Movie
{
	public bool ready = false;

	protected Value	theMovie = null;
	private MainMenuCamera parent = null;
	
	public MainFlashMenu(MainMenuCamera parent, SFManager sfmgr, SFMovieCreationParams cp) :
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

	public void MenuReady()
	{
		ready = true;
	}
}

