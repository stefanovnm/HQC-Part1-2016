using System;

using _01.ClassChefInCSharp.Vegetables;

namespace _01.ClassChefInCSharp
{
    public class Chef
    {
        public Chef()
        {
        }

        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bowl bowl = new Bowl();

            this.Peel(potato);
            this.Peel(carrot);
            bowl = this.GetBowl();

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);

            Console.WriteLine("Soup is ready!");
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.IsCutted = true;
        }

        private void Peel(Vegetable vegitable)
        {
            vegitable.IsPeeled = true;
        }

        private Potato GetPotato()
        {
            return new Potato();
        }
    }
}
