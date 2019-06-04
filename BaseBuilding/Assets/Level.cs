using System.Collections.Generic;
using UnityEngine;
using System;

public class Level
{
	public int LevelNumber;
	public int currentMoney;
	public Resorce moneyResorce;

	public List<Resorce> resorces;
	public List<Building> buildings;
	public List<Building> buildingSpot;

	public EventHandler builded;

	public Level(int number, List<Need> needs, int startingMoney, Mudule core)
	{
		resorces = new List<Resorce>();
		buildings = new List<Building>();
		buildingSpot = new List<Building>();

		for (int i = 0; i < needs.Count; i++)
		{
			Resorce r = new Resorce(needs[i]);
			resorces.Add(r);
			if (needs[i].name == "Money")
			{
				moneyResorce = r;
			}
		}
		currentMoney = startingMoney;

		build(core);
	}

	public void build(Mudule mudule)
	{
		Building b = new Building(mudule);
		buildings.Add(b);

		Resorce r = needToResorce(mudule.output);
		r.Income += b.getOutput();
		r.outputers.Add(b);
		r.fixNeeds();

		for (int i = 0; i < mudule.needs.Count; i++)
		{
			r = needToResorce(mudule.needs[i]);

			r.Outcome += mudule.needsAmount[i];
			r.inputers.Add(b);
			r.fixNeeds();
		}

		currentMoney -= b.mudule.price;
		moneyResorce.Outcome += mudule.upkeep;
		if(builded != null)
		{
			builded(this, new BuildingArgs(mudule));
		}
	}

	public Resorce needToResorce(Need n)
	{
		for (int i = 0; i < resorces.Count; i++)
		{
			if (n == resorces[i].need)
			{
				return resorces[i];
			}
		}
		return null;
	}

	public class BuildingArgs : EventArgs
	{
		Mudule builded;

		public BuildingArgs(Mudule builded)
		{
			this.builded = builded;
		}
	}
}
