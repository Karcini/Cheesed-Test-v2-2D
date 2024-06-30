using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_kitchen : Room
{
    public override void RoomStats()
    {
        canFindCheese = true; 

        cheese = 3;
        cheeseHourSearch = 5;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.Kitchen);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.Pantry);
        neighboringMouseHoles.Add(TileName.LivingRoom);
    }
}
