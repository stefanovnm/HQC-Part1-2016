using System;
using System.Linq;

namespace _02.RefactorYourCSharp2ExamSolutions
{
    public class MathProblem
    {
        public static void Execute()
        {
            int sum = Input();
            Console.WriteLine("{0} = {1}", DecimalToNineteenth(sum), sum);
        }

        private static int Power(int number, int deg)
        {
            int result = number;

            for (int i = 0; i < deg; i++)
            {
                result *= 19;
            }

            return result;
        }

        private static int Input()
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int sum = 0;
            int counter = 0;

            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    sum += Power((int)item[i] - 97, item.Length - 1 - counter);
                    counter++;

                    if (i == item.Length - 1)
                    {
                        counter = 0;
                    }
                }
            }

            return sum;
        }

        private static string DecimalToNineteenth(int number)
        {
            int tempNumber = number;
            string result = string.Empty;

            while (tempNumber > 0)
            {
                char current = (char)((tempNumber % 19) + 97);
                result = current + result;
                tempNumber = tempNumber / 19;
            }

            return result;
        }
    }
}