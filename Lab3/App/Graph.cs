using System;
using System.Collections.Generic;

namespace App
{
    public class Graph
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
