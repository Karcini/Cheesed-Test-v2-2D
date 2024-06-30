using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_dinning : Room
{
    public override void RoomStats()
    {
        canFindCheese = true;

        cheese = 2;
        cheeseHourSearch = 4;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.DinningRoom);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.LivingRoom);
        neighboringMouseHoles.Add(TileName.KidsRoom);
    }
}
