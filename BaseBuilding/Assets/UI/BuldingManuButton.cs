using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldingManuButton : MonoBehaviour
{
	public Mudule mudule;
	public GameManeger gm;
	public UIBuilding ui;
	
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void clicked()
	{
		ui.build(mudule);
	}
}
