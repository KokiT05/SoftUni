using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CommandPatternLectureExample
{
    public class Leaf : Componen
    {
        public Leaf(Position position) : base(position)
        {
        }

        public override void Add(IComponent component)
        {
        }

        public override void Remove(IComponent component)
        {
        }
    }
}
