using LB2.Calculations;
using System;

namespace LB2.Output
{
    internal class ResultOutput
    {
        public static void PrintGroups(GroupStatistics[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"\nГрупа {i + 1}:");

                Console.WriteLine($"Середній бал: {groups[i].Average:F2}");
                Console.WriteLine($"Мінімальна оцінка: {groups[i].Min}");
                Console.WriteLine($"Максимальна оцінка: {groups[i].Max}");
            }
        }

        public static void PrintStream(StreamStatistics stream)
        {
            Console.WriteLine("\n===== ВЕСЬ ПОТІК =====");

            Console.WriteLine($"Середній бал потоку: {stream.Average:F2}");
            Console.WriteLine($"Мінімальна оцінка потоку: {stream.Min}");
            Console.WriteLine($"Максимальна оцінка потоку: {stream.Max}");
        }
    }
}