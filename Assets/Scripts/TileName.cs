using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileName
{
    //Replacement for Enum TileName since various classes are needing the room typesand enums can't be static
    public enum tileName
    {
        BasicTile, Workshop, Garage, Office,
        MasterBedroom, BabyRoom, KidsRoom, Bathroom,
        Pantry, Kitchen, DinningRoom, LivingRoom, EmptyTile
    }

    public static int BasicTile = 0;
    public static int Workshop = 1;
    public static int Garage = 2;
    public static int Office = 3;
    public static int MasterBedroom = 4;
    public static int BabyRoom = 5;
    public static int KidsRoom = 6;
    public static int Bathroom = 7;
    public static int Pantry = 8;
    public static int Kitchen = 9;
    public static int DinningRoom = 10;
    public static int LivingRoom = 11;
    public static int EmptyTile = 12;
}
