namespace _01.ClassChefInCSharp.Vegetables
{
    public abstract class Vegetable
    {
        public Vegetable()
        {
            this.IsPeeled = false;
            this.IsCutted = false;
        }

        public bool IsPeeled { get; set; }

        public bool IsCutted { get; set; }
    }
}
