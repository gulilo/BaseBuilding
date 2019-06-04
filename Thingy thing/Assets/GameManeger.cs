using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManeger : MonoBehaviour
{
	public static GameManeger instance;

	public Mudule core;
	public int tickTime = 1;//in seconds
	public int startingMoney = 10000;
	float timepassed = 0;

	public List<Need> needs; // temp

	public List<Level> levels;
	public int currentLevel;

	public EventHandler<MoneyArgs> moneyChanged;

	void Start()
	{
		instance = this;
		levels = new List<Level>();
		levels.Add(new Level(0, needs, startingMoney, core));
	}

	void Update()
	{
		float time = Time.deltaTime;
		timepassed += time;
		if (timepassed > tickTime)
		{
			timepassed = 0;
			Level l = levels[currentLevel];
			l.currentMoney += l.moneyResorce.Income;

			l.currentMoney -= l.moneyResorce.Outcome;

			if (moneyChanged != null)
			{
				moneyChanged(this, new MoneyArgs(l.currentMoney));
			}
		}
	}

	public void build(Mudule mudule)
	{
		levels[currentLevel].build(mudule);
	}

	public class MoneyArgs : EventArgs
	{
		public float amount { get; private set; }

		public MoneyArgs(float amount)
		{
			this.amount = amount;
		}
	}
}
