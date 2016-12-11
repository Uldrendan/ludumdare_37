using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashroomButton : MonoBehaviour {

	GameObject contextMenu;

	void Start()
	{
		contextMenu = transform.parent.gameObject;
	}

	public void BathroomFunction()
	{
		switch (gameObject.name)
		{
			case "Toilet":
				GameMaster.instance.Bathroom += 100;
				break;
			case "Brush":
				GameMaster.instance.Hygiene += 20;
				break;
			case "Shower":
				GameMaster.instance.Hygiene += 30;
				break;
		}
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}
}
