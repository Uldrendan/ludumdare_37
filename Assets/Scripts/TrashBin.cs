using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Interactable {

	public const int NumWiggles = 3;
	public const float WiggleDegrees = 10;
	public const float WiggleDegreesPerSecond = 120;

	private AudioSource _audioSource;

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

	public override void OnClick () {
		_audioSource.pitch = Random.Range (0.8f, 1.2f);
		_audioSource.Play ();
		CurrentCoroutine = Wiggle ();
	}

	IEnumerator Wiggle () {
		int numWiggles = NumWiggles;
		float wiggleDegrees = WiggleDegrees;
		float wiggleDegreesPerSecond = WiggleDegreesPerSecond;
		int wiggleDir = 1;

		while (numWiggles > 0) {
			Quaternion goalRotation = Quaternion.Euler (0, 0, wiggleDegrees * wiggleDir);
			while (transform.rotation != goalRotation) {
				transform.rotation = Quaternion.RotateTowards (transform.rotation, goalRotation, wiggleDegreesPerSecond*Time.deltaTime);
				yield return null;
			}
			wiggleDir *= -1;
			numWiggles--;
			while (transform.rotation != Quaternion.identity) {
				transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.identity, wiggleDegreesPerSecond*Time.deltaTime);
				yield return null;
			}
		}
	}
}
