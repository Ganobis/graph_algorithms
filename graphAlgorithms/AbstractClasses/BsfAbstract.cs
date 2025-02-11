using graphAlgorithms.Interfaces;

namespace graphAlgorithms.AbstractClasses;

public abstract class BsfAbstract<T> : IPathAlgorithm
{
	protected readonly T Graph;
	protected List<int> Path;

	protected BsfAbstract(T graph)
	{
		Graph = graph;
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
}