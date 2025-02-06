using _020.Workshop.Common;
using _020.Workshop.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.GameObjects
{
    public class Enemy : IGameObject
    {
        private IDrawer drawer;
        public Enemy(IDrawer drawer)
        {
            this.drawer = drawer;
            Random random = new Random();
            this.Position = new Position(random.Next(0,20), random.Next(0,20));
        }
        public Position Position {get;}

        public void Draw()
        {
            drawer.DrawAtPosition(Position, "G");
        }
    }
}
