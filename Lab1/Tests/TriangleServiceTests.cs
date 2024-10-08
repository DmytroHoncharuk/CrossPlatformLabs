using App; // Простір імен для TrianglesService
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
	public class TriangleServiceTests
	{
		private readonly ITestOutputHelper _output;

		public TriangleServiceTests(ITestOutputHelper output)
		{
			_output = output;
		}

		[Theory]
		[InlineData(2, 5)]
		[InlineData(4, 27)]
		[InlineData(10, 315)]
		public void GetNumberOfTriangles_ValidLevels_ReturnsExpectedCount(int numberOfLevels, int expectedTriangles)
		{
			var result = TrianglesService.GetNumberOfTriangles(numberOfLevels);

			Assert.Equal(expectedTriangles, result);
			_output.WriteLine($"{nameof(GetNumberOfTriangles_ValidLevels_ReturnsExpectedCount)}: numberOfLevels: {numberOfLevels}, result: {result} - passed");
		}

		[Theory]
		[InlineData(0)]
		[InlineData(106)]
		public void GetNumberOfTriangles_InvalidLevels_ThrowsArgumentOutOfRangeException(int numberOfLevels)
		{
			void Act() => TrianglesService.GetNumberOfTriangles(numberOfLevels);

			Assert.Throws<ArgumentOutOfRangeException>(Act);
			_output.WriteLine($"{nameof(GetNumberOfTriangles_InvalidLevels_ThrowsArgumentOutOfRangeException)}: numberOfLevels: {numberOfLevels} - passed");
		}
	}
}
