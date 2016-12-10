using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockView : MonoBehaviour {

	Text clockDisplay;
	string dateTime;
	public bool displayDate;

	void Start () {
		clockDisplay = GetComponent<Text>();
	}
	

	void FixedUpdate () {
		dateTime = GameMaster.instance.currentTime + ":00";
		if (displayDate)
			dateTime = "Day: " + GameMaster.instance.currentDay + "   " + dateTime;
		clockDisplay.text = dateTime;
	}
}
