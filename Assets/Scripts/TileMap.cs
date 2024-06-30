using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
	public static List<Room> roomsMap1 = new List<Room>();
	public TileType[] tileTypes;
	public int[,] tiles;
	Node[,] graph;
	List<Node> currentPath = null;
	
	//11x13 tile Map
	int mapSizeX = 11;
	int mapSizeY = 13;
	
	
	public GameObject cat;
	public GameObject mouse;
	
    void Start()
    {
		GenerateMapData();
		GeneratePathFindingGraph();
		GenerateMap();
    }
	
	void GenerateMapData()
	{
		//Allocate map tile Identifiers
			//Starting Top left, Generate Rows to the right, Go down 1 Column, Repeat
        tiles = new int[mapSizeX,mapSizeY];
		
		//Initialize our map tiles
		for(int y=0; y<mapSizeY; y++)
		{	
			for(int x=0; x<mapSizeX; x++)
			{
				tiles[x, y] = (int)TileName.EmptyTile;
			}	
		}
		BasicTileLocations();
	}
	void GenerateMap()
	{
		float xIncrement = 0f;
		float yIncrement = 0f;
		for(int y=0; y<mapSizeY; y++)
		{
			xIncrement = -1.5f * (float)y; 
			yIncrement = -0.85f * (float)y;
			for(int x=0; x<mapSizeX; x++)
			{
				TileType tt = tileTypes[tiles[x,y]];
				GameObject tempObj = (GameObject)Instantiate(tt.tilePrefab, new Vector3(xIncrement, yIncrement, 0), Quaternion.identity);
				
				Tile t = tempObj.GetComponent<Tile>();
				t.coordX = xIncrement;
				t.coordY = yIncrement;
				t.gridX = x;
				t.gridY = y;
				t.map = this;
				
				xIncrement += 1.5f; yIncrement -= 0.85f;
			}
		}
		GenerateRooms();
	}
	void GenerateRooms()
    {
		//generate rooms
		for (int x=0; x < roomsMap1.Count; x++)
        {
			//pass map data to room script
			roomsMap1[x].map = this;
			//give room script gridX/Y
			roomsMap1[x].GetClosestGrid();
		}
		//override tiletype data
		OverrideTileTypes();
		//override node Data for graph at gridX/Y
		OverrideRoomNodes();
	}

	//Implement Dijkstra refer to pseudoCode
	public void GeneratePathTo(int x , int y)
	{
		if(cat)
		{	
			//check if tile is not accessible, break pathing if so
			if( CanEnterTile(x,y) == false )
			{
				return;
			}
			
			//Initializing Cat Here for now
			cat.GetComponent<Cat>().InitializeCat();
			cat.GetComponent<Cat>().map = this;
			
			//clear out our unit's old path
			cat.GetComponent<Cat>().currentPath = null;
			
			Dictionary<Node, float> distanceTraveled = new Dictionary<Node, float>();
			Dictionary<Node, Node> previousNode = new Dictionary<Node, Node>();
			//Queue of nodes we haven't checked
			List<Node> unvisited = new List<Node>();
			
			//thanks to CoordConverter we can use gridX gridY of Cat
			Node source =  graph[cat.GetComponent<Cat>().gridX, cat.GetComponent<Cat>().gridY];
			Node target =  graph[x,y];
			
			distanceTraveled[source] = 0;
			previousNode[source] = null;
			
				//Initialize everything
			foreach(Node v in graph)
			{
				if(v != source)
				{
					distanceTraveled[v] = Mathf.Infinity;
					previousNode[v] = null;
				}
				unvisited. Add(v);
			}
			while(unvisited.Count>0)
			{
				//"u" is the unvisited node with the smallest distance 
				Node u = null;
				foreach(Node possibleU in unvisited)
				{
					if(u == null || distanceTraveled[possibleU] < distanceTraveled[u])
					{
						u = possibleU;
					}
				}
				
				if (u == target)
				{
					break; //out of while loop
				}
				unvisited.Remove(u);
				
				//this calculates distance, implement the cost for tile movement instead of actual distance and give empty tiles a very high cost
				foreach(Node v in u.neighbors)
				{
					//float alt = distanceTraveled[u] + u.DistanceTo(v);
					float alt = distanceTraveled[u] + CostToEnterTile(v.x, v.y);
					if( alt < distanceTraveled[v])
					{
						distanceTraveled[v] = alt;
						previousNode[v] = u;
					}
				}
			}
			
			//return shortest route to target or no possible route to target
			if(previousNode[target] == null)
			{
				//no route possible
				return;
			}
			//Step through previous chain and add it to our path
			List<Node> currentPath = new List<Node>();
			Node curr = target;
			while(curr!=null)
			{
				currentPath.Add(curr);
				curr = previousNode[curr];
			}
			//Path describes a route from target to source, so invert it for pathing route
			currentPath.Reverse();
				//Pass the list route path thing to cat
			cat.GetComponent<Cat>().currentPath = currentPath;
		}
		if(mouse)
        {

        }
	}
	//Turns our shortest path algorithm into a most cost efficient path algorithm
	public float CostToEnterTile(int x, int y)
	{
		TileType tt = tileTypes[ tiles[x,y] ];
		return tt.movementCost;
	}
	//checks the tiletype's accessibility boolean
	public bool CanEnterTile(int x, int y)
	{
		return tileTypes[ tiles[x,y] ].isAccessible;
	}
	
	//Generate Node Path
	void GeneratePathFindingGraph()
	{
		//Initialize array
		graph = new Node[mapSizeX,mapSizeY];
		//Initialize a Node for each spot in the array
		for(int y=0; y<mapSizeY; y++)
		{	
			for(int x=0; x<mapSizeX; x++)
			{
				graph[x,y] = new Node();
				graph[x,y].x = x;
				graph[x,y].y = y;
			}
		}
		//Initialize neighbors for each node
		for(int y=0; y<mapSizeY; y++)
		{	
			for(int x=0; x<mapSizeX; x++)
			{
				//adds a Node.neighbors of a grid space left/right/down/up
				if(x > 0)
					graph[x,y].neighbors.Add( graph[x-1,y] );
				if(x < mapSizeX-1)
					graph[x,y].neighbors.Add( graph[x+1,y] );
				if(y > 0)
					graph[x,y].neighbors.Add( graph[x,y-1] );
				if(y < mapSizeY-1)
					graph[x,y].neighbors.Add( graph[x,y+1] );
			}	
		}
	}
	
	//we might want this to instead be on the unit that moves since units will have different movement and we will have many units
	public Vector3 TileCoordToWorldCoord(float x, float y)
	{
		return new Vector3(x, y, 0);
	}

	public void BasicTileLocations()
	{
		//override EmptyTiles with Intended Basic Tiles
		tiles[4, 0] = (int)TileName.BasicTile;

		tiles[4, 1] = (int)TileName.BasicTile;

		tiles[4, 2] = (int)TileName.BasicTile;

		tiles[4, 3] = (int)TileName.BasicTile;

		tiles[4, 4] = (int)TileName.BasicTile;

		tiles[4, 5] = (int)TileName.BasicTile;

		tiles[4, 6] = (int)TileName.BasicTile;

		tiles[2, 7] = (int)TileName.BasicTile;
		tiles[3, 7] = (int)TileName.BasicTile;
		tiles[4, 7] = (int)TileName.BasicTile;
		tiles[5, 7] = (int)TileName.BasicTile;
		tiles[6, 7] = (int)TileName.BasicTile;
		tiles[7, 7] = (int)TileName.BasicTile;
		tiles[8, 7] = (int)TileName.BasicTile;

		tiles[2, 8] = (int)TileName.BasicTile;

		tiles[2, 9] = (int)TileName.BasicTile;

		tiles[2, 10] = (int)TileName.BasicTile;
		tiles[3, 10] = (int)TileName.BasicTile;
		tiles[4, 10] = (int)TileName.BasicTile;

		tiles[2, 11] = (int)TileName.BasicTile;
		tiles[3, 11] = (int)TileName.BasicTile;
		tiles[4, 11] = (int)TileName.BasicTile;

		tiles[2, 12] = (int)TileName.BasicTile;
		tiles[3, 12] = (int)TileName.BasicTile;
		tiles[4, 12] = (int)TileName.BasicTile;
	}
	public void OverrideTileTypes()
    {
		tiles[10, 11] = (int)TileName.Workshop;
		tiles[1, 1] = (int)TileName.Garage;
		tiles[2, 5] = (int)TileName.Office;
		tiles[1, 7] = (int)TileName.MasterBedroom;
		tiles[5, 5] = (int)TileName.BabyRoom;
		tiles[7, 5] = (int)TileName.KidsRoom;
		tiles[0, 9] = (int)TileName.Bathroom;
		tiles[9, 7] = (int)TileName.Bathroom;
		tiles[3, 8] = (int)TileName.Pantry;
		tiles[5, 8] = (int)TileName.Kitchen;
		tiles[7, 8] = (int)TileName.DinningRoom;
		tiles[7, 11] = (int)TileName.LivingRoom;
	}
	void OverrideRoomNodes()
	{
		//Remove all basic tiles that touch non basic tiles
		for(int y=1; y<mapSizeY-1; y++)
        {
			for(int x=0; x<mapSizeX-1; x++)
            {
				if(tiles[x,y] == (int)TileName.BasicTile)
                {
					if (tiles[x + 1, y] != (int)TileName.BasicTile)
						graph[x, y].neighbors.Remove(graph[x + 1, y]);
					if (tiles[x - 1, y] != (int)TileName.BasicTile)
						graph[x, y].neighbors.Remove(graph[x - 1, y]);
					if (tiles[x, y + 1] != (int)TileName.BasicTile)
						graph[x, y].neighbors.Remove(graph[x, y + 1]);
					if (tiles[x, y - 1] != (int)TileName.BasicTile)
						graph[x, y].neighbors.Remove(graph[x, y - 1]);
				}
            }
        }

		//Workshop Nodes
		graph[10, 11].neighbors.Clear();
		graph[10, 11].neighbors.Add(graph[7, 11]);
		graph[10, 11].neighbors.Add(graph[9, 7]);

		//Garage Nodes
		graph[1, 1].neighbors.Clear();
		graph[1, 1].neighbors.Add(graph[4, 0]);
		graph[4, 0].neighbors.Add(graph[1, 1]);

		//Office Nodes
		graph[2, 5].neighbors.Clear();
		graph[2, 5].neighbors.Add(graph[1, 7]);

		//MasterBedroom Nodes
		graph[1, 7].neighbors.Clear();
		graph[1, 7].neighbors.Add(graph[2, 5]);
		graph[1, 7].neighbors.Add(graph[0, 9]);
		graph[1, 7].neighbors.Add(graph[2, 8]);
		graph[2, 8].neighbors.Add(graph[1, 7]);

		//BabyRoom Nodes
		graph[5, 5].neighbors.Clear();
		graph[5, 5].neighbors.Add(graph[6, 7]);
		graph[6, 7].neighbors.Add(graph[5, 5]);

		//KidsRoom Nodes
		graph[7, 5].neighbors.Clear();
		graph[7, 5].neighbors.Add(graph[8, 7]);
		graph[8, 7].neighbors.Add(graph[7, 5]);

		//Bathroom1 Nodes
		graph[0, 9].neighbors.Clear();
		graph[0, 9].neighbors.Add(graph[1, 7]);
		graph[0, 9].neighbors.Add(graph[2, 10]);
		graph[2, 10].neighbors.Add(graph[0, 9]);

		//Bathroom2 Nodes
		graph[9, 7].neighbors.Clear();
		graph[9, 7].neighbors.Add(graph[10, 11]);
		graph[9, 7].neighbors.Add(graph[8, 7]);
		graph[8, 7].neighbors.Add(graph[9, 7]);

		//Pantry Nodes
		graph[3, 8].neighbors.Clear();
		graph[3, 8].neighbors.Add(graph[5, 8]);

		//Kitchen Nodes
		graph[5, 8].neighbors.Clear();
		graph[5, 8].neighbors.Add(graph[3, 8]);
		graph[5, 8].neighbors.Add(graph[7, 11]);

		//DinningRoom Nodes
		graph[7, 8].neighbors.Clear();
		graph[7, 8].neighbors.Add(graph[7, 11]);

		//LivingRoom Nodes
		graph[7, 11].neighbors.Clear();
		graph[7, 11].neighbors.Add(graph[5, 8]);
		graph[7, 11].neighbors.Add(graph[7, 8]);
		graph[7, 11].neighbors.Add(graph[10, 11]);
		graph[7, 11].neighbors.Add(graph[4, 11]);
		graph[4, 11].neighbors.Add(graph[7, 11]);
	}

	/*
	AllignTile allign = new AllignTile();
	public float[] ShiftRoom(int room)
	{
		float[] xyArray = { 0, 0 };
		switch (room)
		{
			case (int)tileName.Workshop:
				xyArray = allign.AllignToCorner(2, 4, 1);
				break;

			case (int)tileName.Garage:
				xyArray = allign.AllignToCorner(4, 3, 1);
				break;

			case (int)tileName.Office:
				xyArray = allign.AllignToCorner(2, 2, 0);
				break;

			case (int)tileName.MasterBedroom:
				xyArray = allign.AllignToCorner(2, 2, 0);
				break;

			case (int)tileName.BabyRoom:
				xyArray = allign.AllignToCorner(2, 2, 3);
				break;

			case (int)tileName.KidsRoom:
				xyArray = allign.AllignToCorner(2, 2, 3);
				break;

			case (int)tileName.Bathroom:
				xyArray = allign.AllignToCorner(2, 2, 0);
				break;

			case (int)tileName.Pantry:
				xyArray = allign.AllignToCorner(2, 2, 3);
				break;

			case (int)tileName.Kitchen:
				xyArray = allign.AllignToCorner(2, 2, 3);
				break;

			case (int)tileName.DinningRoom:
				xyArray = allign.AllignToCorner(2, 2, 2);
				break;

			case (int)tileName.LivingRoom:
				xyArray = allign.AllignToCorner(2, 2, 2);
				break;
		}
		return xyArray;
	}
	*/
}
