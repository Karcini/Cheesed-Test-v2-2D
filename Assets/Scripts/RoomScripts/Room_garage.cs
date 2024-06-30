using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_garage : Room
{
    public override void RoomStats()
    {
        canFindCards = true;
        canGatherCardPile = true;

        cards = 1;
        cardHourSearch = 4;
        cardPile = 1;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.Garage);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.MasterBedroom);
    }
}
