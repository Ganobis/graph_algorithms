namespace algorithmsRepresentation.interfaces
{
	public interface ISimpleGraph
	{
		public void AddEdge(int source, int destination, int weight);
		public List<int> GetNeighbors(int vertex);
		public List<int> GetVertices();
		public string PrintGraph();
		public List<Tuple<int, int, int>> GetAllEdges();
		public int GetWeight(int source, int destination);
	}
}
