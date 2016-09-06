using System;

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileName.GetFileExtension("example"));
            Console.WriteLine(FileName.GetFileExtension("example.pdf"));
            Console.WriteLine(FileName.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileName.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine();

            Console.WriteLine("Distance in the 2D space = {0:f2}", Distance.Calculate2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Distance.Calculate3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine();

            Paralelipiped paralelipiped = new Paralelipiped(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", paralelipiped.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", paralelipiped.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", paralelipiped.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", paralelipiped.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", paralelipiped.CalcDiagonalYZ());
        }
    }
}
