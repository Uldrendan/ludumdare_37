using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindow : MonoBehaviour {

	public void Open() {
		gameObject.SetActive (true);
	}

	public void Close() {
		gameObject.SetActive (false);
	}

	public void Toggle() {
		gameObject.SetActive (!gameObject.activeSelf);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
