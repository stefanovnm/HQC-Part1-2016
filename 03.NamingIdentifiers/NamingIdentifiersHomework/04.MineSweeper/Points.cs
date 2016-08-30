namespace _04.MineSweeper
{
    public class Points
    {
        private string name;
        private int points;

        public Points()
        {
        }

        public Points(string name, int points)
        {
            this.Name = name;
            this.CurrentPoints = points;
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public int CurrentPoints
        {
            get { return points; }
            set { this.points = value; }
        }
    }
}
