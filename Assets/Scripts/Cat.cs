using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
	public TileMap mapObjTileMap;
	public float coordX;
	public float coordY;
	public int gridX;
	public int gridY;
	public TileMap map;
	public List<Node> currentPath = null;
	public int movement = 2;
	float centerCat = 0.85f;

	CoordConversion convert = new CoordConversion();
	[SerializeField]
	PlayerTurn _playerNumber;
	public PlayerTurn PlayerNumber { get { return _playerNumber; } set { _playerNumber = value; } }
	
	void Start()
	{
		//Initializes Position and Grid of Cat into script
		InitializeCat();
		mapObjTileMap = (TileMap)FindObjectOfType(typeof(TileMap));
	}
		//Currently on select cat, sends this cat gameObject to TileMap
    void OnMouseDown()
    {
		SwapToCat();
		SetCat();
    }
	void SwapToCat()
    {
		if (mapObjTileMap.cat == null)
        {
			mapObjTileMap.mouse = null;
		}
    }
	void SetCat()
    {
		Debug.Log("Cat Clicked!");
		mapObjTileMap.cat = this.gameObject;
	}
	public void InitializeCat()
	{
		coordX = this.gameObject.transform.position.x;
		coordY = this.gameObject.transform.position.y -centerCat;
		
		int[] gridValues = convert.WorldCoordToGridCoord(coordX, coordY);
		gridX = gridValues[0];
		gridY = gridValues[1];
	}
	public void MoveCat()
	{
		int remainingMovement = movement;
		while(remainingMovement > 0)
		{
			if(currentPath == null)
				return;
			
			//Set Cat?
			//InitializeCat();
			
			//remove current/first node from the path
			currentPath.RemoveAt(0);
			
			//grab the new first node and move to that position
			//May want to LERP the transform
			float[] worldValues = CoordConversion.GridCoordToWorldCoord(currentPath[0].x, currentPath[0].y);
			transform.position = map.TileCoordToWorldCoord( worldValues[0], worldValues[1] +centerCat);
			
			if(currentPath.Count == 1)
			{
				//we only have 1 tile left in path, it is our destination
				//clear path finding info
				currentPath = null;
			}
			//Don't really need CostToMove from currentPath[0].x .y  since all movement = 1
			remainingMovement --;
		}
	}
	
	void Update()
	{
		if(currentPath != null)
		{
			int currentNode = 0;
			while(currentNode < currentPath.Count-1)
			{
				//Draws a line in grid coordinates
					//Index out of Range when x != 0
						
				Vector3 start = map.TileCoordToWorldCoord(currentPath[currentNode].x, currentPath[currentNode].y);
				Vector3 end = map.TileCoordToWorldCoord(currentPath[currentNode+1].x, currentPath[currentNode+1].y);;
				
				Debug.DrawLine(start, end);
				currentNode++;
			}
		}
	}
}
