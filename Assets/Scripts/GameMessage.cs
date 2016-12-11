using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMessage : MonoBehaviour 
{

	public static GameMessage instance;

	public GameObject gameMessagePanel;
	Text messageText;
	Button actionButton;

	void Start () 
	{
		if (instance != null)
			Destroy(instance);
		else
			instance = this;

		messageText = gameMessagePanel.transform.GetChild(0).GetComponent<Text>();
		actionButton = gameMessagePanel.transform.GetChild(1).GetComponent<Button>();
	}

	public void PostGameMessage(string message)
	{
		gameMessagePanel.SetActive(true);
		messageText.text = message;
		actionButton.transform.GetChild(0).GetComponent<Text>().text = "Restart";
		actionButton.onClick.AddListener(delegate { Restart();});

	}

	public void Restart()
	{
		SceneManager.LoadScene("Main");
	}
}