using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.DFS;

public sealed class DfsAdjacencyList: DfsAbstract<AdjacencyList>
{
	public DfsAdjacencyList(AdjacencyList graph) : base(graph)
	{
	}

	public override void FindPath(int source, int destination)
	{
		Stack<int> stack = new();
		Dictionary<int, int> previousVertex = new();
		List<int> visited = new();

		stack.Push(source);
		visited.Add(source);
		previousVertex[source] = -1;

		while (stack.Count > 0)
		{
			int currentVertex = stack.Pop();

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
					stack.Push(neighbor);
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