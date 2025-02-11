using algorithmsRepresentation.ImplSimpleGraph;
using algorithmsRepresentation.interfaces;

namespace algorithmsRepresentation.ImplSimpleGraph.EdgeList;

public class EdgeList : ISimpleGraph
{
	private readonly List<Edge> _edgeList = new();

	public void AddEdge(int vertex1, int vertex2, int weight)
	{
		_edgeList.Add(new Edge(vertex1, vertex2, weight));
	}

	public List<int> GetNeighbors(int vertexNumber)
	{
		List<int> neighbors = new();

		foreach (var edge in _edgeList)
		{
			if (edge.Vertex1 == vertexNumber)
			{
				neighbors.Add(edge.Vertex2);
			}
			else if (edge.Vertex2 == vertexNumber)
			{
				neighbors.Add(edge.Vertex1);
			}
		}

		return neighbors;
	}

	public List<int> GetVertices()
	{
		List<int> vertexList = new();
		foreach (var edge in _edgeList)
		{
			if (!vertexList.Contains(edge.Vertex1))
			{
				vertexList.Add(edge.Vertex1);
			}
			if (!vertexList.Contains(edge.Vertex2))
			{
				vertexList.Add(edge.Vertex2);
			}
		}
		return vertexList;
	}

	public List<Tuple<int, int, int>> GetAllEdges()
	{
		List<Tuple<int, int, int>> allEdges = new();

		foreach (var edge in _edgeList)
		{
			allEdges.Add(new Tuple<int, int, int>(edge.Vertex1, edge.Vertex2, edge.Weight));
		}

		return allEdges;
	}

	public string PrintGraph()
	{
		string result = null!;
		foreach (var edge in _edgeList)
		{
			result += string.Format(GraphResource.PrintGraph_Text, edge.Vertex1, edge.Vertex2, edge.Weight) + Environment.NewLine;
		}
		return result;
	}

	public int GetWeight(int source, int destination)
	{
		if (source > destination)
		{
			(source, destination) = (destination, source);
		}
		foreach (var edge in _edgeList)
		{
			if(edge.Vertex1 == source && edge.Vertex2 == destination)
				return edge.Weight;
		}
		throw new Exception(GraphResource.GetVertex_VertexDontExist);
	}
}