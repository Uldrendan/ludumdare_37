using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWindowButton : Button {

	public GameWindow Window;

	// Use this for initialization
	void Start () {
		Transform parent = transform.parent;
		while (Window == null) {
			Window = parent.GetComponent<GameWindow> ();
			parent = parent.parent;
		}
		onClick.AddListener (() => Window.Close());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
