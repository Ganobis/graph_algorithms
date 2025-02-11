using algorithmsRepresentation.ImplSimpleGraph;
using algorithmsRepresentation.interfaces;

namespace algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;

public class AdjacencyMatrix : ISimpleGraph
{
	private readonly int[,] _adjacencyMatrix;
	private readonly int _numVertices;

	public int NumVertices => _numVertices;

	public AdjacencyMatrix(int vertices)
	{
		_numVertices = vertices;
		_adjacencyMatrix = new int[vertices, vertices];
	}

	public AdjacencyMatrix(int vertices, int[,] adjacencyMatrix)
	{
		_numVertices = vertices;
		_adjacencyMatrix = adjacencyMatrix;
	}

	public AdjacencyMatrix(AdjacencyMatrix adjacencyMatrix)
	{
		_adjacencyMatrix = adjacencyMatrix._adjacencyMatrix;
		_numVertices = adjacencyMatrix._numVertices;
	}

	public void AddEdge(int source, int destination, int weight)
	{
		if (source >= 0 && source < _numVertices && destination >= 0 && destination < _numVertices)
		{
			if (source > destination)
			{
				(source, destination) = (destination, source);
			}
			_adjacencyMatrix[source, destination] = weight;
		}
		else
		{
			throw new Exception(GraphResource.AddEdge_AdjacencyMatrix_WrongData);
		}
	}

	public List<int> GetNeighbors(int vertex)
	{
		List<int> neighbors = new();

		for (int i = 0; i < _numVertices; i++)
		{
			if (i < vertex)
			{
				if (_adjacencyMatrix[i, vertex] > 0)
					neighbors.Add(i);
			}
			else if (vertex < i)
			{
				if (_adjacencyMatrix[vertex, i] > 0)
					neighbors.Add(i);
			}
		}

		return neighbors;
	}

	public List<int> GetVertices()
	{
		List<int> vertexList = new();
		for (int i = 0; i < _numVertices; i++)
		{
			for (int j = i + 1; j < _numVertices && j < _numVertices; j++)
			{
				if (_adjacencyMatrix[i, j] != 0)
				{
					if (!vertexList.Contains(j))
					{
						vertexList.Add(j);
					}
					if (!vertexList.Contains(i))
					{
						vertexList.Add(i);
					}
				}
			}
		}
		return vertexList;
	}

	public List<Tuple<int, int, int>> GetAllEdges()
	{
		List<Tuple<int, int, int>> allEdges = new();

		for (int i = 0; i < _numVertices; i++)
		{
			for (int j = i + 1; j < _numVertices; j++)
			{
				if (_adjacencyMatrix[i, j] != 0)
				{
					allEdges.Add(new Tuple<int, int, int>(i, j, _adjacencyMatrix[i, j]));
				}
			}
		}

		return allEdges;
	}

	public string PrintGraph()
	{
		string result = null!;
		for (int i = 0; i < _numVertices; i++)
		{
			for (int j = i + 1; j < _numVertices; j++)
			{
				if (_adjacencyMatrix[i, j] != 0)
				{
					result += string.Format(GraphResource.PrintGraph_Text, i, j, _adjacencyMatrix[i, j]) + Environment.NewLine;
				}
			}
		}
		return result;
	}

	public int GetWeight(int source, int destination)
	{
		if (source > destination)
		{
			(source, destination) = (destination, source);
		}
		return _adjacencyMatrix[source, destination];
	}
}