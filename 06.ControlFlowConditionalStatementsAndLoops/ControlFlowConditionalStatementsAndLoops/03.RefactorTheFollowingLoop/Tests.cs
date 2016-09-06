using System;

namespace _03.RefactorTheFollowingLoop
{
    public class Tests
    {
        public static void Main()
        {
            int expectedValue = 66;

            int[] array = GenerateArrayOfIntegers(100);
            
            IsInArray(expectedValue, array);
        }

        public static void IsInArray(int expectedValue, int[] array)
        {
            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == expectedValue)
                {
                    isFound = true;
                    Console.Write(array[i]);
                    Console.WriteLine(" - Value found!");
                    break;
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Value not found!");
            }
        }

        public static int[] GenerateArrayOfIntegers(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
