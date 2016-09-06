using System;

namespace RefactorYourCSharp1ExamSolutions
{
    public class EncodingSum
    {
        public static void Task2()
        {
            int m = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            char current = ' ';
            int result = 0;
            int i = 0;
            
            while (true)
            {
                if (i == input.Length)
                {
                    break;
                }

                current = input[i];
                if (current == '@')
                {
                    break;
                }

                if (current >= 48 && current <= 57) 
                {
                    // 0-9
                    result = result * ((int)current - 48);
                }
                else
                {
                    if (current >= 65 && current <= 90) 
                    {
                        // A-Z
                        result = result + current - 65;
                    }
                    else
                    {
                        if (current >= 97 && current <= 122) 
                        {
                            // a-z
                            result = result + current - 97;
                        }
                        else
                        {
                            result = result % m;
                        }
                    }
                }

                i++;
            }

            Console.WriteLine(result);
        }
    }
}