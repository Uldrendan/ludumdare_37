using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : MonoBehaviour {

	public static Workspace instance;

	private AudioSource _audioSource;

	public AudioClip KeyboardMash;
	public AudioClip KeyboardType;

	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy (instance.gameObject);
		}
		instance = this;
		_audioSource = GetComponent<AudioSource> ();
	}

	public void StartTyping() {
		_audioSource.loop = true;
		_audioSource.clip = KeyboardType;
		_audioSource.Play ();
	}
	public void StartMashing() {
		_audioSource.loop = true;
		_audioSource.clip = KeyboardMash;
		_audioSource.Play ();
	}
	public void StopKeyboardSounds() {
		_audioSource.Stop ();
	}
}