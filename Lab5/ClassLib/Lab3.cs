using System.Text;

namespace ClassLib;

public static class Lab3
{
    public static string Execute(string text)
    {
        string finalResult = String.Empty;
        try
        {
            var (n, edges) = ReadGraphDataFromText(text);

            string result = ProcessGraph(n, edges);

            finalResult = result.StartsWith("Yes") ? "Yes" : "No";

            Console.WriteLine(finalResult);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return finalResult;

    }
    private static (int, List<(int, int)>) ReadGraphDataFromText(string text)
    {
        var line = text.Trim();
        var values = line.Split(' ');

        if (values.Length < 2)
        {
            throw new FormatException("File must contain at least two numbers: soldiers count and pairs count.");
        }

        if (!values.All(v => int.TryParse(v, out _)))
        {
            throw new FormatException("All output data must be integers.");
        }

        var intValues = values.Select(int.Parse).ToArray();

        int n = intValues[0];
        int m = intValues[1];

        var edges = new List<(int, int)>();
        for (int i = 0; i < m; i++)
        {
            int from = intValues[2 + 2 * i] - 1;
            int to = intValues[3 + 2 * i] - 1;
            edges.Add((from, to));
        }

        return (n, edges);
    }

    private static void WriteResultToFile(string result, string outputFileName)
    {
        File.WriteAllText(outputFileName, result);
    }
    private static string ProcessGraph(int n, List<(int, int)> edges)
    {
        CheckNumberOfNodes(n, nameof(n));
        CheckNumberOfEdges(edges.Count, nameof(edges));

        var graph = new Graph(n);

        foreach (var (from, to) in edges)
        {
            graph.AddEdge(from, to);
        }

        if (graph.Toposort())
        {
            var sortedNodes = graph.GetSortedNodes();
            return "Yes\n" + string.Join(" ", sortedNodes.Select(node => node + 1));
        }
        else
        {
            return "No";
        }
    }

    private static void CheckNumberOfNodes(int numberOfNodes, string variableName)
    {
        if (numberOfNodes < 1 || numberOfNodes > 100)
        {
            throw new ArgumentOutOfRangeException(variableName, $"{variableName} must be in range of 1 to 100.");
        }
    }

    private static void CheckNumberOfEdges(int numberOfEdges, string variableName)
    {
        if (numberOfEdges < 1 || numberOfEdges > 5000)
        {
            throw new ArgumentOutOfRangeException(variableName, $"{variableName} must be in range of 1 to 5000.");
        }
    }
    private class Graph
    {
        private readonly List<int>[] _adjacencyList;
        private readonly bool[] _visited;
        private readonly bool[] _onStack;
        private readonly List<int> _sortedNodes;

        public Graph(int nodeCount)
        {
            _adjacencyList = new List<int>[nodeCount];
            _visited = new bool[nodeCount];
            _onStack = new bool[nodeCount];
            _sortedNodes = new List<int>();

            for (int i = 0; i < nodeCount; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int from, int to)
        {
            _adjacencyList[to].Add(from);
        }

        public bool Toposort()
        {
            for (int i = 0; i < _adjacencyList.Length; i++)
            {
                if (!_visited[i] && !Traverse(i))
                {
                    return false;
                }
            }
            return true;
        }

        public List<int> GetSortedNodes()
        {
            _sortedNodes.Reverse();
            return _sortedNodes;
        }

        private bool Traverse(int node)
        {
            if (_onStack[node])
            {
                return false;
            }

            if (_visited[node])
            {
                return true;
            }

            _onStack[node] = true;
            foreach (var neighbor in _adjacencyList[node])
            {
                if (!Traverse(neighbor))
                {
                    return false;
                }
            }

            _onStack[node] = false;
            _visited[node] = true;
            _sortedNodes.Add(node);
            return true;
        }
    }
}
