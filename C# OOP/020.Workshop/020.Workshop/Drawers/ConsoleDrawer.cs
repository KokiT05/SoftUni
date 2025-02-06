using _020.Workshop.Common;
using _020.Workshop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.Drawers
{
    public class ConsoleDrawer : IDrawer
    {
        public void DrawAtPosition(Position position, string toDraw)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine(toDraw);
        }
    }
}
