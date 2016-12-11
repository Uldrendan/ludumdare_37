using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartItem : Button {

	public ProductStock ProductStock;
	public Image Icon;
	public Text Amount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Amount.text = "x" + ProductStock.Num;
	}

	public void SetProductStock(ProductStock productStock) {
		ProductStock = productStock;
		Amount.text = "x" + productStock.Num;
		Icon.sprite = productStock.Product.Icon;
	}

	public void Setup() {
		Icon = transform.Find ("Icon").GetComponent<Image> ();
		Amount = transform.Find ("Amount").GetComponent<Text> ();
		transform.localScale = new Vector3 (1, 1, 1);
		onClick.AddListener (() => ShopManager.instance.CancelProductOrder(ProductStock.Product));
	}
}
