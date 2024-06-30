using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_kidsroom : Room
{
    public override void RoomStats()
    {
        canFindCheese = true;
        canFindCards = true;

        cheese = 2;
        cheeseHourSearch = 6;
        cards = 1;
        cardHourSearch = 8;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.KidsRoom);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.BabyRoom);
        neighboringMouseHoles.Add(TileName.Bathroom);
        neighboringMouseHoles.Add(TileName.DinningRoom);
    }
}
