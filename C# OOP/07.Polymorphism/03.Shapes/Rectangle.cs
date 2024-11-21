using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _03.Shapes
{
    internal class Rectangle : Shape
    {
        private double height;
        private double width;
        private string drawResult;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get { return this.height; } private set { this.height = value; } }

        public double Width { get { return this.width; } private set { this.width = value; } }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return (this.Height * this.Width) * 2;
        }

        public override string Draw()
        {
            StringBuilder stringBuilder = new StringBuilder(this.drawResult);

            stringBuilder.Append(this.DrawLine(this.Width, '*', '*'));
            for (int i = 1; i < this.height - 1; ++i)
            {
                stringBuilder.Append(this.DrawLine(this.Width, '*', ' '));
            }
            stringBuilder.Append(this.DrawLine(this.Width, '*', '*'));

            this.drawResult = stringBuilder.ToString();
            return this.drawResult;
        }

        private string DrawLine(double width, char end, char mid)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(end);
            for (int i = 1; i < width - 1; ++i)
            {
                stringBuilder.Append(mid);
            }
            stringBuilder.AppendLine(end.ToString());

            this.drawResult = stringBuilder.ToString();
            return this.drawResult;
        }
    }
}
