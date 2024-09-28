using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReverseАLinkedList
{
    public class RecursionReverse
    {
        public Node Reverse(Node node)
        {
            if (node.Next == null)
            {
                return node;
            }

            node.Next = null;

            Node returnNode = Reverse(node.Next);
            returnNode.Next = node;


            return returnNode;
        }
    }
}
