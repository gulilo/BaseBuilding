using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuFiller : MonoBehaviour {

	public UIBuilding ui;
	public List<Mudule> mudules;
	public GameObject ButtonPrefab;

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < mudules.Count;i++)
		{
			GameObject go =  Instantiate(ButtonPrefab, transform);
		
			go.GetComponent<BuldingManuButton>().ui = ui;
			go.GetComponent<BuldingManuButton>().mudule = mudules[i];
			go.GetComponentInChildren<Text>().text = mudules[i].name;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
