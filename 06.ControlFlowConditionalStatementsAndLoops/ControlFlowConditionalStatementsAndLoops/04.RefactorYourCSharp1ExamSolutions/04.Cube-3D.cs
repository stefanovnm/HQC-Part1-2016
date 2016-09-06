using System;

namespace RefactorYourCSharp1ExamSolutions
{
    public class Cube3D
    {
        public static void Task4()
        {
            int input = int.Parse(Console.ReadLine());
            
            int width = (2 * input) - 1;
            int height = (2 * input) - 1;
            string[,] cube = new string[width, height];

            // print first cube
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i == 0 && j < input) || (i == (input - 1) && j < input))
                    {
                        cube[i, j] = ":";
                    }
                    else 
                    {
                        if ((j == 0 && i < input) || (j == (input - 1) && i < input))
                        {
                            cube[i, j] = ":";
                        }
                        else
                        {
                            cube[i, j] = " ";
                        }
                    }
                }
            }

            // print diagonals,bottom and right
            for (int i = input; i < width; i++)
            {
                cube[i, i - input + 1] = ":";
                cube[i - input + 1, i] = ":";
                cube[i, i] = ":";
                if (i == width - 1)
                {
                    for (int j = 0; j < input - 1; j++)
                    {
                        cube[i, j + input] = ":";
                        cube[j + input, i] = ":";
                    }
                }
            }

            // print verticals
            for (int i = 0; i < input - 2; i++)
            {
                for (int j = 0; j < input - 2; j++)
                {
                    cube[i + j + 2, input + i] = "|";
                    cube[input + i, i + j + 2] = "-";
                }
            }

            // print matrix
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(cube[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}