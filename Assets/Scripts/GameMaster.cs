using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static GameMaster instance;

	public int energy = 100;
	public int hygiene = 100;
	public int food = 100;

	void Start () {
		if (instance != null)
			GameObject.Destroy(instance);
		else
			instance = this;
	}
}
