using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int time = GameMaster.instance.currentTime;
		float rotation = 30 * (time % 12);
		transform.localRotation = Quaternion.Euler (0, 90 - rotation, -90);
		// this is pretty shitty, dkm
	}
}
