using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
	public virtual void Enter() { }

	public abstract void Do();

	public abstract bool ExitCriteria();

	public virtual void Exit() { }
}

public class ShowerAction : Action
{
	float timer;

	public override void Do()
	{
		timer += Time.deltaTime;
		GameMaster.instance.Hygiene += Time.deltaTime;
		GameMaster.instance.Energy -= Time.deltaTime;
		GameMaster.instance.Hunger -= Time.deltaTime;
		GameMaster.instance.Bathroom -= Time.deltaTime;
	}

	public override bool ExitCriteria()
	{
		if (timer >= 3 || GameMaster.instance.Hygiene == 100)
			return true;
		return false;
	}
}

public class WorkAction : Action
{
	public override void Do()
	{
		GameMaster.instance.Money += Time.deltaTime;
		GameMaster.instance.Hygiene -= Time.deltaTime;
		GameMaster.instance.Energy -= Time.deltaTime;
		GameMaster.instance.Hunger -= Time.deltaTime;
		GameMaster.instance.Bathroom -= Time.deltaTime;
	}

	public override bool ExitCriteria()
	{
		return false;
	}
}

public class PlayAction : Action
{
	public override void Do()
	{
		GameMaster.instance.Progress += Time.deltaTime;
		GameMaster.instance.Hygiene -= Time.deltaTime;
		GameMaster.instance.Energy -= Time.deltaTime;
		GameMaster.instance.Hunger -= Time.deltaTime;
		GameMaster.instance.Bathroom -= Time.deltaTime;
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
		GameMaster.instance.Hygiene -= Time.deltaTime;
		GameMaster.instance.Energy -= Time.deltaTime;
		GameMaster.instance.Hunger -= Time.deltaTime;
		GameMaster.instance.Bathroom -= Time.deltaTime;
	}

	public override bool ExitCriteria()
	{
		return false;
	}
}