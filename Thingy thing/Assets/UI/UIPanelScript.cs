using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelScript : MonoBehaviour
{
	public Need need;
	public Mudule mudule;
	public GameManeger gm;

	void Start()
	{
		Resorce r = gm.levels[gm.currentLevel].needToResorce(need);

		Text income = transform.GetChild(3).GetComponent<Text>();
		income.text = ""+r.Income;
		Text outcome = transform.GetChild(4).GetComponent<Text>();// fix hard code later
		outcome.text = "" + r.Outcome;

		Button button = transform.GetChild(0).GetComponent<Button>();
		button.onClick.AddListener(() => { gm.GetComponent<GameManeger>().build(mudule); });

		button.transform.GetChild(0).GetComponent<Text>().text = mudule.name;

		r.incomeChanged += (sender, args) => { income.text = ""+args.amount; };
		r.outcomeChanged += (sender, args) => { outcome.text = ""+args.amount; };
	}
}
