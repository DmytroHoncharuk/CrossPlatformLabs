using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Читання даних з файлу через IOHelper
                var (n, edges) = IOHelper.ReadGraphDataFromFile();

                // Обробка графа через GraphService
                string result = GraphService.ProcessGraph(n, edges);

                // Оскільки виведення повинно бути тільки "Yes" або "No",
                string finalResult = result.StartsWith("Yes") ? "Yes" : "No";

                // Запис результату у файл через IOHelper
                IOHelper.WriteResultToFile(finalResult);
            }
            catch (Exception ex)
            {
                // У випадку помилки, записуємо "No" у файл
                IOHelper.WriteResultToFile("No");
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
