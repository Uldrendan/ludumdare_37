using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
	// Behaviour to perform when clicked.
	public abstract void OnClick ();

	// Handling of Coroutines
	protected IEnumerator _currentCoroutine;
	public IEnumerator CurrentCoroutine {
		get {
			return _currentCoroutine;
		}
		set {
			if (_currentCoroutine != null) {
				StopCoroutine (_currentCoroutine);
			}
			_currentCoroutine = value;
			StartCoroutine (_currentCoroutine);
		}
	}
}
