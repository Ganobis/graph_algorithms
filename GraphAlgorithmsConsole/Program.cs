using algorithmsRepresentation.ImplSimpleGraph.AdjacencyList;
using algorithmsRepresentation.ImplSimpleGraph.AdjacencyMatrix;
using algorithmsRepresentation.ImplSimpleGraph.EdgeList;
using algorithmsRepresentation.ImplSimpleGraph.VertexGraph;
using graphConverter.ImplConverter;
using graphAlgorithms.ImplAlgorithms.BFS;
using graphAlgorithms.ImplAlgorithms.DFS;
using graphAlgorithms.ImplAlgorithms.Dijkstra;
using graphAlgorithms.ImplAlgorithms.BellmanFord;
using graphAlgorithms.ImplAlgorithms.Kruskal;
using graphAlgorithms.ImplAlgorithms.Boruvka;
using algorithmsClock;

namespace GraphAlgorithmsConsole;

internal class Program
{
	static void Main(string[] args)
	{
        (int, int)[] points = new[]
        {
            (228, 132),
            (45, 11),
            (7, 49),
            (87, 214),
            (76, 151)
        };
        PrintTimeResults(points, "C:\\Users\\WGANOBIS\\Documents\\Praca magisterska\\polaczenia.json");
        DataAnalyze(45, 49, "C:\\Users\\WGANOBIS\\Documents\\Praca magisterska\\polaczenia.json");


        /*
        DataAnalyze(247, 132, Text.Main_GraphPath_500S);
        DataAnalyze(247, 132, Text.Main_GraphPath_500N);
        DataAnalyze(247, 132, Text.Main_GraphPath_500D);
        DataAnalyze(247, 132, Text.Main_GraphPath_1000S);
        DataAnalyze(247, 132, Text.Main_GraphPath_1000N);
        DataAnalyze(247, 132, Text.Main_GraphPath_1000D);
        DataAnalyze(247, 132, Text.Main_GraphPath_2000S);
        DataAnalyze(247, 132, Text.Main_GraphPath_2000N);
        DataAnalyze(247, 132, Text.Main_GraphPath_2000D);
        

        (int, int)[] points = new[]
        {
            (247, 132),
            (45, 388),
            (173, 49),
            (297, 214),
            (76, 431)
        };

        PrintTimeResults(points, Text.Main_GraphPath_500S);
        PrintTimeResults(points, Text.Main_GraphPath_1000S);
        PrintTimeResults(points, Text.Main_GraphPath_2000S);
        PrintTimeResults(points, Text.Main_GraphPath_500N);
        PrintTimeResults(points, Text.Main_GraphPath_1000N);
        PrintTimeResults(points, Text.Main_GraphPath_2000N);
        PrintTimeResults(points, Text.Main_GraphPath_500D);
        PrintTimeResults(points, Text.Main_GraphPath_1000D);
        PrintTimeResults(points, Text.Main_GraphPath_2000D);
        */
    }

    private static void PrintTimeResults((int, int)[] punkty, string graph)
	{
		Console.WriteLine(Text.PrintTimeResults_Line);
		Console.WriteLine(graph);
		Console.WriteLine();

		AdjacencyMatrix adjacencyMatrix = ConverterAdjacencyMatrix.JsonToGraph(graph);

		AdjacencyList adjacencyList = ConverterAjdacencyList.JsonToGraph(graph);

		EdgeList edgeList = ConverterEdgeList.JsonToGraph(graph);

		VertexGraph vertexGraph = ConverterVertexGraph.JsonToGraph(graph);


        BfsAdjacencyList bfsAdjacencyList = new(adjacencyList);
		Console.WriteLine(Text.PrintTimeResults_TimeBfsAdjacencyList + string.Join(", ", Clock.BenchmarkCpuTwoArg(bfsAdjacencyList.FindPath, punkty,
			() => { }, 5, 5)));

		BfsAdjacencyMatrix bfsAdjacencyMatrix = new(adjacencyMatrix);
		Console.WriteLine(Text.PrintTimeResults_TimeBfsAdjacencyMatrix + string.Join(", ", Clock.BenchmarkCpuTwoArg(bfsAdjacencyMatrix.FindPath, punkty,
			() => { }, 5, 5)));

		BfsEdgeList bfsEdgeList = new(edgeList);
		Console.WriteLine(Text.PrintTimeResults_TimeBfsEdgeList + string.Join(", ", Clock.BenchmarkCpuTwoArg(bfsEdgeList.FindPath, punkty,
			() => { }, 5, 5)));

		BfsVertexGraph bfsBfsVertexGraph = new(vertexGraph);
		Console.WriteLine(Text.PrintTimeResults_TimeBfsVertexGraph + string.Join(", ", Clock.BenchmarkCpuTwoArg(bfsBfsVertexGraph.FindPath, punkty,
			() => { }, 5, 5)));




		DfsAdjacencyList dfsAdjacencyList = new(adjacencyList);
		Console.WriteLine(Text.PrintTimeResults_TimeDfsAdjacencyList + string.Join(", ", Clock.BenchmarkCpuTwoArg(dfsAdjacencyList.FindPath, punkty,
			() => { }, 5, 5)));

		DfsAdjacencyMatrix dfsAdjacencyMatrix = new(adjacencyMatrix);
		Console.WriteLine(Text.PrintTimeResults_TimeDfsAdjacencyMatrix + string.Join(", ", Clock.BenchmarkCpuTwoArg(dfsAdjacencyMatrix.FindPath, punkty,
			() => { }, 5, 5)));

		DfsEdgeList dfsEdgeList = new(edgeList);
		Console.WriteLine(Text.PrintTimeResults_TimeDfsEdgeList + string.Join(", ", Clock.BenchmarkCpuTwoArg(dfsEdgeList.FindPath, punkty,
			() => { }, 5, 5)));

		DfsVertexGraph dfsDfsVertexGraph = new(vertexGraph);
		Console.WriteLine(Text.PrintTimeResults_TimeDfsTertexGraph + string.Join(", ", Clock.BenchmarkCpuTwoArg(dfsDfsVertexGraph.FindPath, punkty,
			() => { }, 5, 5)));




		BellmanFordAdjacencyList bellmanFordAdjacencyList = new(adjacencyList);
		Console.WriteLine(Text.PrintTimeResults_TimeBellmanFordAdjacencyList +
						  string.Join(", ", Clock.BenchmarkCpuTwoArg(bellmanFordAdjacencyList.FindPath, punkty,
							  bellmanFordAdjacencyList.ClearPath, 5, 5)));

        BellmanFordAdjacencyMatrix bellmanFordAdjacencyMatrix = new(adjacencyMatrix);
        Console.WriteLine(Text.PrintTimeResults_TimeBellmanFordAdjacencyMatrix + string.Join(", ", Clock.BenchmarkCpuTwoArg(bellmanFordAdjacencyMatrix.FindPath, punkty,
            bellmanFordAdjacencyMatrix.ClearPath, 5, 5)));

        BellmanFordEdgeList bellmanFordEdgeList = new(edgeList);
		Console.WriteLine(Text.PrintTimeResults_TimeBellmanFordEdgeList + string.Join(", ", Clock.BenchmarkCpuTwoArg(bellmanFordEdgeList.FindPath, punkty,
			bellmanFordEdgeList.ClearPath, 5, 5)));

		BellmanFordVertexGraph bellmanFordVertexGraph = new(vertexGraph);
		Console.WriteLine(Text.PrintTimeResults_TimeBellmanFordVertexGraph + string.Join(", ", Clock.BenchmarkCpuTwoArg(bellmanFordVertexGraph.FindPath, punkty,
			bellmanFordVertexGraph.ClearPath, 5, 5)));




		DijkstraAdjacencyList dijkstraAdjacencyList = new(adjacencyList);
		Console.WriteLine(Text.PrintTimeResults_TimeDijkstraAdjacencyList + string.Join(", ", Clock.BenchmarkCpuTwoArg(dijkstraAdjacencyList.FindPath, punkty,
			dijkstraAdjacencyList.ClearPath, 5, 5)));

        DijkstraAdjacencyMatrix dijkstraAdjacencyMatrix = new(adjacencyMatrix);
        Console.WriteLine(Text.PrintTimeResults_TimeDijkstraAdjacencyMatrix + string.Join(", ", Clock.BenchmarkCpuTwoArg(dijkstraAdjacencyMatrix.FindPath, punkty,
            dijkstraAdjacencyMatrix.ClearPath, 5, 5)));

        DijkstraEdgeList dijkstraEdgeList = new(edgeList);
		Console.WriteLine(Text.PrintTimeResults_TimeDijkstraEdgeList + string.Join(", ", Clock.BenchmarkCpuTwoArg(dijkstraEdgeList.FindPath, punkty,
			dijkstraEdgeList.ClearPath, 5, 5)));

		DijkstraVertexGraph dijkstraVertexGraph = new(vertexGraph);
		Console.WriteLine(Text.PrintTimeResults_TimeDijkstraVertexGraph + string.Join(", ", Clock.BenchmarkCpuTwoArg(dijkstraVertexGraph.FindPath, punkty,
			dijkstraVertexGraph.ClearPath, 5, 5)));




		BoruvkaAdjacencyList boruvkaAdjacencyList = new BoruvkaAdjacencyList(adjacencyList);
		Console.WriteLine(Text.PrintTimeResults_TimeBoruvkaAdjacencyList + string.Join(", ", Clock.BenchmarkCpu(boruvkaAdjacencyList.FindTree,
			boruvkaAdjacencyList.ClearTree, 5, 5)));

		BoruvkaAdjacencyMatrix boruvkaAdjacencyMatrix = new BoruvkaAdjacencyMatrix(adjacencyMatrix);
		Console.WriteLine(Text.PrintTimeResults_TimeBoruvkaAdjacencyMatrix + string.Join(", ", Clock.BenchmarkCpu(boruvkaAdjacencyMatrix.FindTree,
			() => { }, 5, 5)));

		BoruvkaEdgeList boruvkaEdgeList = new BoruvkaEdgeList(edgeList);
		Console.WriteLine(Text.PrintTimeResults_TimeBoruvkaEdgeList + string.Join(", ", Clock.BenchmarkCpu(boruvkaEdgeList.FindTree,
			boruvkaEdgeList.ClearTree, 5, 5)));

		BoruvkaVertexGraph boruvkaVertexGraph = new BoruvkaVertexGraph(vertexGraph);
		Console.WriteLine(Text.PrintTimeResults_TimeBoruvkaVertexGraph + string.Join(", ", Clock.BenchmarkCpu(boruvkaVertexGraph.FindTree,
			boruvkaVertexGraph.ClearTree, 5, 5)));



		KruskalAdjacencyList kruskalAdjacencyList = new KruskalAdjacencyList(adjacencyList);
		Console.WriteLine(Text.PrintTimeResults_TimeKruskalAdjacencyList + string.Join(", ", Clock.BenchmarkCpu(kruskalAdjacencyList.FindTree,
			kruskalAdjacencyList.ClearTree, 5, 5)));


		KruskalAdjacencyMatrix kruskalAdjacencyMatrix = new KruskalAdjacencyMatrix(adjacencyMatrix);
		Console.WriteLine(Text.PrintTimeResults_TimeKruskalAdjacencyMatrix + string.Join(", ", Clock.BenchmarkCpu(kruskalAdjacencyMatrix.FindTree,
			() => { }, 5, 5)));


		KruskalEdgeList kruskalEdgeList = new KruskalEdgeList(edgeList);
		Console.WriteLine(Text.PrintTimeResults_TimeKruskalEdgeList + string.Join(", ", Clock.BenchmarkCpu(kruskalEdgeList.FindTree,
			kruskalEdgeList.ClearTree, 5, 5)));

        KruskalVertexGraph kruskalVertexGraph = new KruskalVertexGraph(vertexGraph);
        Console.WriteLine(Text.PrintTimeResults_TimeKruskalVertexGraph + string.Join(", ", Clock.BenchmarkCpu(kruskalVertexGraph.FindTree,
            () => { kruskalVertexGraph.ClearTree(vertexGraph); }, 5, 5)));
    }

    private static void DataAnalyze(int source, int destination, string graph)
    {
        //AdjacencyList
        AdjacencyList adjacencyList = ConverterAjdacencyList.JsonToGraph(graph);


        BfsAdjacencyList bfsAdjacencyList = new(adjacencyList);
        bfsAdjacencyList.FindPath(source, destination);

        GC.Collect();

        DfsAdjacencyList dfsAdjacencyList = new(adjacencyList);
        dfsAdjacencyList.FindPath(source, destination);

        GC.Collect();

        BellmanFordAdjacencyList bellmanFordAdjacencyList = new(adjacencyList);
		bellmanFordAdjacencyList.FindPath(source, destination);

        GC.Collect();

        DijkstraAdjacencyList dijkstraAdjacencyList = new(adjacencyList);
		dijkstraAdjacencyList.FindPath(source, destination);

        GC.Collect();

        BoruvkaAdjacencyList boruvkaAdjacencyList = new BoruvkaAdjacencyList(adjacencyList);
        boruvkaAdjacencyList.FindTree();

        GC.Collect();

        KruskalAdjacencyList kruskalAdjacencyList = new KruskalAdjacencyList(adjacencyList);
		kruskalAdjacencyList.FindTree();

        GC.Collect();

        //---------------------------------
        //AdjacencyMatrix
        AdjacencyMatrix adjacencyMatrix = ConverterAdjacencyMatrix.JsonToGraph(graph);

        BfsAdjacencyMatrix bfsAdjacencyMatrix = new(adjacencyMatrix);
        bfsAdjacencyMatrix.FindPath(source, destination);

        GC.Collect();

        DfsAdjacencyMatrix dfsAdjacencyMatrix = new(adjacencyMatrix);
        dfsAdjacencyMatrix.FindPath(source, destination);

        GC.Collect();

        BellmanFordAdjacencyMatrix bellmanFordAdjacencyMatrix = new(adjacencyMatrix);
        bellmanFordAdjacencyMatrix.FindPath(source, destination);

        GC.Collect();

        DijkstraAdjacencyMatrix dijkstraAdjacencyMatrix = new(adjacencyMatrix);
		dijkstraAdjacencyMatrix.FindPath(source, destination);

        GC.Collect();

        BoruvkaAdjacencyMatrix boruvkaAdjacencyMatrix = new BoruvkaAdjacencyMatrix(adjacencyMatrix);
		boruvkaAdjacencyMatrix.FindTree();

        GC.Collect();

        KruskalAdjacencyMatrix kruskalAdjacencyMatrix = new KruskalAdjacencyMatrix(adjacencyMatrix);
		kruskalAdjacencyMatrix.FindTree();

        GC.Collect();

        //---------------------------------
        //EdgeList
        EdgeList edgeList = ConverterEdgeList.JsonToGraph(graph);

        BfsEdgeList bfsEdgeList = new(edgeList);
        bfsEdgeList.FindPath(source, destination);

        GC.Collect();

        DfsEdgeList dfsEdgeList = new(edgeList);
        dfsEdgeList.FindPath(source, destination);

        GC.Collect();

        BellmanFordEdgeList bellmanFordEdgeList = new(edgeList);
        bellmanFordEdgeList.FindPath(source, destination);

        GC.Collect();

        DijkstraEdgeList dijkstraEdgeList = new(edgeList);
		dijkstraEdgeList.FindPath(source, destination);

        GC.Collect();

        BoruvkaEdgeList boruvkaEdgeList = new BoruvkaEdgeList(edgeList);
		boruvkaEdgeList.FindTree();

        GC.Collect();

        KruskalEdgeList kruskalEdgeList = new KruskalEdgeList(edgeList);
		kruskalEdgeList.FindTree();

        GC.Collect();

        //---------------------------------
        //VertexGraph
        VertexGraph vertexGraph = ConverterVertexGraph.JsonToGraph(graph);

        BfsVertexGraph bfsBfsVertexGraph = new(vertexGraph);
        bfsBfsVertexGraph.FindPath(destination, source);

        GC.Collect();

        DfsVertexGraph dfsDfsVertexGraph = new(vertexGraph);
        dfsDfsVertexGraph.FindPath(source, destination);

        GC.Collect();

        BellmanFordVertexGraph bellmanFordVertexGraph = new(vertexGraph);
        bellmanFordVertexGraph.FindPath(source, destination);

        GC.Collect();

        DijkstraVertexGraph dijkstraVertexGraph = new(vertexGraph);
        dijkstraVertexGraph.FindPath(source, destination);

        GC.Collect();

        BoruvkaVertexGraph boruvkaVertexGraph = new BoruvkaVertexGraph(vertexGraph);
        boruvkaVertexGraph.FindTree();

        GC.Collect();

        KruskalVertexGraph kruskalVertexGraph = new KruskalVertexGraph(vertexGraph);
		kruskalVertexGraph.FindTree();
    }
}