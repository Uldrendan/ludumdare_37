using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public List<ShopItem> Stock;

	public GameObject ShopItem_GO;
	public GameObject ShopContent;

	// Use this for initialization
	void Start () {
		Stock = new List<ShopItem> ();
		AddProduct (new SaladProduct ());
		AddProduct (new ColdPizzaProduct ());
		AddProduct (new HotPocketsProduct ());

	}

	void AddProduct(Product product) {
		if (!IsProductInStock (product)) {
			GameObject shopItem_GO = Instantiate (ShopItem_GO, ShopContent.transform) as GameObject;
			ShopItem shopItem = shopItem_GO.GetComponent<ShopItem> ();
			shopItem.Setup ();
			shopItem.SetProduct (product);
		}
	}

	bool IsProductInStock(Product product) {
		ShopItem match = Stock.Find ((x) => x.Product == product);
		return (match != null);
	}

	void RemoveProduct(Product product) {
		Stock.RemoveAll ((x) => x.Product == product);
	}
}
