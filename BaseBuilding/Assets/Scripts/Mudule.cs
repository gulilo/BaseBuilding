using UnityEngine;
using System.Collections.Generic; 
[CreateAssetMenu(fileName = "Mudule", menuName = "Mudule", order = 1)]
public class Mudule : ScriptableObject
{
	public int price;
	public int upkeep;
	public int electricity;
	public Need output;
	public int outputAmount;

	public List<Need> needs;
    public List<int> needsAmount;

    public List<int> bonus = new List<int>{ 50, 30, 10 };
}
