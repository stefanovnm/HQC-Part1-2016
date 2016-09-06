using System;

namespace VariablesDataExpressionsAndConstants
{
    public class StatisticsPrinter
    {
        public void PrintStatistics(double[] statistics, int count)
        {
            double max = this.FindMaxNumber(statistics, count);
            Console.WriteLine("Max: {0}", max);

            double min = this.FindMinNumber(statistics, count);
            Console.WriteLine("Min: {0}", min);

            double average = this.FindAverageNumber(statistics, count);
            Console.WriteLine("Average: {0}", min);
        }

        private double FindMaxNumber(double[] numbers, int count)
        {
            double max = numbers[0];

            for (int i = 0; i < count; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private double FindMinNumber(double[] numbers, int count)
        {
            double min = numbers[0];

            for (int i = 0; i < count; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private double FindAverageNumber(double[] numbers, int count)
        {
            double average = numbers[0];
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += numbers[i];
            }

            average = sum / count;

            return average;
        }
    }
}
