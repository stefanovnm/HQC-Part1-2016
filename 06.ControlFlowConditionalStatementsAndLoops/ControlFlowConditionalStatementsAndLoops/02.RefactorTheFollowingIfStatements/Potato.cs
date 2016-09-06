using System;

namespace _02.RefactorTheFollowingIfStatements
{
    public class Potato
    {
        public Potato()
        {
            this.HasBeenPeeled = false;
            this.IsRotten = false;
        }

        public bool HasBeenPeeled { get; set; }

        public bool IsRotten { get; set; }

        public void Cook()
        {
            Console.WriteLine("Potato has been cooked");
        }

        public void Peel()
        {
            this.HasBeenPeeled = true;
        }
    }
}
