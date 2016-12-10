using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : Interactable {


	void Start () {
		
	}
	
	public override void OnClick()
	{
		Vector3 mousePos = Input.mousePosition;
		Debug.Log(mousePos);
	}
}
