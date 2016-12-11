﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedButton : MonoBehaviour {

	GameObject contextMenu;

	void Start()
	{
		contextMenu = transform.parent.gameObject;
	}

	public void Sleep()
	{
		GameMaster.instance.Energy += 100;
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}

	public void MakeBed()
	{
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}
}
