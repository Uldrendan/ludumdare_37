using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedContextMenu : MonoBehaviour {
	
	public GameObject SleepButton_GO;

	public DoActionButton SleepButton;

	// Use this for initialization
	void Start () {
		SleepButton = SleepButton_GO.GetComponent<DoActionButton>();
		SleepButton.SetAction(ScriptableObject.CreateInstance<SleepAction>());
	}

	// Update is called once per frame
	void Update () {

	}
}
