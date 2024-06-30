using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_bathroom : Room
{
    //This might need another bathroom script, currently this is Bathroom 1
        //remember master bed script is currently linked to this one
    public override void RoomStats()
    {
        toiletTeleport = true;

        LoadMouseHoles();
    }

    private void LoadMouseHoles()
    {
        mouseHole = new Node();
        MapOne.mouseHoles.Add(mouseHole, TileName.Bathroom);
    }
    private void NeighborMouseHoles()
    {
        neighboringMouseHoles.Add(TileName.KidsRoom);
        neighboringMouseHoles.Add(TileName.Workshop);
    }
}
