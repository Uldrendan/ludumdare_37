using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
	public const float OVERALL_MODIFIER = 1;
	public const float HYGIENE_MODIFIER = 100f/36f;
	public const float BRUSH_TEETH_MODIFIER = 100;
	public const float SHOWER_MODIFIER = 100f/3f;
	public const float BATHROOM_MODIFIER = 100f/12f;
	public const float TOILET_MODIFIER = 100;
	public const float HUNGER_MODIFIER = 100f/24f;
	public const float ENERGY_MODIFIER = 100/18f;
	public const float SLEEP_MODIFIER = 100f/12f;
	public const float SLEEP_METABOLISM_MODIFIER = 0.1f;
	public const float MONEY_MODIFIER = 1;
	public const float PROGRESS_MODIFIER = 1;

	public virtual void Enter() { }

	public abstract void Do();

	public abstract bool ExitCriteria();

	public virtual void Exit() { }
}

public class ShowerAction : Action
{
	float timer;

	public override void Enter ()
	{
		Debug.Log ("SHOWER");
		Character.instance.EnterWashroom ();
		Washroom.instance.ShutDoor ();
		Washroom.instance.ShowerOn ();
	}

	public override void Exit ()
	{
		Debug.Log ("SHOWER END");
		Character.instance.ExitWashroom ();
		Washroom.instance.ShowerOff ();
		Character.instance.WhiffSound ();
	}

	public override void Do()
	{
		timer += Time.deltaTime;
		GameMaster.instance.Hygiene += Time.deltaTime * OVERALL_MODIFIER * SHOWER_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Energy -= Time.deltaTime * OVERALL_MODIFIER * ENERGY_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hunger -= Time.deltaTime * OVERALL_MODIFIER * HUNGER_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Bathroom -= Time.deltaTime * OVERALL_MODIFIER * BATHROOM_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
	}

	public override bool ExitCriteria()
	{
		if (timer >= 3 || GameMaster.instance.Hygiene == 100)
			return true;
		return false;
	}
}

public class BrushTeethAction : Action
{
	float timer;
	float startingHygiene;

	public override void Enter ()
	{
		startingHygiene = GameMaster.instance.Hygiene;
		Character.instance.EnterWashroom ();
		Washroom.instance.SinkOn ();
		Washroom.instance.ShutDoor ();
	}

	public override void Exit ()
	{
		Character.instance.ExitWashroom ();
		Washroom.instance.SinkOff ();
		Character.instance.WhiffSound ();

	}

	public override void Do()
	{
		timer += Time.deltaTime;
		GameMaster.instance.Hygiene += Time.deltaTime * OVERALL_MODIFIER * BRUSH_TEETH_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Energy -= Time.deltaTime * OVERALL_MODIFIER * ENERGY_MODIFIER  / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hunger -= Time.deltaTime * OVERALL_MODIFIER * HUNGER_MODIFIER  / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Bathroom -= Time.deltaTime * OVERALL_MODIFIER * BATHROOM_MODIFIER  / GameMaster.REALTIMESECONDS_PER_HOUR;
	}

	public override bool ExitCriteria()
	{
		if (GameMaster.instance.Hygiene >= (Mathf.Min(100,startingHygiene+20)))
			return true;
		return false;
	}
}

public class ToiletAction : Action 
{
	public override void Enter ()
	{
		Character.instance.EnterWashroom ();
		Washroom.instance.ShutDoor ();
		Washroom.instance.UseToilet ();
	}

	public override void Exit ()
	{
		Character.instance.ExitWashroom ();
		Washroom.instance.FlushToilet ();
		Character.instance.WhiffSound ();
	}

	public override void Do()
	{
		GameMaster.instance.Hygiene -= Time.deltaTime * OVERALL_MODIFIER * HYGIENE_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Energy -= Time.deltaTime * OVERALL_MODIFIER * ENERGY_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hunger -= Time.deltaTime * OVERALL_MODIFIER * HUNGER_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Bathroom += Time.deltaTime * OVERALL_MODIFIER * TOILET_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
	}

	public override bool ExitCriteria()
	{
		if (GameMaster.instance.Bathroom >= 100)
			return true;
		return false;
	}
}

public class WorkAction : Action
{
	public override void Enter ()
	{
		Workspace.instance.StartTyping ();
	}

	public override void Exit ()
	{
		Workspace.instance.StopKeyboardSounds ();
	}

	public override void Do()
	{
		GameMaster.instance.Money += Time.deltaTime * OVERALL_MODIFIER * MONEY_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hygiene -= Time.deltaTime * OVERALL_MODIFIER * HYGIENE_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Energy -= Time.deltaTime * OVERALL_MODIFIER * ENERGY_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hunger -= Time.deltaTime * OVERALL_MODIFIER * HUNGER_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Bathroom -= Time.deltaTime * OVERALL_MODIFIER * BATHROOM_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
	}

	public override bool ExitCriteria()
	{
		return false;
	}
}

public class PlayAction : Action
{
	public override void Enter ()
	{
		Workspace.instance.StartMashing ();
	}

	public override void Exit ()
	{
		Workspace.instance.StopKeyboardSounds ();
	}

	public override void Do()
	{
		GameMaster.instance.Progress += Time.deltaTime * OVERALL_MODIFIER * PROGRESS_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hygiene -= Time.deltaTime * OVERALL_MODIFIER * HYGIENE_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Energy -= Time.deltaTime * OVERALL_MODIFIER * ENERGY_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hunger -= Time.deltaTime * OVERALL_MODIFIER * HUNGER_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Bathroom -= Time.deltaTime * OVERALL_MODIFIER * BATHROOM_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
	}

	public override bool ExitCriteria()
	{
		return false;
	}
}

public class IdleAction : Action
{
	public override void Do()
	{
		GameMaster.instance.Hygiene -= Time.deltaTime * OVERALL_MODIFIER * HYGIENE_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Energy -= Time.deltaTime * OVERALL_MODIFIER * ENERGY_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hunger -= Time.deltaTime * OVERALL_MODIFIER * HUNGER_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Bathroom -= Time.deltaTime * OVERALL_MODIFIER * BATHROOM_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
	}

	public override bool ExitCriteria()
	{
		return false;
	}
}

public class SleepAction : Action
{
	public override void Enter ()
	{
		Character.instance.WhiffSound ();
		Bed.instance.BeginSnoring ();
	}

	public override void Exit ()
	{
		Character.instance.WhiffSound ();
		Bed.instance.StopSnoring ();
	}

	public override void Do()
	{
		GameMaster.instance.Hygiene -= Time.deltaTime * OVERALL_MODIFIER * SLEEP_METABOLISM_MODIFIER * HYGIENE_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Energy += Time.deltaTime * OVERALL_MODIFIER * SLEEP_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Hunger -= Time.deltaTime * OVERALL_MODIFIER * SLEEP_METABOLISM_MODIFIER * HUNGER_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
		GameMaster.instance.Bathroom -= Time.deltaTime * OVERALL_MODIFIER * SLEEP_METABOLISM_MODIFIER * BATHROOM_MODIFIER / GameMaster.REALTIMESECONDS_PER_HOUR;
	}

	public override bool ExitCriteria()
	{
		if (GameMaster.instance.Energy >= 100)
			return true;
		return false;
	}
}