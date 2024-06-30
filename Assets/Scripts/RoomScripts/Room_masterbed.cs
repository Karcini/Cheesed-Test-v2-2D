using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_masterbed : Room
{
    public override void RoomStats()
    {
        canFindCheese = true;
        canGatherCheesePile = true;

        cheese = 3;
        cheeseHourSearch = 5;
        cheesePile = 3;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.MasterBedroom);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.Bathroom);
        neighboringMouseHoles.Add(TileName.Office);
        neighboringMouseHoles.Add(TileName.Garage);
    }
}
