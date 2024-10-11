namespace App;

public static class IOHelper
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static int ReadSingleNumberFromFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new FileNotFoundException($"Could not find file: {InputFileName}.");
        }

        var lines = File.ReadAllLines(InputFileName)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
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

    public static void WriteResultToFile(int result)
    {
        File.WriteAllText(OutputFileName, result.ToString());
    }
}
