using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : Interactable {

	public GameObject contextMenu;
	bool open;
	
	public override void OnClick()
	{
		if (!open)
		{
			contextMenu.gameObject.SetActive(true);
			GameMaster.instance.currentContext = contextMenu;
			open = true;
		}
		else
		{
			contextMenu.gameObject.SetActive(false);
			GameMaster.instance.currentContext = null;
			open = false;
		}
	}
}
