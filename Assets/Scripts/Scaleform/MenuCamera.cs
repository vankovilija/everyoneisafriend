using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections;
using Scaleform;

public class MenuCamera : SFCamera {
	public FlashMenu menu = null;
	public FlashDialogs dialogs = null;
	public string MENU_File = "FlashMenu.swf";
	public string DIALOGS_File = "Dialogs.swf";

	public delegate void EventHandler (MenuCamera cameraScript);
	public event EventHandler Initialized;

	new public  IEnumerator Start()
	{
		SF_SetKey("BEOY7LTWH217LULMEBD5KWSD3NGQLUSLY96XHSLNP7JUXU9Y1AX6YC9SQFBZZT9");
		SF_SetTextureCount(500);

		return base.Start();
	}

	new public void Update()
	{
		CreateUI ();
		base.Update ();
	}

	private void CreateUI()
	{
		if (menu == null) {
			SFMovieCreationParams creationParams = CreateMovieCreationParams(MENU_File);
//	     	creationParams.TheScaleModeType  = ScaleModeType.SM_ShowAll;
			creationParams.IsInitFirstFrame = false;
			menu = new FlashMenu(this, SFMgr, creationParams);
		}

		if (dialogs == null) {
			SFMovieCreationParams creationParams = CreateMovieCreationParams(DIALOGS_File);
//	     	creationParams.TheScaleModeType  = ScaleModeType.SM_NoScale;
			creationParams.IsInitFirstFrame = false;
			dialogs = new FlashDialogs(this, SFMgr, creationParams);
		}

		if (Initialized != null)
			Initialized (this);
	}
}
