using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles character behaviour and positioning in game world
public class Character : MonoBehaviour {

    public enum ComputerState { Idle, Gaming, Working }
    public enum Locations { Desk, Bed, Washroom, Kitchen, FrontDoor, Center}

    // set in inspector with children of Waypoints prefab, same order as enum Locations
    public Transform[] Points; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
