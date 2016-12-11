using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : Interactable {

	public GameObject contextMenu;
	
	public override void OnClick()
	{
		if (GameMaster.instance.currentContext != contextMenu)
		{
			GameMaster.instance.ClearContext();
			contextMenu.SetActive(true);
			GameMaster.instance.currentContext = contextMenu;
		}
		else
		{
			contextMenu.gameObject.SetActive(false);
			GameMaster.instance.currentContext = null;
		}
	}
}
