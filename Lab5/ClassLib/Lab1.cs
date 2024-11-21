using System.Globalization;

namespace ClassLib;

public static class Lab1
{
    public static string Execute(string text)
    {
        int numberOflevels;
        try
        {
            numberOflevels = ReadSingleNumberFromText(text);
            Console.WriteLine($"Number of Levels: {numberOflevels}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return e.Message;
        }

        int countOfTriangles;
        try
        {
            countOfTriangles = GetNumberOfTriangles(numberOflevels);
            Console.WriteLine($"Count of triangles: {countOfTriangles}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return e.Message;
        }

        return countOfTriangles.ToString();

    }

    private static int CountNumberOfTriangles(int numberOfLevels)
    {
        return ((numberOfLevels * (numberOfLevels + 2) * (numberOfLevels * 2 + 1)) / 8);
    }

    private static int GetNumberOfTriangles(int numberOfLevels)
    {
        CheckNumberOfLevels(numberOfLevels, nameof(numberOfLevels));

        int countedTriangles = CountNumberOfTriangles(numberOfLevels);

        return countedTriangles;
    }



    private static void CheckNumberOfLevels(int numberOfLevels, string variableName)
    {
        if (numberOfLevels <= 0 || numberOfLevels >= 106)
        {
            throw new ArgumentOutOfRangeException(variableName, $"{variableName} має бути в межах 1 та 105.");
        }

    }


    private static int ReadSingleNumberFromText(string text)
    {
        var lines = text.Replace("\r", "")
           .Split('\n', StringSplitOptions.RemoveEmptyEntries)
           .Select(static line => line.Trim())
           .Where(static line => !string.IsNullOrWhiteSpace(line))
           .ToArray();

        if (lines.Length == 0)
        {
            throw new FormatException("Файл не може бути порожнім.");
        }

        if (lines.Length != 1)
        {
            throw new FormatException("Файл повинен містити лише один рядок із даними.");
        }

        if (!int.TryParse(lines[0], out var numberofLevels))
        {
            throw new FormatException("Дані в файлі повинні містити одне ціле число.");
        }

        return numberofLevels;
    }
}

