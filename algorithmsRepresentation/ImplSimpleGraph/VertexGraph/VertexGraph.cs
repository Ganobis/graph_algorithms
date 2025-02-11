using algorithmsRepresentation.ImplSimpleGraph;
using algorithmsRepresentation.interfaces;

namespace algorithmsRepresentation.ImplSimpleGraph.VertexGraph;

public class VertexGraph : ISimpleGraph
{
	private readonly Dictionary<int, Vertex> _vertices = new();

	VertexGraph(Dictionary<int, Vertex> vertices)
	{
		_vertices = new Dictionary<int, Vertex>(vertices);
	}

	public VertexGraph()
	{
	}

	public void AddVertex(int id)
	{
		if (!_vertices.ContainsKey(id))
		{
			_vertices[id] = new Vertex(id);
		}
	}

	public void AddEdge(int sourceId, int destinationId, int weight)
	{
		if (_vertices.ContainsKey(sourceId) && _vertices.ContainsKey(destinationId))
		{
			Vertex source = _vertices[sourceId];
			Vertex destination = _vertices[destinationId];
			source.AddNeighbor(destination, weight);
			destination.AddNeighbor(source, weight);
		}
		else
		{
			throw new Exception(GraphResource.AddEdge_MissingVertex);
		}
	}

	public List<int> GetVertices()
	{
		return new List<int>(_vertices.Keys);
	}

	public Vertex GetVertex(int id)
	{
		if (_vertices.ContainsKey(id))
		{
			return _vertices[id];
		}
		throw new Exception(GraphResource.GetVertex_VertexDontExist);
	}

	public List<int> GetNeighbors(int vertex)
	{
		_vertices.TryGetValue(vertex, out var vertexNeighbors);
		if (vertexNeighbors != null)
		{
			List<int> neighbors = new();
			foreach (Vertex neighbor in vertexNeighbors)
			{
				neighbors.Add(neighbor.Id);
			}
			return neighbors;
		}
		return new List<int>();
	}

	public List<Tuple<int, int, int>> GetAllEdges()
	{
		List<Tuple<int, int, int>> allEdges = new List<Tuple<int, int, int>>();

		foreach (var vertex in _vertices.Values)
		{
			foreach (var neighbor in vertex.Neighbors)
			{
				allEdges.Add(new Tuple<int, int, int>(vertex.Id, neighbor.Key.Id, neighbor.Value));
			}
		}

		return allEdges;
	}

	public string PrintGraph()
	{
		string result = null!;
		foreach (var vertex in _vertices.Values)
		{
			result += string.Format(GraphResource.PrintGraph_VertexGraph_Vertex, vertex.Id);
			foreach (var neighbor in vertex.Neighbors)
			{
				result += string.Format(GraphResource.PrintGraph_VertexGraph_VertexWeight, 
					neighbor.Key.Id, neighbor.Value);
			}
			result += Environment.NewLine;
		}
		return result;
	}

	public int GetWeight(int source, int destination)
	{
		foreach (var vertex in _vertices[source].Neighbors)
		{
			if (vertex.Key.Id == destination)
			{
				return vertex.Value;
			}
		}
		throw new Exception(GraphResource.GetVertex_VertexDontExist);
	}
}