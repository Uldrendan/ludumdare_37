using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventScheduler : MonoBehaviour {

	public static GameEventScheduler instance;

	public List<GameEvent> ScheduledEvents;

	public List<GameEvent> CurrentEvents;

	// Use this for initialization
	void Start () {

		if (instance != null)
			Destroy(instance);
		instance = this;

		ScheduledEvents = new List<GameEvent> ();
		CurrentEvents = new List<GameEvent> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckScheduledEvents ();
		ExecuteCurrentEvents ();
		UpdateCurrentEvents ();
	}

	void CheckScheduledEvents() {
		bool eventsUpToDate = false;
		while (!eventsUpToDate) {
			GameEvent ge = ScheduledEvents.FirstOrDefault ();
			if (ge != null) {
				if (ge.StartTime.CompareTo (DateTime.Now) < 0) {
					ScheduledEvents.RemoveAt (0);
					CurrentEvents.Add (ge);
					CurrentEvents.Sort ((ge1, ge2) => ge1.EndTime.CompareTo (ge2.EndTime));
					ge.Enter();
				} else {
					eventsUpToDate = true;
				}
			} else {
				eventsUpToDate = true;
			}
		}
	}

	void ExecuteCurrentEvents() {
		foreach (GameEvent ge in CurrentEvents) {
			ge.Do ();
		}
	}

	void UpdateCurrentEvents() {
		bool eventsUpToDate = false;
		while (!eventsUpToDate) {
			GameEvent ge = CurrentEvents.FirstOrDefault ();
			if (ge != null) {
				if (ge.EndTime.CompareTo (DateTime.Now) < 0) {
					CurrentEvents.RemoveAt (0);
					ge.Exit ();
				} else {
					eventsUpToDate = true;
				}
			} else {
				eventsUpToDate = true;
			}
		}
	}

	public void ScheduleGameEvent(GameEvent ge) {
		ScheduledEvents.Add (ge);
		ScheduledEvents.Sort ((ge1, ge2) => ge1.StartTime.CompareTo (ge2.StartTime));
	}

	public void CancelGameEvent(GameEvent ge) {
		ScheduledEvents.FirstOrDefault ((x) => x.GetType() == ge.GetType());
	}
}

public abstract class GameEvent : ScriptableObject {
	public DateTime StartTime;
	public DateTime EndTime;

	public GameEvent () {
		StartTime = DateTime.Now;
		EndTime = StartTime;
	}

	public GameEvent (DateTime startTime, DateTime endTime) {
		StartTime = startTime;
		EndTime = endTime;
	}

	public GameEvent (TimeSpan timeUntilEvent, TimeSpan eventLength) {
		StartTime = DateTime.Now.Add (timeUntilEvent);
		EndTime = StartTime.Add (eventLength);
	}

	public virtual void Enter () {

	}
	public virtual void Do () {

	}
	public virtual void Exit() {

	}
}

public class TestEvent : GameEvent {
	public TestEvent () : base () {}
	public TestEvent (DateTime startTime, DateTime endTime) : base (startTime,endTime) {}
	public TestEvent (TimeSpan timeUntilEvent, TimeSpan eventLength) : base (timeUntilEvent, eventLength) {}

	public override void Enter () {
		Debug.Log ("You gonna die soon");
	}
	public override void Exit() {
		Debug.Log ("You died, ya bish");
	}
}

public class OrderDeliveryEvent : GameEvent {
	public OrderDeliveryEvent () : base () {}
	//Delivery events are always instantaneous;
	public OrderDeliveryEvent (DateTime startTime) : base (startTime,startTime) {}
	public OrderDeliveryEvent (TimeSpan timeUntilEvent) : base (timeUntilEvent, TimeSpan.Zero) {}

	public override void Enter () {
		List<ProductStock> order = ShopManager.instance.CurrentOrder;
		ShopManager.instance.DeliverCart ();
	}

	public override void Exit () {

	}
}

public class OnSleepEvent : GameEvent
{
    public OnSleepEvent() : base() { }
    public OnSleepEvent(TimeSpan timeUntilEvent) : base (timeUntilEvent, TimeSpan.Zero) { }
    public OnSleepEvent(DateTime startTime, DateTime endTime) : base(startTime, endTime) { }
    public OnSleepEvent(TimeSpan timeUntilEvent, TimeSpan eventLength) : base(timeUntilEvent, eventLength) { }

    public override void Do()
    {
        Debug.Log("Sleeping...");
    }
    public override void Exit()
    {
        Debug.Log("Waking up!");
        GameMaster.instance.Chara.GetComponent<Character>().Wake();
        GameMaster.instance.Chara.GetComponent<Character>().Resume();
    }
}