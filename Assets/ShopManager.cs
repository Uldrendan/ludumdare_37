using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

	public static ShopManager instance;

	public List<ShopItem> Stock;
	public List<ProductStock> CurrentOrder;

	public GameObject ShopItem_GO;
	public GameObject CartItem_GO;
	public GameObject ShopContent;
	public GameObject CartContent;

	// Use this for initialization
	void Start () {

		if (instance != null)
			Destroy(instance);
		else
			instance = this;

		Stock = new List<ShopItem> ();
		CurrentOrder = new List<ProductStock> ();
		AddProduct (new SaladProduct ());
		AddProduct (new ColdPizzaProduct ());
		AddProduct (new HotPocketsProduct ());
		AddProduct (new EnergyDrinkProduct ());
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

	public void OrderProduct(Product product) {
		Debug.Log ("Ordering 1 Product: " + product.Name);
		if (CurrentOrder == null) {
			CurrentOrder = new List<ProductStock> ();
			GameEventScheduler.instance.ScheduleGameEvent (new OrderDeliveryEvent(TimeSpan.FromSeconds(10)));
		}
		ProductStock order = CurrentOrder.Find ((x) => x.Product == product);
		if (order != null) {
			order.Num++;
		} else {
			ProductStock stock = new ProductStock (product, 1);
			CurrentOrder.Add (stock);
			GameObject cartItem_GO = Instantiate (CartItem_GO, CartContent.transform) as GameObject;
			CartItem cartItem = cartItem_GO.GetComponent<CartItem> ();
			cartItem.Setup ();
			cartItem.SetProductStock (stock);
		}
	}

	public void CancelProductOrder(Product product) {
		Debug.Log ("Cancelling 1 Order: " + product.Name);
		ProductStock order = CurrentOrder.Find ((x) => x.Product == product);
		if (order != null) {
			order.Num--;
			if (order.Num == 0) {
				CurrentOrder.Remove (order);
			}
		}
		if (CurrentOrder.Count == 0) {
			GameEventScheduler.instance.CancelGameEvent (new OrderDeliveryEvent());
		}
	}
}
