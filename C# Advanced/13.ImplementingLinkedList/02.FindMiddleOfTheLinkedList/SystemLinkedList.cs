using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FindMiddleOfTheLinkedList
{
    public class SystemLinkedList
    {
        public int GetLength(Node node)
        {
            int length = 0;

            while (node != null)
            {
                node = node.Next;
                length++;
            }

            return length;
        }

        public int GetMiddle(Node node)
        {
            int length = GetLength(node);

            int midIndex = length / 2;
            while (midIndex > 0)
            {
                node = node.Next;
                midIndex--;
            }

            return node.Value;
        }
    }
}
