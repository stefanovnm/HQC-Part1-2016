using System;

namespace RefactorYourCSharp1ExamSolutions
{
    public class SequencesOfBits
    {
        public static void Task5()
        {
            int num = int.Parse(Console.ReadLine());
            string[] numbers = new string[num];
            string result = string.Empty;

            for (int i = 0; i < num; i++)
            {
                string number = Console.ReadLine();
                numbers[i] = Convert.ToString(int.Parse(number), 2).PadLeft(30, '0');
                result = result + numbers[i];
            }

            Console.WriteLine(LongSequance(result, '1'));
            Console.WriteLine(LongSequance(result, '0'));
        }

        private static int LongSequance(string input, char type)
        {
            int longest = 0;
            int test = 0;
            bool isEqual = false;
            bool wasEqual = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == type && longest == 0)
                {
                    longest = 1;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == type)
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = false;
                }

                if (wasEqual && isEqual)
                {
                    isEqual = true;
                    wasEqual = true;
                    test++;
                    if (test > longest)
                    {
                        longest = test;
                    }    
                }

                if (wasEqual && !isEqual)
                {
                    wasEqual = false;
                    isEqual = false;
                    test = 0;
                }

                if (!wasEqual && isEqual)
                {
                    test++;
                    wasEqual = true;
                    isEqual = true;
                }

                if (!wasEqual && !isEqual)
                {
                    isEqual = false;
                    wasEqual = false;
                } 
            }

            return longest;
        }
    }
}
