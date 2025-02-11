using algorithmsRepresentation.ImplSimpleGraph.EdgeList;
using graphConverter.Interfaces;
using Newtonsoft.Json.Linq;

namespace graphConverter.ImplConverter;

public class ConverterEdgeList : IGraphConverter<EdgeList>
{
	public static string GraphToTxt(EdgeList graph)
	{
		return graph.PrintGraph();
	}

	public static EdgeList JsonToGraph(string path)
	{
		EdgeList edgeList = new();
		string json = File.ReadAllText(path);

		JObject jsonObject = JObject.Parse(json);
		foreach (var edge in jsonObject["edges"] ?? throw new InvalidDataException(Text.ConverterEdgeList_JsonToGraph_WrongEdges))
		{
			edgeList.AddEdge(
				(int)(edge["source"] ?? throw new InvalidDataException(Text.ConverterEdgeList_JsonToGraph_WrongSource)),
				(int)(edge["destination"] ?? throw new InvalidDataException(Text.ConverterEdgeList_JsonToGraph_WrongDestination)),
				(int)(edge["weight"] ?? throw new InvalidDataException(Text.ConverterEdgeList_JsonToGraph_WrongWeight)));
		}

		return edgeList;
	}
}