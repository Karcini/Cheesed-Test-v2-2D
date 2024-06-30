using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Tile
{
    public Node mouseHole;
    public List<int> neighboringMouseHoles;
    MapOne mapOne;

    public bool canFindCheese = false;
    public bool canFindCards = false;
    public bool canGatherCheesePile = false;
    public bool canGatherCardPile = false;
    public bool toiletTeleport = false;

    public int cheese = 0;
    public int cheeseHourSearch = 0;
    public int cards = 0;
    public int cardHourSearch = 0;
    public int cheesePile = 0;
    public int cardPile = 0;
    public int PileRegenTime = 24;  //hours
    public int searchMultiplier = 1;  //mice searching


	//This is a test method for polymorphism
    public override void Initializer()
    {
        coordX = this.gameObject.transform.position.x;
        coordY = this.gameObject.transform.position.y;
        gridX = 0;
        gridY = 0;
        TileMap.roomsMap1.Add(this);
    }

    public override void TilePathing()
	{
        Debug.Log("Override Tile, Grid(" + gridX + ", " + gridY + ") WorldCoords(" + coordX + ", " + coordY + ")");
        map.GeneratePathTo(gridX, gridY);
    }	

    public void GetClosestGrid()
    {
        //using CenterPoint, get closest empty tile, if there is a tie pick first one, get values for gridX/Y
        Tile[] allTiles = FindObjectsOfType<Tile>();
        Tile targetTile = new Tile();
        float dist = 0;
        for(int x=0; x < allTiles.Length; x++)
        {
            if(allTiles[x] != this)
            {
                Vector3 newTile = allTiles[x].transform.position;
                float newDist = Vector3.Distance(newTile, transform.position);
                if (dist == 0)
                {
                    targetTile = allTiles[x];
                    dist = newDist;
                }
                else
                {
                    if (newDist < dist)
                    {
                        targetTile = allTiles[x];
                        dist = newDist;
                    }
                }
            }
        }
        gridX = targetTile.gridX;
        gridY = targetTile.gridY;
    }

    public virtual void RoomStats()
    {

    }
    private void LoadConnectingMouseHoles()
    {
        Node tempHole;
        for (int x = 0; x < neighboringMouseHoles.Count; x++)
        {
            tempHole = mapOne.GetMouseHole(neighboringMouseHoles[x]);
            mouseHole.neighbors.Add(tempHole);
        }
    }
}
