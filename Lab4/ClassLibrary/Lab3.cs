﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary;

public class Lab3
{
    public static void Execute(string inputPath, string outputPath)
    {
        try
        {
            var (n, edges) = ReadGraphDataFromFile(inputPath);

            string result = ProcessGraph(n, edges);

            string finalResult = result.StartsWith("Yes") ? "Yes" : "No";

            Console.WriteLine(finalResult);
            WriteResultToFile(finalResult, outputPath);
        }
        catch (Exception ex)
        {
            WriteResultToFile("No", outputPath);
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
    private static (int, List<(int, int)>) ReadGraphDataFromFile(string inputFileName)
    {
        if (!File.Exists(inputFileName))
        {
            throw new FileNotFoundException($"Не вдалося знайти файл: {inputFileName}.");
        }

        var line = File.ReadAllText(inputFileName).Trim();
        var values = line.Split(' ');

        if (values.Length < 2)
        {
            throw new FormatException("Файл повинен містити принаймні два числа: кількість солдат і кількість пар.");
        }

        if (!values.All(v => int.TryParse(v, out _)))
        {
            throw new FormatException("Усі вхідні дані повинні бути цілими числами.");
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
            throw new ArgumentOutOfRangeException(variableName, $"{variableName} має бути в межах 1 та 100.");
        }
    }

    private static void CheckNumberOfEdges(int numberOfEdges, string variableName)
    {
        if (numberOfEdges < 1 || numberOfEdges > 5000)
        {
            throw new ArgumentOutOfRangeException(variableName, $"{variableName} має бути в межах 1 та 5000.");
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