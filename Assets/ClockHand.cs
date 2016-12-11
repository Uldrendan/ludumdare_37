using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour {

	private AudioSource _audioSource;
	private int _prevTime = 0;


	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		int time = GameMaster.instance.currentTime;
		if (_prevTime != time) {
			float rotation = 30 * (time % 12);
			transform.localRotation = Quaternion.Euler (0, 90 - rotation, -90);
			// this is pretty shitty, dkm
			_audioSource.Play();
		}

		_prevTime = time;
	}
}
