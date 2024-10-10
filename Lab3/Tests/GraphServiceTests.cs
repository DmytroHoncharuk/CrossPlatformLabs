using System;
using System.Collections.Generic;
using Xunit;

namespace App.Tests
{
    public class GraphServiceTests
    {
        [Theory]
        [InlineData(5, new[] { 1, 3, 1, 4, 4, 3, 5, 2 }, "Yes")]
        [InlineData(3, new[] { 1, 2, 1, 3, 2, 3 }, "Yes")]
        [InlineData(4, new[] { 1, 2, 2, 3, 3, 4, 1, 4, 4, 1 }, "No")]
        [InlineData(2, new[] { 1, 2 }, "Yes")]
        [InlineData(2, new[] { 1, 2, 2, 1 }, "No")]
        [InlineData(4, new[] { 1, 2, 2, 3, 3, 1 }, "No")] 
        [InlineData(6, new[] { 1, 2, 1, 3, 2, 4, 3, 4, 4, 5, 5, 6 }, "Yes")] 
        [InlineData(3, new[] { 1, 2, 2, 3 }, "Yes")]
        [InlineData(4, new[] { 1, 2, 2, 3, 3, 4, 4, 2 }, "No")] 
        [InlineData(6, new[] { 1, 2, 1, 3, 2, 4, 4, 5, 5, 6 }, "Yes")]
        public void TestProcessGraph(int n, int[] edgeArray, string expectedResult)
        {
            var edges = ConvertEdgeArrayToList(edgeArray);
            var result = GraphService.ProcessGraph(n, edges);
            Assert.Equal(expectedResult, result.Split('\n')[0]);
        }

        private List<(int, int)> ConvertEdgeArrayToList(int[] edgeArray)
        {
            var edges = new List<(int, int)>();
            for (int i = 0; i < edgeArray.Length; i += 2)
            {
                edges.Add((edgeArray[i] - 1, edgeArray[i + 1] - 1));
            }
            return edges;
        }
    }
}