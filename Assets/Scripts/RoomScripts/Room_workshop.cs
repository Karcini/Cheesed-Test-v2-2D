using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_workshop : Room
{
    public override void RoomStats()
    {
        canFindCards = true;

        cards = 1;
        cardHourSearch = 5;

        LoadMouseHoles();
        // Load NeighborMouseHoles() on a method called else where afterwards
        // Load LoadConnectingMouseHoles() on a method afterwards
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.Workshop);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.LivingRoom);
        neighboringMouseHoles.Add(TileName.Bathroom);
    }
}
