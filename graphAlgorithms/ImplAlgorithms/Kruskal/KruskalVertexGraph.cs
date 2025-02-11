using algorithmsRepresentation.ImplSimpleGraph.VertexGraph;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.Kruskal;

public class KruskalVertexGraph : KruskalAbstract<VertexGraph>
{
	private readonly Dictionary<int, HashSet<int>> _disjointSets;
	private int _edgesCount;

	public KruskalVertexGraph(VertexGraph graph) : base(graph)
	{
		_disjointSets = new Dictionary<int, HashSet<int>>();

		foreach (var vertexId in graph.GetVertices())
		{
			_disjointSets[vertexId] = new HashSet<int> { vertexId };
		}

		_edgesCount = 0;
	}

	public override void FindTree()
	{
		MinimumSpanningGraph = new VertexGraph();

		var sortedEdges = new SortedSet<Tuple<int, int, int>>(
			Graph.GetAllEdges(),
			Comparer<Tuple<int, int, int>>.Create((x, y) =>
			{
				int weightComparison = x.Item3.CompareTo(y.Item3);
				if (weightComparison != 0) return weightComparison;

				int firstComparison = x.Item1.CompareTo(y.Item1);
				if (firstComparison != 0) return firstComparison;

				return x.Item2.CompareTo(y.Item2);
			})
		);

		while (_edgesCount < Graph.GetVertices().Count - 1)
		{
			var edge = sortedEdges.Min;
			sortedEdges.Remove(edge);
			sortedEdges.Remove(new Tuple<int, int, int>(edge.Item2, edge.Item1, edge.Item3));

			int source = edge.Item1;
			int destination = edge.Item2;
			int weight = edge.Item3;

			if (Find(source) != Find(destination))
			{
				MinimumSpanningGraph.AddVertex(source);
				MinimumSpanningGraph.AddVertex(destination);
				MinimumSpanningGraph.AddEdge(source, destination, weight);
				Union(source, destination);
				_edgesCount++;
			}
		}
	}

	public override int GetEdgeWeight()
	{
		return MinimumSpanningGraph.GetAllEdges().Sum(edge => edge.Item3) / 2;
	}

	public void ClearTree(VertexGraph graph)
	{
		_disjointSets.Clear();

		foreach (var vertexId in graph.GetVertices())
		{
			_disjointSets[vertexId] = new HashSet<int> { vertexId };
		}

		_edgesCount = 0;
	}

	private int Find(int vertex)
	{
		foreach (var set in _disjointSets)
		{
			if (set.Value.Contains(vertex))
			{
				return set.Key;
			}
		}
		return -1;
	}

	private void Union(int source, int destination)
	{
		int sourceRoot = Find(source);
		int destRoot = Find(destination);

		if (sourceRoot != destRoot)
		{
			_disjointSets[sourceRoot].UnionWith(_disjointSets[destRoot]);
			_disjointSets.Remove(destRoot);
		}
	}
}