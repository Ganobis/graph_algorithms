using algorithmsRepresentation.ImplSimpleGraph.VertexGraph;
using graphAlgorithms.AbstractClasses;
using graphAlgorithms.Interfaces;

namespace graphAlgorithms.ImplAlgorithms.BFS;

public sealed class BfsVertexGraph : BsfAbstract<VertexGraph>
{
	public BfsVertexGraph(VertexGraph graph) : base(graph)
	{
	}
	public override void FindPath(int source, int destination)
	{
		Queue<int> queue = new();
		Dictionary<int, int> previousVertex = new();
		List<int> visited = new();

		queue.Enqueue(source);
		visited.Add(source);
		previousVertex[source] = -1;

		while (queue.Count > 0)
		{
			int currentVertex = queue.Dequeue();

			if (currentVertex == destination)
			{
				Path = ReconstructPath(previousVertex, destination);
				return;
			}

			List<int> neighbors = Graph.GetNeighbors(currentVertex);
			foreach (var neighbor in neighbors)
			{
				if (!visited.Contains(neighbor))
				{
					visited.Add(neighbor);
					queue.Enqueue(neighbor);
					previousVertex[neighbor] = currentVertex;
				}
			}
		}
	}

	private List<int> ReconstructPath(IReadOnlyDictionary<int, int> previousVertex, int destination)
	{
		List<int> path = new();
		int current = destination;

		while (current != -1)
		{
			path.Insert(0, current);
			current = previousVertex[current];
		}

		return path;
	}
}