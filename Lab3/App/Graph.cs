using System;
using System.Collections.Generic;

namespace App
{
	public class Graph
	{
		private readonly List<int>[] _adjacencyList;
		private readonly bool[] _visitedNodes;
		private readonly bool[] _nodesInRecursion;
		private readonly List<int> _sortedNodes;

		public Graph(int numberOfNodes)
		{
			_adjacencyList = new List<int>[numberOfNodes];
			_visitedNodes = new bool[numberOfNodes];
			_nodesInRecursion = new bool[numberOfNodes];
			_sortedNodes = new List<int>();

			for (int i = 0; i < numberOfNodes; i++)
			{
				_adjacencyList[i] = new List<int>();
			}
		}

		public void AddDirectedEdge(int sourceNode, int targetNode)
		{
			_adjacencyList[targetNode].Add(sourceNode);
		}

		public bool PerformTopologicalSort()
		{
			for (int i = 0; i < _adjacencyList.Length; i++)
			{
				if (!_visitedNodes[i] && !PerformDepthFirstSearch(i))
				{
					return false;
				}
			}
			return true;
		}

		public List<int> GetTopologicallySortedNodes()
		{
			_sortedNodes.Reverse();
			return _sortedNodes;
		}

		private bool PerformDepthFirstSearch(int currentNode)
		{
			if (_nodesInRecursion[currentNode])
			{
				return false;
			}

			if (_visitedNodes[currentNode])
			{
				return true;
			}

			_nodesInRecursion[currentNode] = true;
			foreach (var neighbor in _adjacencyList[currentNode])
			{
				if (!PerformDepthFirstSearch(neighbor))
				{
					return false;
				}
			}

			_nodesInRecursion[currentNode] = false;
			_visitedNodes[currentNode] = true;
			_sortedNodes.Add(currentNode);
			return true;
		}
	}
}
