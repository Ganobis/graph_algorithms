using graphAlgorithms.Interfaces;
using algorithmsRepresentation.interfaces;

namespace graphAlgorithms.AbstractClasses;

public abstract class DijkstraAbstract<T> : IWeightPathAlgorithm where T : ISimpleGraph
{
	protected readonly T Graph;
	protected readonly Dictionary<int, int> Previous;
	protected readonly Dictionary<int, int> Distances;
	protected readonly List<int> Path;
	protected DijkstraAbstract(T graph)
	{
		Graph = graph;
		Previous = new Dictionary<int, int>();
		Distances = new Dictionary<int, int>();
		Path = new List<int>();
	}

	public abstract void FindPath(int source, int destination);

	public List<int> GetPath()
	{
		return Path;
	}

	public int GetPathLength()
	{
		return Path.Count;
	}

	public int GetWeightPath()
	{
		int weight = 0;
		for (int i = 0; i < Path.Count - 1; i++)
		{
			weight += Graph.GetWeight(Path[i], Path[i + 1]);
		}
		return weight;
	}

	public void ClearPath()
	{
		Path.Clear();
	}
}