﻿namespace algorithmsRepresentation.ImplSimpleGraph.EdgeList;

public class Edge
{
	public int Vertex1 { get; }
	public int Vertex2 { get; }
	public int Weight;

	public Edge(int vertex1, int vertex2, int weight)
	{
		Vertex1 = vertex1;
		Vertex2 = vertex2;
		Weight = weight;
	}
}