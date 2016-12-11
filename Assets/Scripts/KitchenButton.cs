using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenButton : MonoBehaviour {

	GameObject contextMenu;

	void Start()
	{
		contextMenu = transform.parent.gameObject;
	}

	public void EatSalad()
	{
		SaladProduct salad = new SaladProduct();
		salad.OnUse();
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}

	public void EatPocket()
	{
		HotPocketsProduct pocket = new HotPocketsProduct();
		pocket.OnUse();
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}

	public void EatPizza()
	{
		ColdPizzaProduct pizza = new ColdPizzaProduct();
		pizza.OnUse();
		contextMenu.SetActive(false);
		GameMaster.instance.ClearContext();
	}
}
