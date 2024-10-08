namespace App
{
    internal static class Program
    {
        private static void Main()
        {
            int numberOflevels;
            try
            {
                numberOflevels = IOHelper.ReadSingleNumberFromFile();
                Console.WriteLine($"Number of Levels: {numberOflevels}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            int countOfTriangles;
            try
            {
                countOfTriangles = TrianglesService.GetNumberOfTriangles(numberOflevels);
                Console.WriteLine($"Count of triangles: {countOfTriangles}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            {
                IOHelper.WriteResultToFile(countOfTriangles);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}