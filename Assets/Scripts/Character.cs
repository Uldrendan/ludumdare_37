using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles character behaviour and positioning in game world
public class Character : MonoBehaviour {
    
    public enum Locations { Desk, Bed, Washroom, Kitchen, FrontDoor, Center }

    private Animator _animator;

    // set in inspector with children of Waypoints prefab, same order as enum Locations
    public Transform[] Points; 

	// Use this for initialization
	void Start () {
        _animator = this.GetComponent<Animator>();
        Idle();
    }

    // Update is called once per frame
    void Update () {
	}

    public void Idle()
    {
        _animator.SetInteger("computerMode", 0);
    }

    public void Play()
    {
        _animator.SetInteger("computerMode", 1);
    }

    public void Work() {
        _animator.SetInteger("computerMode", 2);
    }
}
