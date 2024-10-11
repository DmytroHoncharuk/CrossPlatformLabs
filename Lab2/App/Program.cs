namespace App;

public class Program
{
    private static void Main()
    {        
        int numberOfLevels;
        try
        {
            numberOfLevels = IOHelper.ReadSingleNumberFromFile();  
            Console.WriteLine($"Number of Levels: {numberOfLevels}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading input file: {e.Message}");
            return;
        }

        int countOfWaysToBuildTower;
        try
        {
            countOfWaysToBuildTower = GlassProblemSolver.Solve(numberOfLevels);  
            Console.WriteLine($"Number of ways to build the tower: {countOfWaysToBuildTower}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error solving the problem: {e.Message}");
            return;
        }

        try
        {
            IOHelper.WriteResultToFile(countOfWaysToBuildTower);  
            Console.WriteLine("Result successfully written to OUTPUT.TXT");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing to output file: {e.Message}");
        }
    }
}
