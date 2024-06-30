using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public float coordX;
	public float coordY;
	public int gridX;
	public int gridY;
	public TileMap map;
	
    void Start()
    {
		Initializer();
    }
    void OnMouseDown()
    {
        if (map.cat)
        {
			//Cat Pathing
			TilePathing();
		}
        if (map.mouse)
        {
			//Mouse Pathing
			//
        }
    }

	public virtual void Initializer()
    {
		/*
		//Currently Initialized on Grid Construction, this is overriding wrong tiles

		coordX = this.gameObject.transform.position.x;
		coordY = this.gameObject.transform.position.y;

		CoordConversion convert = new CoordConversion();
		int[] gridValues = convert.WorldCoordToGridCoord(coordX, coordY);
		gridX = gridValues[0];
		gridY = gridValues[1];
		*/
	}

	public virtual void TilePathing()
    {
		Debug.Log("Clicked Tile, Grid(" + gridX + ", " + gridY + ") WorldCoords(" + coordX + ", " + coordY +")");
		map.GeneratePathTo(gridX, gridY);
	}
	
}
