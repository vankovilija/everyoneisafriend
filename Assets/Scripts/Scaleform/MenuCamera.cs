using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections;
using Scaleform;

public class MenuCamera : SFCamera {
	public FlashMenu menu = null;
	public string SWF_File = "FlashMenu.swf";

	new public  IEnumerator Start()
	{
		SF_SetKey("");
		
		return base.Start();
	}

	new public void Update()
	{
//		CreateUI ();
		base.Update ();
	}

	private void CreateUI()
	{
		if (menu == null) {
			SFMovieCreationParams creationParams = CreateMovieCreationParams(SWF_File);
	     	creationParams.TheScaleModeType  = ScaleModeType.SM_ShowAll;
			creationParams.IsInitFirstFrame = false;
			menu = new FlashMenu(this, SFMgr, creationParams);
		}
	}
}
