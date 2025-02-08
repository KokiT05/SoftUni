using _020.Workshop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.Contracts
{
    public interface IDrawer
    {
        void DrawAtPosition(Position position, string toDraw);
    }
}
