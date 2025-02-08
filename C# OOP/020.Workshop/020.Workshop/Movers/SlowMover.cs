using _020.Workshop.Common;
using _020.Workshop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.Movers
{
    public class SlowMover : IMover
    {
        public void Move(IGameObject gameObject, Position position)
        {
            gameObject.Position.X += position.X;
            gameObject.Position.Y += position.Y;
        }
    }
}
