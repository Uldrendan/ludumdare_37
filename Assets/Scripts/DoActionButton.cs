using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoActionButton : Button {

	GameObject contextMenu;

	public Action _action;

	void Start()
	{
		contextMenu = transform.parent.gameObject;
		onClick.AddListener(() => UpdateAction());
	}

	public void UpdateAction()
	{
		GameMaster.instance.currentAction = _action;
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}

	public void SetAction(Action action)
	{
		_action = action;
	}
}
