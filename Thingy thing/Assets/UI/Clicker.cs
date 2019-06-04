using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
	public static Clicker instance;
	public GameObject panelparet;
	public GameObject panel;
	public GameObject core;
	// Use this for initialization
	void Start()
	{
		instance = this;
		//core.GetComponent<MouduleScript>().init(25, 25);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (panelparet.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition, null))
			{
				panelparet.SetActive(false);
			}
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.Log("bla");
			if (Physics.Raycast(ray, out hit, 1000))
			{
				//Debug.Log("bla3");
				if (hit.transform.tag == "BuildingSpot")
				{
				//	Debug.Log("bla2");
					hit.transform.GetComponent<BuildingSpotScript>().click();
				}
			}

		}
	}
}
