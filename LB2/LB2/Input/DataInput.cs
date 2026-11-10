using System;

namespace LB2.Input
{
    internal class DataInput
    {
        public static bool ReadData(out int[][] jaggedArray)
        {
            jaggedArray = Array.Empty<int[]>();

            Console.Write("Введіть кількість груп (3-5): ");

            if (!int.TryParse(Console.ReadLine(), out int groups) ||
                groups < 3 || groups > 5)
            {
                Console.WriteLine("Помилка! Кількість груп має бути від 3 до 5.");
                return false;
            }

            jaggedArray = new int[groups][];

            for (int i = 0; i < groups; i++)
            {
                Console.Write($"\nКількість студентів у групі {i + 1} (10-30): ");

                if (!int.TryParse(Console.ReadLine(), out int students) ||
                    students < 10 || students > 30)
                {
                    Console.WriteLine("Помилка! Кількість студентів має бути від 10 до 30.");
                    return false;
                }

                jaggedArray[i] = new int[students];

                for (int j = 0; j < students; j++)
                {
                    Console.Write($"Оцінка студента {j + 1}: ");

                    if (!int.TryParse(Console.ReadLine(), out jaggedArray[i][j]))
                    {
                        Console.WriteLine("Помилка введення оцінки!");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
