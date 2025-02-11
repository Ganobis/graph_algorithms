using algorithmsRepresentation.interfaces;
using graphAlgorithms.Interfaces;

namespace graphAlgorithms.AbstractClasses;

public abstract class BoruvkaAbstract<T> : IMinimumSpanningTree<T> where T : ISimpleGraph
{
	protected T Graph;
	protected T MinimumSpanningGraph = default!;

	protected BoruvkaAbstract(T graph)
	{
		Graph = graph;
	}

	public abstract void FindTree();

	public T GetTree()
	{
		return MinimumSpanningGraph;
	}

	public virtual int GetEdgeWeight()
	{
		return MinimumSpanningGraph.GetAllEdges().Sum(edge => edge.Item3);
	}
}