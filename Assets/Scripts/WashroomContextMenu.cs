using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceContextMenu : MonoBehaviour {

	public GameObject ShowerButton_GO;
	public GameObject BrushTeethButton_GO;
	public GameObject ToiletButton_GO;

	public DoActionButton ShowerButton;
	public DoActionButton BrushTeethButton;
	public DoActionButton ToiletButton;

	// Use this for initialization
	void Start () {
		ShowerButton = PlayButton_GO.GetComponent<DoActionButton>();
		ShowerButton.SetAction(ScriptableObject.CreateInstance<PlayAction>());
		BrushTeethButton = WorkButton_GO.GetComponent<DoActionButton>();
		BrushTeethButton.SetAction(ScriptableObject.CreateInstance<WorkAction>());
		ToiletButton = ShopButton_GO.GetComponent<ShopButton>();
		ToiletButton.SetAction(ScriptableObject.CreateInstance<WorkAction>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
