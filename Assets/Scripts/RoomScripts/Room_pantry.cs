using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_pantry : Room
{
    public override void RoomStats()
    {
        canGatherCheesePile = true;

        cheesePile = 5;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.Pantry);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.Kitchen);
    }
}
