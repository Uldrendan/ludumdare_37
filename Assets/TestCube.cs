using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : Interactable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnClick() {
		Debug.Log ("I'm a cube, ya bish");
		CurrentCoroutine = TestCoroutine();
	}

	IEnumerator TestCoroutine () {
		Vector3 randomPosition = new Vector3 (Random.Range (-5f, 5f), Random.Range (-5f, 5f), 0);
		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, randomPosition, 1 * Time.deltaTime);
			yield return null;
		}
	}
}
