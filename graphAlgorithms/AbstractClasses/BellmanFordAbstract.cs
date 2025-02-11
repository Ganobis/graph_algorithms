using algorithmsRepresentation.interfaces;
using graphAlgorithms.Interfaces;

namespace graphAlgorithms.AbstractClasses;

public abstract class BellmanFordAbstract<T> : IWeightPathAlgorithm where T : ISimpleGraph
{
	protected readonly T Graph;
	protected readonly List<int> Path;
	protected readonly Dictionary<int, int> Distances;
	protected readonly Dictionary<int, int> Previous;

	protected BellmanFordAbstract(T graph)
	{
		Graph = graph;
		Path = new List<int>();
		Distances = new Dictionary<int, int>();
		Previous = new Dictionary<int, int>();
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
