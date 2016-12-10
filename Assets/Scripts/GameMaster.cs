﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static GameMaster instance;

	public int energy = 100;
	public int hygiene = 100;
	public int food = 100;

	void Start () {
		if (instance != null)
			GameObject.Destroy(instance);
		else
			instance = this;
	}

	// Update is called once per frame
	void Update () {
		CheckClick ();
	}

	void CheckClick () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000f)) {
				Debug.Log ("Clicked " + hit.collider.gameObject.name);
				Interactable interactable = hit.collider.gameObject.GetComponent<Interactable> ();
				if (interactable != null) {
					Debug.Log ("Interactable");
					interactable.OnClick ();
				} else {
					Debug.Log ("NOT Interactable");
				}
			} else {
				Debug.Log ("Clicked EMPTY SPACE");
			}
		}
	}
}
