using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenContextMenu : MonoBehaviour {

	public GameObject HotPocketButton_GO;
	public GameObject ColdPizzaButton_GO;
	public GameObject GardenSaladButton_GO;

	private UseProductButton _hotPocketButton;
	private UseProductButton _coldPizzaButton;
	private UseProductButton _gardenSaladButton;

	// Use this for initialization
	void Start () {
		_hotPocketButton = HotPocketButton_GO.GetComponent<UseProductButton> ();
		_hotPocketButton.SetProduct( ScriptableObject.CreateInstance<HotPocketsProduct>());
		_coldPizzaButton = ColdPizzaButton_GO.GetComponent<UseProductButton> ();
		_coldPizzaButton.SetProduct( ScriptableObject.CreateInstance <ColdPizzaProduct>());
		_gardenSaladButton = GardenSaladButton_GO.GetComponent<UseProductButton> ();
		_gardenSaladButton.SetProduct (ScriptableObject.CreateInstance<SaladProduct>());

	}
}
