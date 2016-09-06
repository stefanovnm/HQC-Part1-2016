using System;
using System.Linq;
using System.Numerics;

namespace _02.RefactorYourCSharp2ExamSolutions
{
    public class SumOfDifferences
    {
        public static void Execute()
        {
            BigInteger[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => BigInteger.Parse(x))
                .ToArray();

            int i = 1;
            BigInteger sum = 0;
            BigInteger current = 0;

            while (i < input.Length)
            {
                current = Bigger(input[i], input[i - 1]) - Smaller(input[i], input[i - 1]);
                if (current % 2 == 1)
                {
                    sum += current;
                    i++;
                }
                else
                {
                    i += 2;
                }
            }

            Console.WriteLine(sum);
        }

        private static BigInteger Bigger(BigInteger a, BigInteger b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private static BigInteger Smaller(BigInteger a, BigInteger b)
        {
            if (a < b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}