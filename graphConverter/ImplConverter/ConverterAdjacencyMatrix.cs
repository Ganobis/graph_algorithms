using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using graphConverter.Interfaces;
using Newtonsoft.Json;

namespace graphConverter.ImplConverter;

public class ConverterAdjacencyMatrix : IGraphConverter<AdjacencyMatrix>
{
	public static string GraphToTxt(AdjacencyMatrix graph)
	{
		return graph.PrintGraph();
	}

	public static AdjacencyMatrix JsonToGraph(string path)
	{
		string json = File.ReadAllText(path);

		dynamic jsonData = JsonConvert.DeserializeObject(json) ?? throw new InvalidDataException(Text.ConverterAdjacencyMatrix_JsonToGraph_WrongData);
		string dataJson = jsonData.matrix.ToString();
		int[,] adjacencyTable = JsonConvert.DeserializeObject<int[,]>(dataJson) ?? throw new InvalidOperationException(Text.ConverterAdjacencyMatrix_JsonToGraph_WrongArray);
		int rows = adjacencyTable.GetLength(0);

		return new AdjacencyMatrix(rows, adjacencyTable);
	}
}