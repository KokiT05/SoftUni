using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CustomDoublyLinkedList
{
    public class SoftUniLinkedListFastReverse
    {
        private int count;

        private bool reversed = false;

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void Reverse()
        {
            Node node = Head;
            Head = Tail;
            Tail = node;
            reversed = !reversed;
        }
        public void Foreach(Action<Node> action)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);

                if (reversed)
                {
                    currentNode = currentNode.Previous;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }


        public void AddTail(Node node)
        {
            count++;
            if (Tail == null)
            {
                Tail = node;
                Head = node;
                return;
            }

            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }
    }
}
