using algorithmsRepresentation.ImplSimpleGraph;
using algorithmsRepresentation.interfaces;

namespace algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;

public class AdjacencyList : ISimpleGraph
{
	private readonly List<Tuple<int, int, int>> _adjacencyList = new();
	private readonly List<int> _vertexList = new();

	public AdjacencyList(AdjacencyList original)
	{
		_adjacencyList.AddRange(original._adjacencyList);
		_vertexList.AddRange(original._vertexList);
	}

	public AdjacencyList()
	{
	}

	public void AddVertex(int vertex)
	{
		if (!IsExistVertex(vertex))
		{
			_vertexList.Add(vertex);
		}
		else
		{
			throw new Exception(GraphResource.AddVertex_AdjacencyList_ExistingVertex);
		}
	}

	public void AddEdge(int source, int destination, int weight)
	{
		if (IsExistVertex(source) && IsExistVertex(destination))
		{
			if (source < destination)
			{
				(source, destination) = (destination, source);
			}
			_adjacencyList.Add(new Tuple<int, int, int>(destination, source, weight));
		}
		else
		{
			throw new Exception(GraphResource.AddEdge_MissingVertex);
		}
	}

	public List<int> GetNeighbors(int vertex)
	{
		var neighbors = new List<int>();
		foreach(Tuple<int, int, int> itemFromList in _adjacencyList)
		{
			if(itemFromList.Item1 == vertex)
			{
				neighbors.Add(itemFromList.Item2);
			}
			else if (itemFromList.Item2 == vertex)
			{
				neighbors.Add(itemFromList.Item1);
			}
		}

		return neighbors;
	}

	public List<int> GetVertices()
	{
		return _vertexList;
	}

	public string PrintGraph()
	{
		string result = null!;
		foreach (Tuple<int, int, int> itemFromList in _adjacencyList)
		{
			result += string.Format(GraphResource.PrintGraph_Text, itemFromList.Item1, itemFromList.Item2,
				itemFromList.Item3) + Environment.NewLine;
		}
		return result;
	}

	public List<Tuple<int, int, int>> GetAllEdges()
	{
		return _adjacencyList;
	}

	public int GetWeight(int source, int destination)
	{
		foreach (var edge in _adjacencyList)
		{
			if ((edge.Item1 == source && edge.Item2 == destination) || (edge.Item1 == destination && edge.Item2 == source))
			{
				return edge.Item3;
			}
		}
		throw new Exception(GraphResource.GetVertex_VertexDontExist);
	}

	private bool IsExistVertex(int vertex)
	{
		int x = _vertexList.FindIndex(v => v == vertex);
		return x != -1;
	}
}