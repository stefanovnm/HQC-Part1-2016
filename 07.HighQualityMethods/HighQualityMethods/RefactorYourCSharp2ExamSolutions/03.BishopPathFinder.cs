using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.RefactorYourCSharp2ExamSolutions
{
    public class BishopPathFinder
    {
        public static void Execute()
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int count = int.Parse(Console.ReadLine());
            var moves = new List<Tuple<string, int>>();

            for (int k = 0; k < count; k++)
            {
                string current = Console.ReadLine();
                moves.Add(new Tuple<string, int>(current.Substring(0, 2), int.Parse(current.Substring(2, current.Length - 2))));
            }

            int[,] array = new int[size[0], size[1]];
            array = FulfillArray(array);

            bool[,] boolArray = new bool[size[0], size[1]];
            boolArray = FulfillBoolArray(boolArray);

            int i = array.GetLength(0) - 1;
            int j = 0;
            int sum = 0;

            foreach (var move in moves)
            {
                int avaiableMoves = Math.Min(move.Item2 - 1, AvaibleMoves(array, i, j, move.Item1));

                while (avaiableMoves > 0)
                {
                    i = MoveI(i, move.Item1);
                    j = MoveJ(j, move.Item1);

                    if (boolArray[i, j] == false)
                    {
                        sum += array[i, j];
                        boolArray[i, j] = true;
                    }

                    avaiableMoves--;
                }
            }

            Console.WriteLine(sum);
        }

        private static int[,] FulfillArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            array[i, j] = (array.GetLength(0) - 1) * 3;
                        }
                        else
                        {
                            array[i, j] = array[i - 1, j] - 3;
                        }
                    }
                    else
                    {
                        array[i, j] = array[i, j - 1] + 3;
                    }
                }
            }

            return array;
        }

        private static bool[,] FulfillBoolArray(bool[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = false;
                }
            }

            return array;
        }

        private static int AvaibleMoves(int[,] array, int i, int j, string dir)
        {
            int able = 0;

            if (dir == "RU" || dir == "UR")
            {
                able = Math.Min(i, array.GetLength(1) - 1 - j);
            }

            if (dir == "LU" || dir == "UL")
            {
                able = Math.Min(i, j);
            }

            if (dir == "RD" || dir == "DR")
            {
                able = Math.Min(array.GetLength(0) - 1 - i, array.GetLength(1) - 1 - j);
            }

            if (dir == "LD" || dir == "DL")
            {
                able = Math.Min(array.GetLength(0) - 1 - i, j);
            }

            return able;
        }

        private static int MoveI(int i, string dir)
        {
            if (dir == "RU" || dir == "UR")
            {
                i--;
            }

            if (dir == "LU" || dir == "UL")
            {
                i--;
            }

            if (dir == "RD" || dir == "DR")
            {
                i++;
            }

            if (dir == "LD" || dir == "DL")
            {
                i++;
            }

            return i;
        }

        private static int MoveJ(int j, string dir)
        {
            if (dir == "RU" || dir == "UR")
            {
                j++;
            }

            if (dir == "LU" || dir == "UL")
            {
                j--;
            }

            if (dir == "RD" || dir == "DR")
            {
                j++;
            }

            if (dir == "LD" || dir == "DL")
            {
                j--;
            }

            return j;
        }
    }
}