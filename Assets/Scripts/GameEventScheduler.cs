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
				if (ge.StartTime.CompareTo (GameDateTime.Now()) < 0) {
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
	public GameDateTime StartTime;
	public GameDateTime EndTime;

	public GameEvent () {
		StartTime = GameDateTime.Now ();
		EndTime = StartTime;
	}

	public GameEvent (GameDateTime startTime, GameDateTime endTime) {
		StartTime = startTime;
		EndTime = endTime;
	}

	public GameEvent (GameTimeSpan timeUntilEvent, GameTimeSpan eventLength) {
		StartTime = GameDateTime.Now().Add (timeUntilEvent);
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
	public TestEvent (GameDateTime startTime, GameDateTime endTime) : base (startTime,endTime) {}
	public TestEvent (GameTimeSpan timeUntilEvent, GameTimeSpan eventLength) : base (timeUntilEvent, eventLength) {}

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
	public OrderDeliveryEvent (GameDateTime startTime) : base (startTime,startTime) {}
	public OrderDeliveryEvent (GameTimeSpan timeUntilEvent) : base (timeUntilEvent, GameTimeSpan.Zero()) {}

	public override void Enter () {
		List<ProductStock> order = ShopManager.instance.CurrentOrder;
		ShopManager.instance.DeliverCart ();
	}

	public override void Exit () {

	}
}

public class GameDateTime {
	public int Day;
	public int Hour;

	public GameDateTime(int day, int hour) {
		Day = day;
		Hour = hour;
		Validate ();
	}

	public void Validate () {
		while (Hour >= 24) {
			Hour -= 24;
			Day++;
		}

		while (Hour < 0) {
			Hour += 24;
			Day--;
		}
	}

	public static GameDateTime Now () {
		return new GameDateTime (GameMaster.instance.currentDay, GameMaster.instance.currentTime);
	}

	public GameDateTime Add (GameTimeSpan span) {
		GameDateTime newDateTime = this;
		newDateTime.Day += span.Days;
		newDateTime.Hour += span.Hours;
		newDateTime.Validate ();
		return newDateTime;
	}

	public GameTimeSpan Difference (GameDateTime dateTime) {
		GameDateTime smaller;
		GameDateTime larger;
		if (CompareTo (dateTime) < 0) {
			smaller = this;
			larger = dateTime;
		} else {
			smaller = dateTime;
			larger = this;
		}

		int days = larger.Day - smaller.Day;
		int hours = larger.Hour - smaller.Hour;
		return new GameTimeSpan (days, hours);
	}

	public int CompareTo (object obj) {
		if (!(obj is GameDateTime)) {
			return 2;
		}
		GameDateTime dateTime = (GameDateTime)obj;
		if (Day > dateTime.Day) {
			return 1;
		} else if (Day < dateTime.Day) {
			return -1;
		} else {
			if (Hour > dateTime.Hour) {
				return 1;
			} else if (Hour < dateTime.Hour) {
				return -1;
			} else {
				return 0;
			}
		}
	}
}

public class GameTimeSpan {
	public int Days;
	public int Hours;

	public GameTimeSpan(int days, int hours) {
		Days = days;
		Hours = hours;
		Validate ();
	}

	public void Validate () {
		while (Hours >= 24) {
			Hours -= 24;
			Days++;
		}

		while (Hours < 0) {
			Hours += 24;
			Days--;
		}
	}

	public static GameTimeSpan Zero () {
		return new GameTimeSpan (0, 0);
	}
}