using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuilding : MonoBehaviour
{
	public GameObject moudulePrefab;

	public GameObject selected;
	public GameManeger gm;
	public GameObject buldingPanel;

	public List<MouduleScript> moudules;

	void Start () 
	{
		gm.levels[gm.currentLevel].builded += (sender, args) =>
		{
			Instantiate(moudulePrefab);
		}
		GameObject ob = Instantiate(moudulePrefab);
		moudules.Add(ob.GetComponent<MouduleScript>());
		for(int i = 0;i < moudules.Count;i++)
		{
			register(moudules[i]);
		}
	}

	private void register(MouduleScript moudule)
	{
		moudule.clicked += (sender,args)=> 
		{
			
			Debug.Log("here");
			if(sender is BuildingSpotScript)
			{
				selected = (GameObject)sender;
				buldingPanel.SetActive(true);
			}
		};
	}

	public void select( GameObject go)
	{
		selected = go;
	}

	public void build(Mudule m)
	{
		if(selected != null)
		{
			gm.build(m);
			selected.GetComponent<BuildingSpotScript>().build();
		}
	}
}
