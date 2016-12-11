using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : ContextMenuInteractable {

	public float updateStep = 0.1f;
	public int sampleDataLength = 1024;
	private float _currentUpdateTime = 0f;
	private float _clipLoudness;
	private float[] clipSampleData;

	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}
	
	void Update () {
		_currentUpdateTime += Time.deltaTime;
		if (_currentUpdateTime >= updateStep) {
			_currentUpdateTime = 0;
			_audioSource.clip.GetData (clipSampleData, _audioSource.timeSamples);

			_clipLoudness = 0f;
			if (_audioSource.isPlaying) {
				foreach (float sample in clipSampleData) {
					_clipLoudness += Mathf.Abs (sample);
				}
				_clipLoudness /= sampleDataLength;
			}
		}
		Debug.Log (_clipLoudness);
	}
}
