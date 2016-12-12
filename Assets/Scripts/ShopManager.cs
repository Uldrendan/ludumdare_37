using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public static ShopManager instance;

	public List<ShopItem> Stock;
	public List<ProductStock> CurrentOrder;

	public GameObject ShopItem_GO;
	public GameObject CartItem_GO;
	public GameObject ShopContent;
	public GameObject CartContent;

	public GameObject CartCost;
	private Text _costText;

	// Use this for initialization
	void Start () {

		if (instance != null)
			Destroy(instance);
		else
			instance = this;


		_costText = CartCost.GetComponent<Text> ();
		Stock = new List<ShopItem> ();
		CurrentOrder = new List<ProductStock> ();
		AddProduct (SaladProduct.CreateInstance<SaladProduct>());
		AddProduct (ColdPizzaProduct.CreateInstance<ColdPizzaProduct>());
		AddProduct (HotPocketsProduct.CreateInstance<HotPocketsProduct>());
		AddProduct (EnergyDrinkProduct.CreateInstance<EnergyDrinkProduct>());
	}

	void Update () {
		_costText.text = GetCartPrice ().ToString("c2") + " / " + GameMaster.instance.Money.ToString("c2");
	}

	float GetCartPrice() {
		float total = 0;
		if (CurrentOrder != null) {
			foreach (ProductStock stock in CurrentOrder) {
				total += stock.GetTotalCost ();
			}
		}
		return total;
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
		if (CurrentOrder == null || CurrentOrder.Count == 0) {
			CurrentOrder = new List<ProductStock> ();
			GameEventScheduler.instance.ScheduleGameEvent (new OrderDeliveryEvent(new GameTimeSpan(0,2)));
		}
		if (GetCartPrice () + product.Cost <= GameMaster.instance.Money) {
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
		} else {
			Debug.Log ("Not Enough Dough");
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

	public void DeliverCart () {
		if (GameMaster.instance.Money >= GetCartPrice ()) {
			foreach (ProductStock stock in CurrentOrder) {
				ProductStock match = GameMaster.instance.Inventory.Find ((x) => x.IsSameProduct (stock));
				if (match != null) {
					match.Add (stock);
				} else {
					GameMaster.instance.Inventory.Add (stock);
				}
			}
			GameMaster.instance.Money -= GetCartPrice ();
			EmptyCart ();
		} else {
			Debug.Log ("Not enough money to pay for order!");
		}
	}

	public void EmptyCart () {
		CurrentOrder = new List<ProductStock>();
		foreach (Transform child in CartContent.transform) {
			Destroy (child.gameObject);
		}
	}
}
