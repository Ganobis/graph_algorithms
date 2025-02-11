using algorithmsRepresentation.ImplSimpleGraph.EdgeList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.DFS;

public sealed class DfsEdgeList: DfsAbstract<EdgeList>
{
	public DfsEdgeList(EdgeList graph) : base(graph)
	{
	}

	public override void FindPath(int source, int destination)
	{
		Stack<int> stack = new Stack<int>();
		Dictionary<int, int> previousVertex = new Dictionary<int, int>();
		List<int> visited = new List<int>();

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

	private List<int> ReconstructPath(Dictionary<int, int> previousVertex, int destination)
	{
		List<int> path = new List<int>();
		int current = destination;

		while (current != -1)
		{
			path.Insert(0, current);
			current = previousVertex[current];
		}

		return path;
	}
}