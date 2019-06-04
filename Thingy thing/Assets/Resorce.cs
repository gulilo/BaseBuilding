using System.Collections.Generic;
using System;
using UnityEngine;

public class Resorce
{
	public Need need;

	private int income;
	public int Income
	{
		get
		{
			return income;
		}
		set
		{
			income = value;
			fixNeeds();
			if (incomeChanged != null)
				incomeChanged(this, new Args(value));
		}
	}

	private int outcome;
	public int Outcome
	{
		get
		{
			return outcome;
		}
		set
		{
			outcome = value;
			if (outcomeChanged != null)
				outcomeChanged(this, new Args(value));
		}
	}

	public EventHandler<Args> incomeChanged;
	public EventHandler<Args> outcomeChanged;

	public List<Building> outputers;
	public List<Building> inputers;

	public Resorce(Need need)
	{
		this.need = need;
		outputers = new List<Building>();
		inputers = new List<Building>();
	}

	public class Args : EventArgs
	{
		public float amount { get; private set; }

		public Args(float amount)
		{
			this.amount = amount;
		}
	}

	public void fixNeeds()
	{
		Queue<Resorce> queue = new Queue<Resorce>();
		queue.Enqueue(this);
		//Debug.Log(need.name + "  " + outcome);
		if(outcome != 0)
		{
			float amount = (float)income / (float)outcome;
			//Debug.Log(amount);
			for (int i = 0; i < inputers.Count; i++)
			{
				inputers[i].giveNeed(this, amount, GameManeger.instance.levels[GameManeger.instance.currentLevel]);//temp
			}
		}
	}
}
