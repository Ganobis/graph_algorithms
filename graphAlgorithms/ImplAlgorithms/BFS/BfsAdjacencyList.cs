using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.BFS;

public sealed class BfsAdjacencyList : BsfAbstract<AdjacencyList>
{
    private Dictionary<int, int> _previousVertex = null!;

    public BfsAdjacencyList(AdjacencyList adjacencyList) : base(adjacencyList)
    {
    }

    public override void FindPath(int source, int destination)
    {
		List<int> usedVertex = new();
        _previousVertex = new Dictionary<int, int>();
        Path = new List<int>();
        Queue<int> queue = new();

        queue.Enqueue(source);
        usedVertex.Add(source);
        _previousVertex[source] = -1;

        while (queue.Count > 0)
        {
            int currentVertex = queue.Dequeue();

            if (currentVertex == destination)
            {
                ReconstructPath(destination);
                return;
            }

            foreach (var neighbor in Graph.GetNeighbors(currentVertex))
            {
                if (!usedVertex.Contains(neighbor))
                {
                    usedVertex.Add(neighbor);
                    queue.Enqueue(neighbor);
                    _previousVertex[neighbor] = currentVertex;
                }
            }
        }
    }

    private void ReconstructPath(int destination)
    {
        int current = destination;
        while (current != -1)
        {
            Path.Insert(0, current);
            current = _previousVertex[current];
        }
    }
}