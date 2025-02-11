using algorithmsRepresentation.ImplSimpleGraph.VertexGraph;
using graphAlgorithms.AbstractClasses;

public class BoruvkaVertexGraph : BoruvkaAbstract<VertexGraph>
{
	private Dictionary<int, int> _componentRepresentatives;

	public BoruvkaVertexGraph(VertexGraph graph) : base(graph)
	{
		ComponentRepresentatives = new Dictionary<int, int>();
		foreach (var vertexId in Graph.GetVertices())
		{
			ComponentRepresentatives[vertexId] = vertexId;
		}
		MinimumSpanningGraph = new VertexGraph();
	}

	public Dictionary<int, int> ComponentRepresentatives { get => _componentRepresentatives; set => _componentRepresentatives = value; }

	public override void FindTree()
	{
		while (MinimumSpanningGraph.GetAllEdges().Count / 2 < Graph.GetVertices().Count - 1)
		{
			var cheapestEdge = new Dictionary<int, Tuple<int, int, int>>();

			foreach (var edge in Graph.GetAllEdges())
			{
				var sourceId = edge.Item1;
				var destinationId = edge.Item2;
				var weight = edge.Item3;

				var sourceComponent = FindComponentRepresentative(sourceId);
				var destinationComponent = FindComponentRepresentative(destinationId);

				if (sourceComponent != destinationComponent)
				{
					if (!cheapestEdge.ContainsKey(sourceComponent) || weight < cheapestEdge[sourceComponent].Item3)
					{
						cheapestEdge[sourceComponent] = Tuple.Create(sourceId, destinationId, weight);
					}
				}
			}

			foreach (var edge in cheapestEdge.Values)
			{
				var sourceId = edge.Item1;
				var destinationId = edge.Item2;
				var weight = edge.Item3;

				var sourceComponent = FindComponentRepresentative(sourceId);
				var destinationComponent = FindComponentRepresentative(destinationId);

				if (sourceComponent != destinationComponent)
				{
					MinimumSpanningGraph.AddVertex(sourceId);
					MinimumSpanningGraph.AddVertex(destinationId);
					MinimumSpanningGraph.AddEdge(sourceId, destinationId, weight);

					Union(sourceComponent, destinationComponent);
				}
			}
		}
	}

	public override int GetEdgeWeight()
	{
		return base.GetEdgeWeight() / 2;
	}

	public void ClearTree()
	{
		ComponentRepresentatives = new Dictionary<int, int>();
		foreach (var vertexId in Graph.GetVertices())
		{
			ComponentRepresentatives[vertexId] = vertexId;
		}
		MinimumSpanningGraph = new VertexGraph();
	}

	private int FindComponentRepresentative(int vertex)
	{
		while (ComponentRepresentatives[vertex] != vertex)
		{
			vertex = ComponentRepresentatives[vertex];
		}
		return vertex;
	}

	private void Union(int sourceComponent, int destinationComponent)
	{
		ComponentRepresentatives[destinationComponent] = sourceComponent;
	}
}