﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButtons : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene("Main");
	}
}
