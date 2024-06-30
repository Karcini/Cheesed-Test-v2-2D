using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOne 
{
    //public static List<Node> mouseHoles;
    public static Dictionary<Node, int> mouseHoles = new Dictionary<Node, int>();

    public Node GetMouseHole(int tileName)
    {
        Node getHole = new Node();
        foreach (KeyValuePair<Node, int> hole in mouseHoles)
        {
            if(hole.Value == tileName)
            {
                getHole = hole.Key;
            }
        }
        return getHole;
    }
}
