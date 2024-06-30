using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordConversion
{
	/*
	This Script translates our data holding grid coordinates to the isometric perspective world coordinates
	
	Grid Movement
		top left (0,0)
			moving 1 right -> x += 1.5  y -= 0.85
			moving 1 down ->  x -= 1.5  y -= 0.85
			
			moving 1 left -> x -= 1.5  y += 0.85
			moving 1 up ->  x += 1.5  y += 0.85
	*/
	
	//Returns Array of Ints where [0]=x   [1]=y
    public int[] WorldCoordToGridCoord(float x2, float y2)
	{
		//moving 1 right -> x += 1.5  y -= 0.85
		//moving 1 down ->  x -= 1.5  y -= 0.85
			//x2 = (1.5*x1) + (-1.5*y1)
			//y2 = (-0.85*x1) - (0.85*y1)
		float tempYv1 = (y2/0.85f) + (x2/1.5f);
		float y1 = tempYv1 * (-0.5f);
		float x1 = (x2/1.5f) + y1;
		//Debug.Log("("+x2+", "+y2+") -> WorldCoord to GridCoord = ("+(int)x1+ ", "+(int)y1+")");
		
		int[] gridCoords = {(int)x1, (int)y1};
		return gridCoords;
	}
	//Returns Array of Floats where [0]=x   [1]=y
	public static float[] GridCoordToWorldCoord(int x1, int y1)
	{
		//This might create some issues depending on accuracy
		float x2 = (1.5f*x1) + (-1.5f*y1);
		float y2 = (-0.85f*x1) - (0.85f*y1);
		float[] worldCoords = {x2,y2};
		return worldCoords;
	}
	//Overloaded function for GridToWorld to include cat centering
		//Note that if Cat is centered, the next WorldToGrid function will FAIL
		//Cannot use this function with current functionality yet, just deal with the fact the cat isn't centered on tiles yet.
	public static float[] GridCoordToWorldCoord(int x1, int y1, float centerCat)
	{
		//centerCat should be explicitly defined as 0.85
		float x2 = (1.5f*x1) + (-1.5f*y1);
		float y2 = (-0.85f*x1) - (0.85f*y1);
		float[] catWorldCoords = {x2,y2+centerCat};
		return catWorldCoords;
	}
}
