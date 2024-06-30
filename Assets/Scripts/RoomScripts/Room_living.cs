using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_living : Room
{
    public override void RoomStats()
    {
        canFindCheese = true;
        canFindCards = true;

        cheese = 1;
        cheeseHourSearch = 3;
        cards = 1;
        cardHourSearch = 10;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.LivingRoom);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.Kitchen);
        neighboringMouseHoles.Add(TileName.DinningRoom);
        neighboringMouseHoles.Add(TileName.Workshop);
    }
}
