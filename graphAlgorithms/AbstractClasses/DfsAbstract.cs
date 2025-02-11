using graphAlgorithms.Interfaces;

namespace graphAlgorithms.AbstractClasses;

public abstract class DfsAbstract<T> : IPathAlgorithm
{
	protected readonly T Graph;
	protected List<int> Path;

	protected DfsAbstract(T graph)
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