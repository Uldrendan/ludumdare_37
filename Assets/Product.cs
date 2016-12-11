using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Product : ScriptableObject {
	public string Name;
	public string Description;
	public float Cost;
	public Sprite Icon;

	public abstract void OnUse ();
}

public class SaladProduct : Product {
	public SaladProduct () {
		Name = "Salad";
		Description = "The healthy alternative.";
		Cost = 20;
		Icon = Resources.Load ("salad_icon") as Sprite;
	}

	public override void OnUse () {

	}
}

public class HotPocketsProduct : Product {
	public HotPocketsProduct () {
		Name = "Hot Pockets";
		Description = "Scalding hot, then freezing cold.";
		Cost = 5;
		Icon = Resources.Load ("salad_icon") as Sprite;
	}

	public override void OnUse () {

	}
}

public class ColdPizzaProduct : Product {
	public ColdPizzaProduct () {
		Name = "Cold Pizza";
		Description = "An explosion of flavour!";
		Cost = 10;
		Icon = Resources.Load ("salad_icon") as Sprite;
	}

	public override void OnUse () {

	}
}

public class EnergyDrinkProduct : Product {
	public EnergyDrinkProduct () {
		Name = "Energy Drink";
		Description = "Helps you stay awake!";
		Cost = 20;
		Icon = Resources.Load ("salad_icon") as Sprite;
	}

	public override void OnUse () {
		
	}
}

public class ProductStock : ScriptableObject {
	public int Num;
	public Product Product;

	public ProductStock(Product product, int num) {
		Product = product;
		Num = num;
	}
}