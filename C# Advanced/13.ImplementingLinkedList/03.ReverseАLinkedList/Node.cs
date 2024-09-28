using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReverseАLinkedList
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Next = null;
        }

        public int Value {  get; set; }

        public Node Next { get; set; }
    }
}
