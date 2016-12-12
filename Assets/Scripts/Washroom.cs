using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washroom : MonoBehaviour {

	public static Washroom instance;

	public ParticleSystem _steam;
	private AudioSource _audioSource;
	private AudioSource _doorAudioSource;
	public AudioClip DoorClose;
	public AudioClip Flush;
	public AudioClip Shower;
	public AudioClip Sink;

	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy (instance.gameObject);
		}
		instance = this;

		_steam.Stop ();
		_audioSource = GetComponent<AudioSource> ();
		_doorAudioSource = transform.Find ("WCdoor").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShutDoor () {
		_doorAudioSource.clip = DoorClose;
		_doorAudioSource.Play ();
	}

	public void FlushToilet () {
		_audioSource.loop = false;
		_audioSource.clip = Flush;
		_audioSource.Play ();
	}

	public void ShowerOn () {
		_audioSource.loop = true;
		_audioSource.clip = Shower;
		_audioSource.Play ();
		_steam.Play ();
	}

	public void ShowerOff () {
		_audioSource.Stop ();
		_steam.Stop ();
	}

	public void SinkOn () {
		_audioSource.loop = true;
		_audioSource.clip = Sink;
		_audioSource.Play ();
	}

	public void SinkOff () {
		_audioSource.Stop ();
	}


}
