using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseProductButton : Button {

	GameObject contextMenu;
	public Product Product;
	private Text _text;

	void Start()
	{
		contextMenu = transform.parent.gameObject;
		_text = GetComponentInChildren<Text> ();
		onClick.AddListener (() => UseProduct ());
	}

	void Update () {
		if (GameMaster.instance.GetStock (Product) > 0) {
			interactable = true;
		} else {
			interactable = false;
		}
		_text.text = Product.Name + " x" + GameMaster.instance.GetStock (Product);

	}

	public void UseProduct () {
		if (GameMaster.instance.GetStock (Product) > 0) {
			GameMaster.instance.UseProduct (Product);
		}
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}

	public void SetProduct (Product product) {
		Product = product;
	}
}
