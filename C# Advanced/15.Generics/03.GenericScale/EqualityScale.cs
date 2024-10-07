using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GenericScale
{
    public class EqualityScale<T>
    {
        private T left { get; set; }
        private T right { get; set; }

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }
        
        public bool AreEqual()
        {
            bool isEquals = left.Equals(right);
            return isEquals;
        }
    }
}
