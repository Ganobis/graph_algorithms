using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using graphAlgorithms.AbstractClasses;
namespace graphAlgorithms.ImplAlgorithms.Kruskal;
public class KruskalAdjacencyMatrix : KruskalAbstract<AdjacencyMatrix>
{

	public KruskalAdjacencyMatrix(AdjacencyMatrix graph) : base(graph)
	{
	}

	public override void FindTree()
	{
		MinimumSpanningGraph = new AdjacencyMatrix(Graph.NumVertices);
		var allEdges = Graph.GetAllEdges();
		var allVertices = Graph.GetVertices();
		allEdges.Sort((x, y) => x.Item3.CompareTo(y.Item3));

		var vertexToComponent = new Dictionary<int, int>();

		foreach (var vertex in allVertices)
		{
			vertexToComponent[vertex] = vertex;
		}

		foreach (var (source, destination, weight) in allEdges)
		{
			int componentSource = vertexToComponent[source];
			int componentDestination = vertexToComponent[destination];

			if (componentSource == componentDestination) continue;
			MinimumSpanningGraph.AddEdge(source, destination, weight);

			foreach (var vertex in allVertices.Where(vertex => vertexToComponent[vertex] == componentDestination))
			{
				vertexToComponent[vertex] = componentSource;
			}
		}
	}
}
