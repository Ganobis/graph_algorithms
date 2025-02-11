using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using graphAlgorithms.AbstractClasses;

namespace graphAlgorithms.ImplAlgorithms.Boruvka;

public sealed class BoruvkaAdjacencyMatrix : BoruvkaAbstract<AdjacencyMatrix>
{
	public BoruvkaAdjacencyMatrix(AdjacencyMatrix graph) : base(graph)
	{
	}

	public override void FindTree()
	{
		int numVertices = Graph.NumVertices;
		MinimumSpanningGraph = new AdjacencyMatrix(numVertices);
		int[] sources = Graph.GetAllEdges().Select(item => item.Item1).ToArray();
		int[] destinations = Graph.GetAllEdges().Select(item => item.Item2).ToArray();

		int[] cheapestEdge = new int[numVertices];
		int[] component = new int[numVertices];

		for (int i = 0; i < numVertices; i++)
		{
			cheapestEdge[i] = -1;
			component[i] = i;
		}

		int numTrees = numVertices;

		while (numTrees > 1)
		{
			for (int i = 0; i < sources.Length; i++)
			{
				int source = sources[i];
				int dest = destinations[i];

				int componentSource = Find(component, source);
				int componentDest = Find(component, dest);

				if (componentSource != componentDest)
				{
					if (cheapestEdge[componentSource] == -1 || Graph.GetWeight(source, dest) < Graph.GetWeight(sources[cheapestEdge[componentSource]], destinations[cheapestEdge[componentSource]]))
					{
						cheapestEdge[componentSource] = i;
					}

					if (cheapestEdge[componentDest] == -1 || Graph.GetWeight(source, dest) < Graph.GetWeight(sources[cheapestEdge[componentDest]], destinations[cheapestEdge[componentDest]]))
					{
						cheapestEdge[componentDest] = i;
					}
				}
			}

			for (int j = 0; j < numVertices; j++)
			{
				if (cheapestEdge[j] != -1)
				{
					int source = sources[cheapestEdge[j]];
					int dest = destinations[cheapestEdge[j]];

					int componentSource = Find(component, source);
					int componentDest = Find(component, dest);

					if (componentSource != componentDest)
					{
						MinimumSpanningGraph.AddEdge(source, dest, Graph.GetWeight(source, dest));

						Union(component, componentSource, componentDest);
						numTrees--;
					}

					cheapestEdge[j] = -1;
				}
			}
		}
	}

	private int Find(int[] component, int vertex)
	{
		if (component[vertex] != vertex)
		{
			component[vertex] = Find(component, component[vertex]);
		}
		return component[vertex];
	}

	private void Union(int[] component, int x, int y)
	{
		int rootX = Find(component, x);
		int rootY = Find(component, y);
		component[rootX] = rootY;
	}
}