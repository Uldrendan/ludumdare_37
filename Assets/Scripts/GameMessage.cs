using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMessage : MonoBehaviour 
{

	public static GameMessage instance;

	Text messageText;
	Button actionButton;

	void Start () 
	{
		if (instance != null)
			Destroy(instance);
		else
			instance = this;

		messageText = transform.GetChild(0).GetComponent<Text>();
		actionButton = transform.GetChild(1).GetComponent<Button>();
	}

	public void PostGameMessage(string message)
	{

	}

	void Update () 
	{
		
	}
}