using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CommandPatternLectureExample
{
    public class Componen : IComponent
    {
        private List<IComponent> children;


        public Componen(Position position)
        {
            this.children = new List<IComponent>();
            this.Position = position;
        }

        public Position Position { get; set; }

        public virtual void Add(IComponent component)
        {
            children.Add(component);
        }

        public virtual void Draw()
        {
            foreach (IComponent component in children)
            {
                component.Draw();
            }
        }

        public virtual void Move(Position position)
        {
            this.Position.X += position.X;
            this.Position.Y += position.Y;
            foreach (IComponent component in children)
            {
                component.Move(position);
            }
        }

        public virtual void Remove(IComponent component)
        {
            children.Remove(component);
        }
    }
}
