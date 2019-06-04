using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
	public Mudule mudule;

	public int level;
	public int multi;

	public List<int> bonus;
	public List<float> haveAmounts;

	public Building(Mudule mudule)
	{
		this.mudule = mudule;
		bonus = new List<int>();
		haveAmounts = new List<float>();
		for(int i = 0; i < mudule.needs.Count;i++)
		{
			bonus.Add(0);
			haveAmounts.Add(0);
		}
		multi = 100;
		level = 1;
	}

	public int getOutput()
	{
		float temp = 1;
		for (int i = 2; i <= level; i++)
		{
			temp = temp * (1 + (i / 10));
		}
		return (int)(mudule.outputAmount * temp * multi / 100);
	}

	public void setmultiplier()
	{
		float temp = 0;
		for (int i = 0; i < mudule.needs.Count; i++)
		{
			temp = temp + (Mathf.Pow(haveAmounts[i],1.6f) * mudule.bonus[i]);
		}
		multi = (int)temp + 100;
	}

	public void giveNeed(Resorce need, float amount, Level level)
	{
        //Debug.Log("before output" + getOutput());
		int before = getOutput();
		//Debug.Log(amount);
		amount = Mathf.Min((float)1, amount);
        //Debug.Log("amount after min " + amount);
		for (int i = 0; i < mudule.needs.Count; i++)
		{
			if (need.need.name == mudule.needs[i].name)
			{
                //Debug.Log ("foud it");
				haveAmounts[i] = amount;
				break;
			}
		}
		setmultiplier();
		//int bla = getOutput() - before;
		//Debug.Log(bla);
		level.needToResorce(mudule.output).Income += getOutput() - before; 
	}

	public int getNeededResource(int index)
	{
		float temp = 1;
		for (int i = 2; i <= level; i++)
		{
			temp = temp * (1 + ((i-1) / 10));
		}
		return (int)(mudule.needsAmount[index] * temp);
	}
}
