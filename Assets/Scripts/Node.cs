using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dijkstra wants a Graph and Source (original tile in our case)
	//We can additionally stop algorithm if "u" (target) was reached and we can reconstruct a path from that point
//Imagine our Grid to be a Graph of "Nodes" and connections from node to node

public class Node
{
	public List<Node> neighbors;
	public int x;
	public int y;
	
	public Node()
	{
		//Initialize list
		neighbors = new List<Node>();
	}
	
	//returns distance between point x,y and node x,y
	public float DistanceTo(Node n)
	{
		return Vector2.Distance( new Vector2(x,y), new Vector2(n.x, n.y) );
	}
}
