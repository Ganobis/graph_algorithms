using algorithmsRepresentation.ImplSimpleGraph.EdgeList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.Boruvka;

public class BoruvkaEdgeList : BoruvkaAbstract<EdgeList>
{
	private Dictionary<int, int> parent;

	public BoruvkaEdgeList(EdgeList graph) : base(graph)
	{
		MinimumSpanningGraph = new EdgeList();
	}

	public override void FindTree()
	{
		parent = new Dictionary<int, int>();

		foreach (int vertex in Graph.GetVertices())
		{
			parent[vertex] = vertex;
		}

		while (true)
		{
			Dictionary<int, Edge> cheapestEdge = new Dictionary<int, Edge>();

			foreach (var edge in Graph.GetAllEdges())
			{
				int set1 = Find(edge.Item1);
				int set2 = Find(edge.Item2);

				if (set1 != set2)
				{
					if (!cheapestEdge.ContainsKey(set1) || edge.Item3 < cheapestEdge[set1].Weight)
					{
						cheapestEdge[set1] = new Edge(edge.Item1, edge.Item2, edge.Item3);
					}

					if (!cheapestEdge.ContainsKey(set2) || edge.Item3 < cheapestEdge[set2].Weight)
					{
						cheapestEdge[set2] = new Edge(edge.Item1, edge.Item2, edge.Item3);
					}
				}
			}

			bool flag = false;

			foreach (var pair in cheapestEdge)
			{
				int set1 = Find(pair.Value.Vertex1);
				int set2 = Find(pair.Value.Vertex2);

				if (set1 != set2)
				{
					MinimumSpanningGraph.AddEdge(pair.Value.Vertex1, pair.Value.Vertex2, pair.Value.Weight);
					Union(set1, set2);
					flag = true;
				}
			}

			if (!flag)
			{
				break;
			}
		}
	}

	public void ClearTree()
	{
		MinimumSpanningGraph = new EdgeList();
	}

	private int Find(int vertex)
	{
		if (parent[vertex] != vertex)
		{
			parent[vertex] = Find(parent[vertex]);
		}
		return parent[vertex];
	}

	private void Union(int set1, int set2)
	{
		int root1 = Find(set1);
		int root2 = Find(set2);

		if (root1 != root2)
		{
			parent[root2] = root1;
		}
	}
}