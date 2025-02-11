using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.Boruvka;

public sealed class BoruvkaAdjacencyList : BoruvkaAbstract<AdjacencyList>
{
	public BoruvkaAdjacencyList(AdjacencyList graph) : base(graph)
	{
		MinimumSpanningGraph = new AdjacencyList();
	}

	public override void FindTree()
	{
		List<int> vertices = Graph.GetVertices();

		Dictionary<int, int> components = new Dictionary<int, int>();
		foreach (int vertex in vertices)
		{
			MinimumSpanningGraph.AddVertex(vertex);
			components[vertex] = vertex;
		}

		bool merged = true;
		while (merged)
		{
			merged = false;
			Dictionary<int, Tuple<int, int, int>> cheapestEdge = new Dictionary<int, Tuple<int, int, int>>();

			foreach (var edge in Graph.GetAllEdges())
			{
				int source = edge.Item1;
				int destination = edge.Item2;
				int weight = edge.Item3;

				int componentOfSource = FindComponent(components, source);
				int componentOfDest = FindComponent(components, destination);

				if (componentOfSource != componentOfDest)
				{
					if (!cheapestEdge.ContainsKey(componentOfSource) || weight < cheapestEdge[componentOfSource].Item3)
					{
						cheapestEdge[componentOfSource] = edge;
					}
					if (!cheapestEdge.ContainsKey(componentOfDest) || weight < cheapestEdge[componentOfDest].Item3)
					{
						cheapestEdge[componentOfDest] = edge;
					}
				}
			}

			foreach (var kvp in cheapestEdge)
			{
				int source = kvp.Value.Item1;
				int destination = kvp.Value.Item2;
				int weight = kvp.Value.Item3;

				int componentOfSource = FindComponent(components, source);
				int componentOfDest = FindComponent(components, destination);

				if (componentOfSource != componentOfDest)
				{
					MinimumSpanningGraph.AddEdge(source, destination, weight);
					MergeComponents(components, componentOfSource, componentOfDest);
					merged = true;
				}
			}
		}
	}

	public void ClearTree()
	{
		MinimumSpanningGraph = new AdjacencyList();
	}

	private int FindComponent(Dictionary<int, int> components, int vertex)
	{
		while (components[vertex] != vertex)
		{
			vertex = components[vertex];
		}
		return vertex;
	}

	private void MergeComponents(Dictionary<int, int> components, int component1, int component2)
	{
		components[component2] = component1;
	}
}
