using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var (n, edges) = IOHelper.ReadGraphDataFromFile();

                string result = GraphService.ProcessGraph(n, edges);

                string finalResult = result.StartsWith("Yes") ? "Yes" : "No";

                Console.WriteLine(finalResult);
                IOHelper.WriteResultToFile(finalResult);
            }
            catch (Exception ex)
            {
                IOHelper.WriteResultToFile("No");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
