using algorithmsRepresentation.ImplSimpleGraph.EdgeList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.BellmanFord;

public sealed class BellmanFordEdgeList : BellmanFordAbstract<EdgeList>
{
	public BellmanFordEdgeList(EdgeList graph) : base(graph)
	{
	}

	public override void FindPath(int source, int destination)
	{
		var graphVertices = Graph.GetVertices();
		var graphEdges = Graph.GetAllEdges();

		foreach (var vertex in graphVertices)
		{
			Distances[vertex] = int.MaxValue;
			Previous[vertex] = -1;
		}

		Distances[source] = 0;

		for (int i = 0; i < graphVertices.Count - 1; i++)
		{
			foreach (var (u, v, weight) in graphEdges)
			{
				if (Distances[u] != int.MaxValue && Distances[u] + weight < Distances[v])
				{
					Distances[v] = Distances[u] + weight;
					Previous[v] = u;
				}

				if (Distances[v] != int.MaxValue && Distances[v] + weight < Distances[u])
				{
					Distances[u] = Distances[v] + weight;
					Previous[u] = v;
				}
			}
		}

		int current = destination;
		while (current != -1)
		{
			Path.Insert(0, current);
			current = Previous[current];
		}

		if (Path[0] != source)
		{
			Path.Clear();
		}
	}
}