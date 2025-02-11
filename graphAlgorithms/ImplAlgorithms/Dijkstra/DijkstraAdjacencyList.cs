using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.Dijkstra;

public sealed class DijkstraAdjacencyList : DijkstraAbstract<AdjacencyList>
{
	public DijkstraAdjacencyList(AdjacencyList graph): base(graph)
	{
	}

	public override void FindPath(int source, int destination)
	{
		var vertices = Graph.GetVertices();
		if (!vertices.Contains(source) || !vertices.Contains(destination))
		{
			throw new Exception(Text.Dijkstra_FindPath_VertexDoNotExist);
		}

		var unvisited = new HashSet<int>(vertices);
		Distances.Clear();
		Previous.Clear();

		foreach (var vertex in vertices)
		{
			Distances[vertex] = int.MaxValue;
			Previous[vertex] = -1;
		}

		Distances[source] = 0;

		while (unvisited.Count != 0)
		{
			int current = unvisited.MinBy(v => Distances[v]);
			unvisited.Remove(current);

			var neighbors = Graph.GetNeighbors(current);
			foreach (var neighbor in neighbors)
			{
				int alt = Distances[current] + Graph.GetWeight(current, neighbor);
				if (alt < Distances[neighbor])
				{
					Distances[neighbor] = alt;
					Previous[neighbor] = current;
				}
			}
		}

		int pointer = Previous.FirstOrDefault(x => x.Key == destination).Value;
		Path.Insert(0, destination);
		while (pointer != -1)
		{
			Path.Insert(0, pointer);
			pointer = Previous[pointer];
		}
	}
}