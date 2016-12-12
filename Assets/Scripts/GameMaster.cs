using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	public static GameMaster instance;

	float energy = 100;
	public float Energy{ get { return energy; } set { energy = Mathf.Clamp(value, 0, 100); } }

	float hygiene = 100;
	public float Hygiene { get { return hygiene; } set { hygiene = Mathf.Clamp(value, 0, 100); } }

	float hunger = 100;
	public float Hunger { get { return hunger; } set { hunger = Mathf.Clamp(value, 0, 100); } }

	float bathroom = 100;
	public float Bathroom { get { return bathroom; } set { bathroom = Mathf.Clamp(value, 0, 100); } }

	float progress;
	public float Progress { get { return progress; } set { progress = Mathf.Clamp(value, 0, 100); } }

	float money = 50;
	public float Money { get { return money; } set { money = Mathf.Max(value, 0); } }

	public int currentDay = 1;
	public int currentTime;

    public GameObject Chara;

	public List<ProductStock> Inventory;

	public GameObject currentContext;

	float timer;
	bool paused; //to pause the update loop functions (for game over or possible pause menu)

	public string currentActivity;

	void Start () {
		Time.timeScale = 1;

		if (instance != null)
			Destroy(instance);
		else
			instance = this;

		Inventory = new List<ProductStock> ();
	}

	void Update()
	{
		if (!paused)
		{
			energy -= Time.deltaTime;
			hygiene -= Time.deltaTime;
			hunger -= Time.deltaTime;
			bathroom -= Time.deltaTime;

			if (currentActivity == "Play")
			{
				progress += Time.deltaTime;
				Chara.GetComponent<Character>().Play();
			}
			if (currentActivity == "Work")
			{
				money += Time.deltaTime;
				Chara.GetComponent<Character>().Work();
			}

			if (progress >= 100)
			{
				paused = true;
				Time.timeScale = 0;
				GameMessage.instance.PostGameMessage("You win!", true);
			}

			if (energy <= 0 || hygiene <= 0 || hunger <= 0 || bathroom <= 0)
			{
				paused = true;
				Time.timeScale = 0;
				if(energy <= 0)
					GameMessage.instance.PostGameMessage("After your marathon gaming session you fall into an energy drink fueled coma. You lose...", true);
				else if(hygiene <= 0)
					GameMessage.instance.PostGameMessage("The filth that was once your ally has turned against you. You lose...", true);
				else if(hunger <= 0)
					GameMessage.instance.PostGameMessage("In a hunger induced rage you leave the house to scavenge. " +
					                                     "You are mistaken for a bear and released into the forest. You lose...", true);
				else if(bathroom <= 0)
					GameMessage.instance.PostGameMessage("You've had an unfortunate accident. You leave the house to purchase new pants " +
					                                     "where you die from embarassment. You lose...", true);
			}

			HandleTimer();
			CheckClick();
		}
	}

	void HandleTimer () {
		timer += Time.deltaTime;
		if (timer >= 1)
		{
			if (currentTime < 23)
				currentTime += 1;
			else
			{
				currentDay += 1;
				currentTime = 0;
			}
			timer = 0;
		}
	}

	public int GetStock(Product product) {
		ProductStock match = Inventory.Find ((x) => x.Product.GetType () == product.GetType ());
		if (match != null) {
			return match.Num;
		} else {
			return 0;
		}
	}

	public void UseProduct(Product product) {
		ProductStock match = Inventory.Find ((x) => x.Product.GetType () == product.GetType ());
		if (match != null && match.Num > 0) {
			match.Product.OnUse ();
			match.Num--;
			if (match.Num == 0) {
				Inventory.Remove (match);
			}
		} else {
			Debug.LogError ("Shouldnt be able to use if you dont have any");
		}
	}

	void CheckClick () {
		if (Input.GetMouseButtonDown (0)) {
			if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			{
				Debug.Log("Selecting context menu option");
				return;
			}
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000f)) {
				Debug.Log ("Clicked " + hit.collider.gameObject.name);
				Transform obj = hit.collider.transform;
				Interactable interactable = obj.GetComponent<Interactable> ();
				while (interactable == null && obj.transform.parent != null) {
					obj = obj.transform.parent;
					Debug.Log ("Checking parent " + obj.name + " for Interactable");
					interactable = obj.GetComponent<Interactable> ();
				}
				if (interactable != null) {
					Debug.Log ("Interactable");
					interactable.OnClick ();
				} else {
					ClearContext();
					Debug.Log("NOT Interactable");
				}
			} else {
				Debug.Log ("Clicked EMPTY SPACE");
			}
		}
	}

	public void ClearContext()
	{
		if (currentContext != null)
			currentContext.SetActive(false);
		currentContext = null;
	}
}