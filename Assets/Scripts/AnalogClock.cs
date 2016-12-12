using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : Interactable {

	public GameObject ClockHand;

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
			ClockHand.transform.localRotation = Quaternion.Euler (0, 90 - rotation, -90);
			// this is pretty shitty, dkm
			_audioSource.volume = 0.1f;
			_audioSource.pitch = Random.Range(0.8f,1.2f);
			_audioSource.Play();
		}

		_prevTime = time;
	}

	public override void OnClick() {
		_audioSource.volume = 0.05f;
		_audioSource.pitch = Random.Range(2.5f,3.5f);
		_audioSource.Play();
	}
}
