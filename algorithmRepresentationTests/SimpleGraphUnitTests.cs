using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using algorithmsRepresentation.ImplSimpleGraph.EdgeList;
using algorithmsRepresentation.ImplSimpleGraph.VertexGraph;

namespace algorithmRepresentationTests
{
	public class AddEdgeTests
	{
		private AdjacencyList _adjacencyList = new();
		private AdjacencyMatrix _adjacencyMatrix = new(8);
		private EdgeList _edgeList = new();
		private VertexGraph _vertexGraph = new();

		[OneTimeSetUp]
		public void AddFirstEdge_SetUp()
		{
			_adjacencyList.AddVertex(0);
			_vertexGraph.AddVertex(0);
			//do��czenie drugiego wieszcho�a
			_adjacencyList.AddVertex(1);
			_vertexGraph.AddVertex(1);
			//dodanie po��czenie mi�dzy 1 i 2
			_adjacencyMatrix.AddEdge(0, 1, 1);
			_vertexGraph.AddEdge(0, 1, 1);
			_adjacencyList.AddEdge(0, 1, 1);
			_edgeList.AddEdge(0, 1, 1);
		}

		[Test]
		public void OneEdgeAdjacencyList()
		{
			Assert.AreEqual(_adjacencyList.PrintGraph(), "Kraw�d�: (0, 1): waga 1\r\n");
		}

		[Test]
		public void OneEdgeVertexGraph()
		{
			Assert.AreEqual(_vertexGraph.PrintGraph(), "Wieszcho�ek 0: 1: waga 1 \r\nWieszcho�ek 1: 0: waga 1 \r\n");
		}

		[Test]
		public void OneEdgeAdjacencyMatrix()
		{
			Assert.AreEqual(_adjacencyMatrix.PrintGraph(), "Kraw�d�: (0, 1): waga 1\r\n");
		}

		[Test]
		public void OneEdgeEdgeList()
		{
			Assert.AreEqual(_edgeList.PrintGraph(), "Kraw�d�: (0, 1): waga 1\r\n");
		}
	}

	public class SimpleGraphTests
	{
		private AdjacencyList _adjacencyList = new();
		private AdjacencyMatrix _adjacencyMatrix = new(8);
		private EdgeList _edgeList = new();
		private VertexGraph _vertexGraph = new();

		private List<int> _vetrex5Neighbors = new(){ 2, 4, 6, 7 };
		[OneTimeSetUp]
		public void AddEdges_SetUp()
		{
			_adjacencyList.AddVertex(0);
			_vertexGraph.AddVertex(0);
			//do��czenie drugiego wieszcho�a
			_adjacencyList.AddVertex(1);
			_vertexGraph.AddVertex(1);
			//dodanie po��czenie mi�dzy 1 i 2
			_adjacencyMatrix.AddEdge(0, 1, 1);
			_vertexGraph.AddEdge(0, 1, 1);
			_adjacencyList.AddEdge(0, 1, 1);
			_edgeList.AddEdge(0, 1, 1);
			//dodanie trzeciego wieszcho�ka
			_adjacencyList.AddVertex(2);
			_vertexGraph.AddVertex(2);
			//dodanie po��czenie mi�dzy 2 i 3
			_adjacencyList.AddEdge(1, 2, 2);
			_vertexGraph.AddEdge(1, 2, 2);
			_adjacencyMatrix.AddEdge(1, 2, 2);
			_edgeList.AddEdge(1, 2, 2);
			//dodanie czwartego wieszcho�ka
			_adjacencyList.AddVertex(3);
			_vertexGraph.AddVertex(3);
			//dodanie po��czenia mi�dzy 2 i 4
			_adjacencyList.AddEdge(1, 3, 1);
			_vertexGraph.AddEdge(1, 3, 1);
			_adjacencyMatrix.AddEdge(1, 3, 1);
			_edgeList.AddEdge(1, 3, 1);
			//dodanie pi�tego wieszcho�ka
			_adjacencyList.AddVertex(4);
			_vertexGraph.AddVertex(4);
			//dodanie po��czenia mi�dzy 4 i 5
			_adjacencyList.AddEdge(3, 4, 5);
			_vertexGraph.AddEdge(3, 4, 5);
			_adjacencyMatrix.AddEdge(3, 4, 5);
			_edgeList.AddEdge(3, 4, 5);
			//dodanie sz�stego wieszcho�ka
			_adjacencyList.AddVertex(5);
			_vertexGraph.AddVertex(5);
			//dodanie po��czenia mi�dzy 3 i 6
			_adjacencyList.AddEdge(2, 5, 8);
			_vertexGraph.AddEdge(2, 5, 8);
			_adjacencyMatrix.AddEdge(2, 5, 8);
			_edgeList.AddEdge(2, 5, 8);
			//dodanie po��czenie mi�dzy 5 i 6
			_adjacencyList.AddEdge(4, 5, 1);
			_vertexGraph.AddEdge(4, 5, 1);
			_adjacencyMatrix.AddEdge(4, 5, 1);
			_edgeList.AddEdge(4, 5, 1);
			//dodanie si�dmengo wieszcho�ka
			_adjacencyList.AddVertex(6);
			_vertexGraph.AddVertex(6);
			//dodanie po��czenia mi�dzy 6 i 7
			_adjacencyList.AddEdge(5, 6, 1);
			_vertexGraph.AddEdge(5, 6, 1);
			_adjacencyMatrix.AddEdge(5, 6, 1);
			_edgeList.AddEdge(5, 6, 1);
			//dodanie �smego wieszcho�ka
			_adjacencyList.AddVertex(7);
			_vertexGraph.AddVertex(7);
			//dodanie po��czenia mi�dzy 6 i 8
			_adjacencyList.AddEdge(5, 7, 3);
			_vertexGraph.AddEdge(5, 7, 3);
			_adjacencyMatrix.AddEdge(5, 7, 3);
			_edgeList.AddEdge(5, 7, 3);
			//dodanie po��czenia mi�dzy 7 i 8
			_adjacencyList.AddEdge(6, 7, 8);
			_vertexGraph.AddEdge(6, 7, 8);
			_adjacencyMatrix.AddEdge(6, 7, 8);
			_edgeList.AddEdge(6, 7, 8);
		}

		[Test]
		public void SimpleGraphAdjacencyList()
		{
			Assert.AreEqual(_adjacencyList.PrintGraph(), "Kraw�d�: (0, 1): waga 1\r\nKraw�d�: (1, 2): waga 2\r\nKraw�d�: (1, 3): waga 1\r\nKraw�d�: (3, 4): waga 5\r\nKraw�d�: (2, 5): waga 8\r\nKraw�d�: (4, 5): waga 1\r\nKraw�d�: (5, 6): waga 1\r\nKraw�d�: (5, 7): waga 3\r\nKraw�d�: (6, 7): waga 8\r\n");
		}

		[Test]
		public void SimpleGraphVertexGraph()
		{
			Assert.AreEqual(_vertexGraph.PrintGraph(), "Wieszcho�ek 0: 1: waga 1 \r\nWieszcho�ek 1: 0: waga 1 2: waga 2 3: waga 1 \r\nWieszcho�ek 2: 1: waga 2 5: waga 8 \r\nWieszcho�ek 3: 1: waga 1 4: waga 5 \r\nWieszcho�ek 4: 3: waga 5 5: waga 1 \r\nWieszcho�ek 5: 2: waga 8 4: waga 1 6: waga 1 7: waga 3 \r\nWieszcho�ek 6: 5: waga 1 7: waga 8 \r\nWieszcho�ek 7: 5: waga 3 6: waga 8 \r\n");
		}

		[Test]
		public void SimpleGraphAdjacencyMatrix()
		{
			Assert.AreEqual(_adjacencyMatrix.PrintGraph(), "Kraw�d�: (0, 1): waga 1\r\nKraw�d�: (1, 2): waga 2\r\nKraw�d�: (1, 3): waga 1\r\nKraw�d�: (2, 5): waga 8\r\nKraw�d�: (3, 4): waga 5\r\nKraw�d�: (4, 5): waga 1\r\nKraw�d�: (5, 6): waga 1\r\nKraw�d�: (5, 7): waga 3\r\nKraw�d�: (6, 7): waga 8\r\n");
		}

		[Test]
		public void SimpleGraphEdgeList()
		{
			Assert.AreEqual(_edgeList.PrintGraph(), "Kraw�d�: (0, 1): waga 1\r\nKraw�d�: (1, 2): waga 2\r\nKraw�d�: (1, 3): waga 1\r\nKraw�d�: (3, 4): waga 5\r\nKraw�d�: (2, 5): waga 8\r\nKraw�d�: (4, 5): waga 1\r\nKraw�d�: (5, 6): waga 1\r\nKraw�d�: (5, 7): waga 3\r\nKraw�d�: (6, 7): waga 8\r\n");
		}

		[Test]
		public void GetNeighborsAdjacencyList()
		{
			CollectionAssert.AreEqual(_adjacencyList.GetNeighbors(5), _vetrex5Neighbors);
		}

		[Test]
		public void GetNeighborsVertexGraph()
		{
			CollectionAssert.AreEqual(_vertexGraph.GetNeighbors(5), _vetrex5Neighbors);
		}

		[Test]
		public void GetNeighborsAdjacencyMatrix()
		{
			CollectionAssert.AreEqual(_adjacencyMatrix.GetNeighbors(5), _vetrex5Neighbors);
		}

		[Test]
		public void GetNeighborshEdgeList()
		{
			CollectionAssert.AreEqual(_edgeList.GetNeighbors(5), _vetrex5Neighbors);
		}
	}
}