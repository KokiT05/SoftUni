using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.ExerciseGenerics
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }
    }
}
