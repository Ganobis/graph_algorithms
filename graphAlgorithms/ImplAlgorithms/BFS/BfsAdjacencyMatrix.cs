using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using graphAlgorithms.AbstractClasses;
using graphAlgorithms.Interfaces;

namespace graphAlgorithms.ImplAlgorithms.BFS;

public sealed class BfsAdjacencyMatrix : BsfAbstract<AdjacencyMatrix>
{
	public BfsAdjacencyMatrix(AdjacencyMatrix adjacencyMatrix): base(adjacencyMatrix)
	{
	}

	public override void FindPath(int source, int destination)
	{
		Path = new List<int>();

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
				ReconstructPath(previousVertex, destination);
				return;
			}

			List<int> neighbors = Graph.GetNeighbors(currentVertex);
			foreach (var neighbor in neighbors.Where(neighbor => !visited.Contains(neighbor)))
			{
				visited.Add(neighbor);
				queue.Enqueue(neighbor);
				previousVertex[neighbor] = currentVertex;
			}
		}
	}

	private void ReconstructPath(Dictionary<int, int> previousVertex, int destination)
	{
		int current = destination;
		while (current != -1)
		{
			Path.Insert(0, current);
			current = previousVertex[current];
		}
	}
}