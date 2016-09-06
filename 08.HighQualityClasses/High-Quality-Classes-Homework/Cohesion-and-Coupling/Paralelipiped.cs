using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    public class Paralelipiped
    {
        private double width;
        private double height;
        private double depth;

        public Paralelipiped()
        {
        }

        public Paralelipiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.ValidateLength(value, "Width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.ValidateLength(value, "Height");
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                this.ValidateLength(value, "Depth");
                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = Distance.Calculate3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = Distance.Calculate2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = Distance.Calculate2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = Distance.Calculate2D(0, 0, this.Height, this.Depth);
            return distance;
        }

        private void ValidateLength(double length, string type)
        {
            if (length <= 0)
            {
                string error = type + "should not be negative or zero";
                throw new ArgumentOutOfRangeException(error);
            }
        }
    }
}
