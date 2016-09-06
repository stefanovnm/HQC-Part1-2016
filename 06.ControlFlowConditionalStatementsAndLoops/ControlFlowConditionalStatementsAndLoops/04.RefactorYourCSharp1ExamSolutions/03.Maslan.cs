using System;
using System.Numerics;

namespace RefactorYourCSharp1ExamSolutions
{
    public class Maslan
    {
        public static void Task3()
        {
            string input = Console.ReadLine();
            string result = Transform(input);
            int counter = 1;
            while (result.Length > 1)
            {
                counter++;
                result = Transform(result);
                if (counter == 10)
                {
                    Console.WriteLine(result);
                    break;
                }
            }

            if (counter != 10)
            {
                Console.WriteLine(counter);
                Console.WriteLine(result);
            }
        }

        private static string Transform(string input)
        {
            BigInteger product = 1;
            int sum = 0;
            string number = input;
            for (int i = 0; i < input.Length; i++)
            {
                number = number.Remove(input.Length - i - 1);
                sum = 0;
                for (int j = 0; j < number.Length; j++)
                {
                    if (j % 2 != 0)
                    {
                        sum = sum + int.Parse(number[j].ToString());
                    }
                }

                if (sum != 0)
                {
                    product = product * sum;
                }

                if (sum == 0)
                {
                    break;
                }
            }

            return product.ToString();
        }
    }
}
