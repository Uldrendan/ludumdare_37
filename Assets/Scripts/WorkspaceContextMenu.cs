using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceContextMenu : MonoBehaviour {

	public GameObject PlayButton_GO;
	public GameObject WorkButton_GO;
	public GameObject ShopButton_GO;

	public DoActionButton PlayButton;
	public DoActionButton WorkButton;
	public ShopButton ShopButton;

	// Use this for initialization
	void Start () {
		PlayButton = PlayButton_GO.GetComponent<DoActionButton>();
		PlayButton.SetAction(ScriptableObject.CreateInstance<PlayAction>());
		WorkButton = WorkButton_GO.GetComponent<DoActionButton>();
		WorkButton.SetAction(ScriptableObject.CreateInstance<WorkAction>());
		ShopButton = ShopButton_GO.GetComponent<ShopButton>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
