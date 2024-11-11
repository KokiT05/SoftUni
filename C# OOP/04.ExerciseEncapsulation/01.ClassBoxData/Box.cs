using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                this.ThrowIfInvalidSide(value, nameof(this.Length));

                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                this.ThrowIfInvalidSide(value, nameof(this.Width));

                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                this.ThrowIfInvalidSide(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double Volume()
        {
            double volumeResult = this.length * this.width * this.height;
            return volumeResult;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.length * this.height) + 
                                        (2 * this.width * this.height);
            return lateralSurfaceArea;
        }

        public double SurfaceArea()
        {
            double surfaceArea = (2 * this.length * this.width) + 
                                (2 * this.length * this.height) +
                                (2 * this.width * this.height);
            return surfaceArea;
        }

        private void ThrowIfInvalidSide(double value, string property)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{property} cannot be zero or negative.");
            }
        }
    }
}
