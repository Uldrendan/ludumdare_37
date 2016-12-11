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
		GameMaster.instance.Hunger += 20;
		GameMaster.instance.Energy += 10;
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
		GameMaster.instance.Hunger += 10;
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
		GameMaster.instance.Hunger += 30;
		GameMaster.instance.Hygiene -= 20;
	}
}