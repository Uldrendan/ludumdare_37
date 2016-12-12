using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles character behaviour and positioning in game world
public class Character : MonoBehaviour {

	public static Character instance;
    
    public enum Locations { Desk, Bed, Washroom, Kitchen, FrontDoor, Center }

    private Animator _animator;

    // set in inspector with children of Waypoints prefab, same order as enum Locations
    public Transform[] Points; 

	// Use this for initialization
	void Start () {
		if (instance != null)
			Destroy(instance);
		instance = this;

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

    public void Sleep() {
        this.transform.position = Points[(int)Locations.Bed].position;
        _animator.SetBool("isSleeping", true);        
    }

    public void Wake()
    {
        _animator.SetBool("isSleeping", false);
    }

    public void Cook()
    {
        transform.position = Points[(int)Locations.Kitchen].position;
        _animator.SetBool("isCooking", true);        
    }

    public void Eat()
    {
        _animator.SetBool("isCooking", false);
    }

    public void OpenDoor()
    {
        transform.position = Points[(int)Locations.FrontDoor].position;
        _animator.SetBool("isAnswering", true);        
    }

    public void CloseDoor()
    {
        _animator.SetBool("isAnswering", false);
    }

    public void EnterWashroom()
    {
        transform.position = Points[(int)Locations.Washroom].position;
        _animator.SetBool("isWashroom", true);        
    }

    public void ExitWashroom()
    {
        _animator.SetBool("isWashroom", false);
    }

    public void Resume() {
        // resumes last at-desk state
        this.transform.position = Points[(int)Locations.Desk].position;
        if (GameMaster.instance.currentActivity == "Play")
            Play();
        else if (GameMaster.instance.currentActivity == "Work")
            Work();
        else
            Idle();
    }
}
