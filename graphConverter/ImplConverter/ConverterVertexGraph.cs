using algorithmsRepresentation.ImplSimpleGraph.VertexGraph;
using graphConverter.Interfaces;
using Newtonsoft.Json.Linq;

namespace graphConverter.ImplConverter;

public class ConverterVertexGraph : IGraphConverter<VertexGraph>
{
	public static string GraphToTxt(VertexGraph graph)
	{
		return graph.PrintGraph();
	}

	public static VertexGraph JsonToGraph(string path)
	{
		VertexGraph vertexGraph = new();
		string json = File.ReadAllText(path);
		JObject jsonObject = JObject.Parse(json);

		foreach (var vertex in jsonObject["vertices"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongVertices))
		{
			vertexGraph.AddVertex((int)(vertex["id"] ?? throw new InvalidOperationException(Text.ConverterAjdacencyList_JsonToGraph_WrongId)));
		}

		foreach (var edge in jsonObject["edges"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongEdges))
		{
			vertexGraph.AddEdge(
				(int)(edge["source"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongSource)),
				(int)(edge["destination"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongDestination)),
				(int)(edge["weight"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongWeight)));
		}

		return vertexGraph;
	}
}