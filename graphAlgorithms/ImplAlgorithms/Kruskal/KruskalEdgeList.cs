using algorithmsRepresentation.ImplSimpleGraph.EdgeList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.Kruskal;

public class KruskalEdgeList : KruskalAbstract<EdgeList>
{
	private readonly Dictionary<int, int> _parent;

	public KruskalEdgeList(EdgeList graph) : base(graph)
	{
		_parent = new Dictionary<int, int>();
	}

	public override void FindTree()
	{
		MinimumSpanningGraph = new EdgeList();

		var edges = Graph.GetAllEdges().OrderBy(e => e.Item3).ToList();
		var vertices = Graph.GetVertices();

		foreach (var vertex in vertices)
		{
			_parent[vertex] = vertex;
		}

		int edgesAdded = 0;
		int index = 0;

		while (edgesAdded < vertices.Count - 1 && index < edges.Count)
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
