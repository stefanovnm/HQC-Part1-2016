using System.Collections.Generic;

using _01.ClassChefInCSharp.Vegetables;

namespace _01.ClassChefInCSharp
{
    public class Bowl
    {
        public Bowl()
        {
            this.Ingredients = new List<Vegetable>();
        }

        public ICollection<Vegetable> Ingredients { get; set; }

        public void Add(Vegetable vegetable)
        {
            this.Ingredients.Add(vegetable);
        }
    }
}
