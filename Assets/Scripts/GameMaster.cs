using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static GameMaster instance;

	public float energy = 100;
	public float hygiene = 100;
	public float hunger = 100;
	public float bathroom = 100;

	public int currentDay;
	public int currentTime;

	float timer;

	void Start () {
		if (instance != null)
			Destroy(instance);
		else
			instance = this;
	}

	void Update () {
		HandleTimer ();
		CheckClick ();
	}

	void HandleTimer () {
		timer += Time.deltaTime;
		if (timer >= 5)
		{
			if (currentTime < 23)
				currentTime += 1;
			else
			{
				currentDay += 1;
				currentTime = 0;
			}
			timer = 0;
			Debug.Log(currentDay + "    " + currentTime + ":00");
		}
	}

	void CheckClick () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000f)) {
				Debug.Log ("Clicked " + hit.collider.gameObject.name);
				Transform obj = hit.collider.transform;
				Interactable interactable = obj.GetComponent<Interactable> ();
				while (interactable == null && obj.transform.parent != null) {
					obj = obj.transform.parent;
					Debug.Log ("Checking parent " + obj.name + " for Interactable");
					interactable = obj.GetComponent<Interactable> ();
				}

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