using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {

	public static Bed instance;

	public ParticleSystem _particle;

	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy (instance.gameObject);
		}
		instance = this;
		_audioSource = GetComponent<AudioSource> ();
	}

	public void BeginSnoring() {
		_particle.Play ();
		_audioSource.loop = true;
		_audioSource.Play ();
	}
	public void StopSnoring() {
		_particle.Stop ();
		_audioSource.Stop ();
	}
}
