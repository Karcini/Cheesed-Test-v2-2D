using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//changes position from center of object to a corner
    //moving 1 right->x += 1.5  y -= 0.85
    //moving 1 down->x -= 1.5  y -= 0.85
    //points between nodes roughly 1.70~1.72
public class AllignTile
{
    public enum Corner {TopLeft, TopRight, BotLeft, BotRight}

    public void Tile2x2(int corner)
    {
        int nodesX = 2; 
        int nodesY = 2;
        AllignToCorner(nodesX, nodesY, corner);
    }

    public void Tile2x4(int corner)
    {
        int nodesX = 2;
        int nodesY = 4;
        AllignToCorner(nodesX, nodesY, corner);
    }

    public void Tile4x3(int corner)
    {
        int nodesX = 4;
        int nodesY = 3;
        AllignToCorner(nodesX, nodesY, corner);
    }

    public float[] AllignToCorner(int nodeX, int nodeY, int corner)
    {
        float x = ((float)nodeX - 1f) * 1.7f / 2f;
        float y = ((float)nodeY - 1f) * 1.7f / 2f;
        switch (corner)
        {
            case (int)Corner.TopLeft:
                //x and y stays positive
                break;

            case (int)Corner.TopRight:
                //x negative, y positive
                x *= -1;
                break;

            case (int)Corner.BotLeft:
                //x positive, y negative
                y *= -1;
                break;

            case (int)Corner.BotRight:
                //x negative, y negative
                x *= -1;
                y *= -1;
                break;
        }
        float[] xyArray = new float[] { x, y };
        return xyArray;
    }
}
