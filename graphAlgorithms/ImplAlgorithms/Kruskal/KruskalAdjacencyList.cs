using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.Kruskal;

public class KruskalAdjacencyList : KruskalAbstract<AdjacencyList>
{
	private readonly Dictionary<int, int> _parent;

	public KruskalAdjacencyList(AdjacencyList graph) : base(graph)
	{
		_parent = new Dictionary<int, int>();
	}

	public override void FindTree()
	{
		MinimumSpanningGraph = new AdjacencyList();

		var edges = Graph.GetAllEdges().OrderBy(e => e.Item3).ToList();

		foreach (var vertex in Graph.GetVertices())
		{
			_parent[vertex] = vertex; 
			MinimumSpanningGraph.AddVertex(vertex);
		}

		int edgesAdded = 0;
		int index = 0;

		while (edgesAdded < Graph.GetVertices().Count - 1 && index < edges.Count)
		{
			var edge = edges[index];
			int rootA = FindRoot(edge.Item1);
			int rootB = FindRoot(edge.Item2);

			if (rootA != rootB)
			{
				MinimumSpanningGraph.AddEdge(edge.Item1, edge.Item2, edge.Item3);
				Union(rootA, rootB);
				edgesAdded++;
			}

			index++;
		}
	}

	public void ClearTree()
	{
		_parent.Clear();
	}

	private int FindRoot(int vertex)
	{
		if (_parent[vertex] == vertex)
			return vertex;

		return _parent[vertex] = FindRoot(_parent[vertex]);
	}

	private void Union(int a, int b)
	{
		int rootA = FindRoot(a);
		int rootB = FindRoot(b);

		_parent[rootA] = rootB;
	}
}