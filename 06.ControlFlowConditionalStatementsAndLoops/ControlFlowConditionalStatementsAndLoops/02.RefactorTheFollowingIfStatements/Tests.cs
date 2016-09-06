using System;

namespace _02.RefactorTheFollowingIfStatements
{
    public class Tests
    {
        private const int MaxX = 10;
        private const int MaxY = 10;
        private const int MinX = 0;
        private const int MinY = 0;

        public static void Main()
        {
            Potato potato = new Potato();
            
            if (potato != null)
            { 
                potato.Peel();

                if (potato.HasBeenPeeled && !potato.IsRotten)
                {
                    potato.Cook();
                }
            }
                
            // second part of the task
            int x = 3;
            int y = 5;
            bool shouldVisitCell = true;

            if ((x >= MinX) && (x <= MaxX) && 
                (y <= MaxX) && (y >= MinX) && shouldVisitCell)
            {
                VisitCell(x, y);
            }
        }

        public static void VisitCell(int x, int y)
        {
            Console.WriteLine("Cell [{0},{1}] is visited", x, y);
        }
    }
}