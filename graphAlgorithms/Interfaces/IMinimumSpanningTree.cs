namespace graphAlgorithms.Interfaces;
public interface IMinimumSpanningTree<out T>
{
	void FindTree();
	public T GetTree();
	public int GetEdgeWeight();
}