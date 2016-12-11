using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMessage : MonoBehaviour 
{

	public static GameMessage instance;

	void Start () 
	{
		if (instance != null)
			Destroy(instance);
		else
			instance = this;
	}

	void Update () 
	{
		
	}
}