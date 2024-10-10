using System.Globalization;

namespace App;

public static class IOHelper
{
    public static (int, List<(int, int)>) ReadGraphDataFromFile(string inputFileName = "INPUT.TXT")
    {
        if (!File.Exists(inputFileName))
        {
            throw new FileNotFoundException($"Не вдалося знайти файл: {inputFileName}.");
        }

        var line = File.ReadAllText(inputFileName).Trim();
        var values = line.Split(' ');

        if (values.Length < 2)
        {
            throw new FormatException("Файл повинен містити принаймні два числа: кількість солдат і кількість пар.");
        }

        if (!values.All(v => int.TryParse(v, out _)))
        {
            throw new FormatException("Усі вхідні дані повинні бути цілими числами.");
        }

        var intValues = values.Select(int.Parse).ToArray();

        int n = intValues[0];
        int m = intValues[1];

        var edges = new List<(int, int)>();
        for (int i = 0; i < m; i++)
        {
            int from = intValues[2 + 2 * i] - 1;
            int to = intValues[3 + 2 * i] - 1;
            edges.Add((from, to));
        }

        return (n, edges);
    }

    public static void WriteResultToFile(string result, string outputFileName = "OUTPUT.TXT")
    {
        File.WriteAllText(outputFileName, result);
    }
}
