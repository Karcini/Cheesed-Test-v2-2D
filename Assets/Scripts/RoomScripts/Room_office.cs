using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_office : Room
{
    public override void RoomStats()
    {
        canFindCards = true;

        cards = 1;
        cardHourSearch = 6;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.Office);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.MasterBedroom);
        neighboringMouseHoles.Add(TileName.BabyRoom);
    }
}
