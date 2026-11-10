using LB2.Calculations;
using LB2.Input;
using LB2.Output;


namespace LB2
{
    internal class Program  
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray;

            if (!DataInput.ReadData(out jaggedArray))
                return;

            GroupStatistics[] groups =
                StatisticsCalculator.CalculateGroups(jaggedArray);

            StreamStatistics stream =
                StatisticsCalculator.CalculateStream(jaggedArray);

            ResultOutput.PrintGroups(groups);
            ResultOutput.PrintStream(stream);
        }
    }
}