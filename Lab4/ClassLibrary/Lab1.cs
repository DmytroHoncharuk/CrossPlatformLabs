using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary;

public class Lab1
{
    public static void Execute(string inputPath,  string outputPath)
    {
        int numberOflevels;
        try
        {
            numberOflevels = ReadSingleNumberFromFile(inputPath);
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
            countOfTriangles = GetNumberOfTriangles(numberOflevels);
            Console.WriteLine($"Count of triangles: {countOfTriangles}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        try
        {
            WriteResultToFile(countOfTriangles, outputPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
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


    private static int ReadSingleNumberFromFile(string inputFileName)
    {
        if (!File.Exists(inputFileName))
        {
            throw new FileNotFoundException($"Не вдалося знайти файл: {inputFileName}.");
        }

        var lines = File.ReadAllLines(inputFileName)
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

    private static void WriteResultToFile(int result, string outputFileName)
    {
        File.WriteAllText(outputFileName, result.ToString(CultureInfo.InvariantCulture));
    }
}
