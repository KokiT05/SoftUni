using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CommandPatternLectureExample.Components
{
    public class Rectangle : Componen
    {
        public Rectangle(Position position, int size) : base(position)
        {
            this.Size = size;
        }

        public int Size { get; set; }

        public override void Draw()
        {
            Console.SetCursorPosition(base.Position.X, base.Position.Y);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"@");
                }
                Console.SetCursorPosition(base.Position.X, base.Position.Y + i);
            }

            base.Draw();
        }
    }
}
