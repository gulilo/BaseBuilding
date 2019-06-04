using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouduleScript : MonoBehaviour
{
	static bool[,] bla = new bool[50, 50];
	static int coreIndexX = 25;
	static int coreIndexY = 25;

	public GameObject BuildingSpotpreFab;
	public int indexX;
	public int indexY;

	public EventHandler clicked;
	public EventHandler builded;

	public void init(int x, int y)
	{
		indexX = x;
		indexY = y;
		bla[x, y] = true;
	}

	void Start()
	{
		addspot(0, 1);
		addspot(0, -1);
		addspot(1, 0);
		addspot(-1, 0);
	}

	private void addspot(int x, int y)
	{
		if (!bla[indexX + x, indexY + y])
		{
			Vector3 pos = new Vector3(transform.position.x + (transform.localScale.x * x), transform.position.y + (transform.localScale.y * y), 0);
			GameObject ob = Instantiate(BuildingSpotpreFab, pos, Quaternion.identity);

			ob.GetComponent<BuildingSpotScript>().x = indexX + x;
			ob.GetComponent<BuildingSpotScript>().y = indexY + y;
			
			if(builded != null)
			{
				builded(this, new Args(ob));
			}

			bla[indexX + x, indexY + y] = true;
		}
	}

	public void click()
	{
		Debug.Log("click");
		if (clicked != null)
		{
			clicked(this, null);
		}
	}

	public class Args : EventArgs
	{
		GameObject ob { get; set; }

		public Args(GameObject ob)
		{
			this.ob = ob;
		}
	}
}
