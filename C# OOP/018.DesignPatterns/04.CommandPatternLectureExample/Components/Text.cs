using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CommandPatternLectureExample.Components
{
    public class Text : Leaf
    {

        public Text(Position position, string text) : base(position)
        {
            this.Message = text;
        }

        public string Message {  get; set; }

        public override void Draw()
        {
            Console.SetCursorPosition(base.Position.X, base.Position.Y);
            Console.WriteLine(Message);
        }
    }
}
