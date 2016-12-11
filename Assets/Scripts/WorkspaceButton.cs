using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceButton : MonoBehaviour {

	public GameObject shopMenu;

	public void UpdateActivity()
	{
		GameMaster.instance.currentActivity = gameObject.name;
	}

	public void OpenShop()
	{
		shopMenu.SetActive(true);
	}
}
