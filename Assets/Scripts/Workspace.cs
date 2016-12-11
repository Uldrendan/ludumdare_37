using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : Interactable {

	public GameObject contextMenu;

	void Start () {
		
	}
	
	public override void OnClick()
	{
		contextMenu.gameObject.SetActive(true);
	}
}
