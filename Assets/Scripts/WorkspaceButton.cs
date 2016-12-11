using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceButton : MonoBehaviour {

	public GameObject shopMenu;

	GameObject contextMenu;

	void Start()
	{
		contextMenu = transform.parent.gameObject;
	}

	public void UpdateActivity()
	{
		GameMaster.instance.currentActivity = gameObject.name;
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}

	public void OpenShop()
	{
		shopMenu.SetActive(true);
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}
}
