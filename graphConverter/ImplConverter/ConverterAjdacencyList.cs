using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using graphConverter.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace graphConverter.ImplConverter;

public class ConverterAjdacencyList : IGraphConverter<AdjacencyList>
{
	public static string GraphToTxt(AdjacencyList graph)
	{
		return graph.PrintGraph();
	}

	public static AdjacencyList JsonToGraph(string path)
	{
		AdjacencyList adjacencyList = new();
		string json = File.ReadAllText(path);

		JObject jsonObject = JObject.Parse(json);
		foreach (var vertex in jsonObject["vertices"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongVertices))
		{
			adjacencyList.AddVertex((int)(vertex["id"] ?? throw new InvalidOperationException(Text.ConverterAjdacencyList_JsonToGraph_WrongId)));
		}
		foreach (var edge in jsonObject["edges"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongEdges))
		{
			adjacencyList.AddEdge(
				(int)(edge["source"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongSource)), 
				(int)(edge["destination"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongDestination)), 
				(int)(edge["weight"] ?? throw new InvalidDataException(Text.ConverterAjdacencyList_JsonToGraph_WrongWeight)));
		}

		return adjacencyList;
	}
}