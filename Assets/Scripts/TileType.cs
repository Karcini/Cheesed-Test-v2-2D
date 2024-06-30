using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileType
{
    //This script only holds data
	public string name;
	public GameObject tilePrefab;
	
	public float movementCost = 1;
	public bool isAccessible = true;
	
		//add other tile functionality later
	public bool isARoom = false;
}
