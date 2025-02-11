using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.DFS;

public sealed class DfsAdjacencyMatrix: DfsAbstract<AdjacencyMatrix>
{
	public DfsAdjacencyMatrix(AdjacencyMatrix graph) : base(graph)
	{
	}

	public override void FindPath(int source, int destination)
	{
		bool[] visited = new bool[Graph.NumVertices];
		List<int> currentPath = new();

		dfsUtil(source, destination, visited, currentPath);
	}

	private void dfsUtil(int current, int destination, bool[] visited, ICollection<int> currentPath)
	{
		visited[current] = true;
		currentPath.Add(current);

		if (current == destination)
		{
			Path = new List<int>(currentPath);
			return;
		}

		foreach (int neighbor in Graph.GetNeighbors(current))
		{
			if (!visited[neighbor])
			{
				dfsUtil(neighbor, destination, visited, currentPath);
			}
		}

		currentPath.Remove(current);
	}
}