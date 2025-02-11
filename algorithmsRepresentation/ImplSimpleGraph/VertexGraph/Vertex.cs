using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmsRepresentation.ImplSimpleGraph.VertexGraph;

public class Vertex : IEnumerable
{
	public int Id { get; }
	public Dictionary<Vertex, int> Neighbors { get; }

	public Vertex(int id)
	{
		Id = id;
		Neighbors = new Dictionary<Vertex, int>();
	}

	public void AddNeighbor(Vertex neighbor, int weight)
	{
		Neighbors.Add(neighbor, weight);
	}

	public IEnumerator GetEnumerator()
	{
		return Neighbors.Keys.GetEnumerator();
	}
}