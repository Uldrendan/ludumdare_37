using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopButton : Button {

	public GameObject contextMenu;

	// Use this for initialization
	void Start () {
		contextMenu = transform.parent.gameObject;
		onClick.AddListener(() => OpenShop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenShop()
	{
		ShopManager.instance.SetAmazonActive(true);
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}
}
