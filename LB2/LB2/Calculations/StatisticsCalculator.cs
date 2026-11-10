using LB2.Calculations;

namespace LB2.Calculations
{
    internal class StatisticsCalculator
    {
        public static GroupStatistics[] CalculateGroups(int[][] array)
        {
            GroupStatistics[] results = new GroupStatistics[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                long sum = 0;
                int min = array[i][0];
                int max = array[i][0];

                for (int j = 0; j < array[i].Length; j++)
                {
                    int grade = array[i][j];

                    sum += grade;

                    if (grade < min)
                        min = grade;

                    if (grade > max)
                        max = grade;
                }

                results[i] = new GroupStatistics
                {
                    Average = (double)sum / array[i].Length,
                    Min = min,
                    Max = max
                };
            }

            return results;
        }

        public static StreamStatistics CalculateStream(int[][] array)
        {
            long sum = 0;
            int count = 0;

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    int grade = array[i][j];

                    sum += grade;
                    count++;

                    if (grade < min)
                        min = grade;

                    if (grade > max)
                        max = grade;
                }
            }

            return new StreamStatistics
            {
                Average = (double)sum / count,
                Min = min,
                Max = max
            };
        }
    }
}