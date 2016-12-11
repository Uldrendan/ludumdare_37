using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

	public List<ShopItem> Stock;
	public List<ProductStock> CurrentOrder;

	public GameObject ShopItem_GO;
	public GameObject ShopContent;

	// Use this for initialization
	void Start () {
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

	void OrderProduct(Product product) {
		if (CurrentOrder == null) {
			CurrentOrder = new List<ProductStock> ();
			GameEventScheduler.instance.ScheduleGameEvent (new OrderDeliveryEvent(TimeSpan.FromSeconds(10)));
		}
		ProductStock order = CurrentOrder.Find ((x) => x.Product == product);
		if (order != null) {
			order.Num++;
		} else {
			CurrentOrder.Add (new ProductStock (product, 1));
		}
	}

	void CancelProductOrder(Product product) {
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
