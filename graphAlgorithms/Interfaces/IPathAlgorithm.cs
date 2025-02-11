namespace graphAlgorithms.Interfaces;

public interface IPathAlgorithm
{
	public void FindPath(int source, int destination);
	public List<int> GetPath();
	public int GetPathLength();
}