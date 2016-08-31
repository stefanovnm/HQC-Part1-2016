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

        // can be done with automatic properties if no validation is done...
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int CurrentPoints
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
