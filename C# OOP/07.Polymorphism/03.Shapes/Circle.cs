using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Shapes
{
    public class Circle : Shape
    {
        private double radius;
        private string drawResult;

        public Circle(double radius)
        {
            this.Radius = radius;
            this.drawResult = string.Empty;
        }

        public double Radius { get { return this.radius; } private set { this.radius = value; } }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            StringBuilder stringBuilder = new StringBuilder();

            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        stringBuilder.Append("*");
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                    }
                }
                stringBuilder.Append(Environment.NewLine);
            }

            this.drawResult = stringBuilder.ToString();
            return this.drawResult;
        }
    }
}
