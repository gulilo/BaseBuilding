using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildingSpotScript : MouduleScript
{
	public GameObject panel;
	public GameObject modulePrefab;

	public int x;
	public int y;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void build()
	{
		Debug.Log("tring to build");
		GameObject ob = Instantiate(modulePrefab, transform.position, transform.rotation);
		ob.GetComponent<MouduleScript>().init(x, y);
		Destroy(gameObject);
	}
}
