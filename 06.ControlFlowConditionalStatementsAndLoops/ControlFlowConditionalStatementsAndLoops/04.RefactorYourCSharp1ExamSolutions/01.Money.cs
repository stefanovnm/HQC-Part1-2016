using System;
using System.Threading;

namespace RefactorYourCSharp1ExamSolutions
{
    public class MoneyDescription
    {
        public static void Task1()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());

            double result = (double)n * (double)s / 400 * p;

            Console.WriteLine("{0:0.000}", result);
        }
    }
}
