using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopButton : Button {

	public GameObject shopMenu;
	public GameObject contextMenu;

	// Use this for initialization
	void Start () {
		onClick.AddListener(() => OpenShop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenShop()
	{
		shopMenu.SetActive(true);
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}
}
