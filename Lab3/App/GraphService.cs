using System;
using System.Collections.Generic;

namespace App
{
    public static class GraphService
    {
        public static string ProcessGraph(int n, List<(int, int)> edges)
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
    }
}
