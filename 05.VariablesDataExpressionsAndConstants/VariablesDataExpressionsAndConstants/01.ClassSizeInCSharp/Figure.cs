using System;

namespace VariablesDataExpressionsAndConstants
{
    public class Figure
    {
        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public static Figure GetRotatedFigure(Figure figure, double angleOfRotation)
        {
            double rotatedWidth = (Math.Abs(Math.Cos(angleOfRotation)) * figure.Width) +
                (Math.Abs(Math.Sin(angleOfRotation)) * figure.Height);

            double rotatedHeight = (Math.Abs(Math.Sin(angleOfRotation)) * figure.Width) +
                (Math.Abs(Math.Cos(angleOfRotation)) * figure.Height);

            Figure rotatedFigure = new Figure(rotatedWidth, rotatedHeight);

            return rotatedFigure;
        }
    }
}