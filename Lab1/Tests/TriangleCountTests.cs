using App;
using Xunit.Abstractions;


namespace Tests
{
	public class TriangleCountTests(ITestOutputHelper output)
	{
		private readonly ITestOutputHelper _output = output;


		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 5)]
		[InlineData(4, 27)]
		[InlineData(10, 315)]
		[InlineData(26, 4823)]

		public void Test_CountNumberOfTriangles_ValidCases(int numberOfLevels, int expectedTriangles)
		{
			var result = TrianglesCounter.CountNumberOfTriangles(numberOfLevels);

			Assert.Equal(expectedTriangles, result);

            _output.WriteLine($"{nameof(Test_CountNumberOfTriangles_ValidCases)}n: {numberOfLevels}, result: {result} - passed");
        }
	}
}
