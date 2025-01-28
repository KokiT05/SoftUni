using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CommandPatternLectureExample
{
    public interface IComponent
    {
        void Add(IComponent component);

        void Remove(IComponent component);

        void Draw();

        void Move(Position position);
    }
}
