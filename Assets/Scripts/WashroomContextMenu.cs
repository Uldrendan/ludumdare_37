using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashroomContextMenu : MonoBehaviour {

	public GameObject ShowerButton_GO;
	public GameObject BrushTeethButton_GO;
	public GameObject ToiletButton_GO;

	public DoActionButton ShowerButton;
	public DoActionButton BrushTeethButton;
	public DoActionButton ToiletButton;

	// Use this for initialization
	void Start () {
		ShowerButton = ShowerButton_GO.GetComponent<DoActionButton>();
		ShowerButton.SetAction(ScriptableObject.CreateInstance<ShowerAction>());
		BrushTeethButton = BrushTeethButton_GO.GetComponent<DoActionButton>();
		BrushTeethButton.SetAction(ScriptableObject.CreateInstance<BrushTeethAction>());
		ToiletButton = ToiletButton_GO.GetComponent<DoActionButton>();
		ToiletButton.SetAction(ScriptableObject.CreateInstance<ToiletAction>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
