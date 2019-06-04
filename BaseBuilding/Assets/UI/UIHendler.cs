using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIHendler : MonoBehaviour
{
	public GameManeger gameMaster;

	public Text money;

	// Use this for initialization
	void Start ()
	{
		gameMaster.moneyChanged += (sender, args) => { money.text ="" + args.amount;};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
