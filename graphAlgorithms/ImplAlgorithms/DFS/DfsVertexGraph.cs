using algorithmsRepresentation.ImplSimpleGraph.VertexGraph;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.DFS;

public sealed class DfsVertexGraph: DfsAbstract<VertexGraph>
{

	public DfsVertexGraph(VertexGraph graph) : base(graph)
	{
	}

	public override void FindPath(int source, int destination)
	{
		HashSet<Vertex> visited = new HashSet<Vertex>();
		List<int> currentPath = new List<int>();

		dfsUtil(Graph.GetVertex(source), Graph.GetVertex(destination), visited, currentPath);
	}

	private void dfsUtil(Vertex current, Vertex destination, HashSet<Vertex> visited, List<int> currentPath)
	{
		visited.Add(current);
		currentPath.Add(current.Id);

		if (current == destination)
		{
			Path = new List<int>(currentPath);
			return;
		}

		foreach (var neighborPair in current.Neighbors)
		{
			var neighbor = neighborPair.Key;
			if (!visited.Contains(neighbor))
			{
				dfsUtil(neighbor, destination, visited, currentPath);
			}
		}

		currentPath.Remove(current.Id);
	}
}