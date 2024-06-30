using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note this is currently a throwaway script for testing
	//delete later if found entirely irrelevant
	
public class GridManager : MonoBehaviour
{
	//Example to show how to Automate a Grid
	//private int rows = 5;
	//private int columns = 8;
	//private float tileSize = 1;
	
    void Start()
    {
        //GenerateGrid();
    }
	
	/*
	void GenerateGrid()
	{
		//This wont run because this assumes this Script is right outside Resources Folder
		GambeObject referenceTile = (GameObject)Instantiate(Resources.Load("Tile_Cyan"));
		for(int row=0; row< rows; row++)
		{
			for(int column=0; column < columns; column++)
			{
				GambeObject tile = (GambeObject)Instantiate(referenceTile, transform);
				float posX = column * tileSize;
				float posY = row * (-tileSize);
				tile.transform.position = new Vector2(posX,posY);
			}
		}
		
		Destroy(referenceTile);
	}
	*/
}
