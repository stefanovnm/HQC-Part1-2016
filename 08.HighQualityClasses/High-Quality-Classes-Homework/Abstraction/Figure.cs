namespace Abstraction
{
    public abstract class Figure
    {
        protected Figure()
        {
        }

        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            string result = string.Format("{0}\nArea: {1:F2}; Perimeter: {2:F2}", this.GetType().Name, this.CalculateSurface(), this.CalculatePerimeter());
            return result;
        }
    }
}
