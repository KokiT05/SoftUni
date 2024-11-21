using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}
