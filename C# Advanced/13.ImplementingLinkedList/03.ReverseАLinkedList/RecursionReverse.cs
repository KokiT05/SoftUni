using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReverseАLinkedList
{
    public class RecursionReverse
    {
        public Node Reverse(Node head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            Node rest = Reverse(head.Next);

            head.Next.Next = head;

            head.Next = null;

            return rest;
        }
    }
}
