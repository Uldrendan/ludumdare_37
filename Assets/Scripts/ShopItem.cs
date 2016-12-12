using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : Button {

	public Product Product;
	public Image Icon;
	public Text Cost;
	public Text Name;
	public Text Description;

	public void Start () {
		Setup ();
		onClick.AddListener (() => OrderProduct());
	}

	public void SetProduct(Product product) {
		Product = product;
		Name.text = Product.Name;
		Description.text = Product.Description;
		Cost.text = "$" + Product.Cost;
		Icon.sprite = Product.Icon;
	}

	void OrderProduct() {
		ShopManager.instance.OrderProduct (Product);
	}

	public void Setup() {
		Icon = transform.Find ("Icon").GetComponent<Image> ();
		Cost = transform.Find ("Cost").GetComponent<Text> ();
		Name = transform.Find ("Name").GetComponent<Text> ();
		Description = transform.Find ("Description").GetComponent<Text> ();
		transform.localScale = new Vector3 (1, 1, 1);
	}
}