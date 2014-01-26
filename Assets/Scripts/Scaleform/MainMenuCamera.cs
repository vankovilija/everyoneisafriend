using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections;
using Scaleform;

public class MainMenuCamera : SFCamera {
	public MainFlashMenu menu = null;
	public string MAIN_Menu = "MainFlashMenu.swf";

	private bool startedAnimation = false;
	
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

		if (menu.ready && Input.GetKeyDown (KeyCode.Space)) {
			if(!startedAnimation){
				menu.theMovie.Invoke("playStartAnimation");
				startedAnimation = true;
			}else{
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}
	}
	
	private void CreateUI()
	{
		if (menu == null) {
			SFMovieCreationParams creationParams = CreateMovieCreationParams(MAIN_Menu);
			//	     	creationParams.TheScaleModeType  = ScaleModeType.SM_ShowAll;
			creationParams.IsInitFirstFrame = false;
			menu = new MainFlashMenu(this, SFMgr, creationParams);
		}
	}
}
