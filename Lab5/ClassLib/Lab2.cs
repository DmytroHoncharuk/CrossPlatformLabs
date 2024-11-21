using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLib;

public static class Lab2
{
    public static string Execute(string text)
    {
        int numberOfLevels;
        try
        {
            numberOfLevels = ReadSingleNumberFromText(text);
            Console.WriteLine($"Number of Levels: {numberOfLevels}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading input file: {e.Message}");
            return "";
        }

        int countOfWaysToBuildTower;
        try
        {
            countOfWaysToBuildTower = Solve(numberOfLevels);
            Console.WriteLine($"Number of ways to build the tower: {countOfWaysToBuildTower}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error solving the problem: {e.Message}");
            return "";
        }

        return countOfWaysToBuildTower.ToString();
    }

    private static readonly int Modulus = 1000 * 1000;
    public static int Solve(int height)
    {
        if (height < 1 || height > 1e5)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "The number must be a natural number and less than or equal to 100000.");
        }

        List<int> count = new List<int>(new int[height + 1]);
        count[0] = 1;

        for (int h = 1; h <= height; h++)
        {
            if (h >= 10)
            {
                count[h] += count[h - 10];
            }
            if (h >= 11)
            {
                count[h] += count[h - 11];
            }
            if (h >= 12)
            {
                count[h] += count[h - 12];
            }
            count[h] %= Modulus;
        }

        return count[height] * 2 % Modulus;
    }

    public static int ReadSingleNumberFromText(string text)
    {
        var lines = text.Replace("\r", "")
           .Split('\n', StringSplitOptions.RemoveEmptyEntries)
           .Select(static line => line.Trim())
           .Where(static line => !string.IsNullOrWhiteSpace(line))
           .ToArray();

        if (lines.Length == 0)
        {
            throw new FormatException("The file cannot be empty.");
        }

        if (lines.Length != 1)
        {
            throw new FormatException("The file must contain only one line with a number.");
        }

        if (!int.TryParse(lines[0], out var number))
        {
            throw new FormatException("The file must contain a valid natural number.");
        }

        if (number < 1 || number > 1e5)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "The number must be a natural number and less than or equal to 100000.");
        }

        return number;
    }

    public static void WriteResultToFile(int result, string outputFileName)
    {
        File.WriteAllText(outputFileName, result.ToString());
    }
}
