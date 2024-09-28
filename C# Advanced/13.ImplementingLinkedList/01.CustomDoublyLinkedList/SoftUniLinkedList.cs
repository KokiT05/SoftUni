using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CustomDoublyLinkedList
{
    public class SoftUniLinkedList
    {
        private int count;

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int[] ToArray()
        {
            int[] array = new int[count];

            int index = 0;
            ForeachFromHead((node) =>
            {
                array[index] = node.Value;
                index++;
            });

            return array;
        }

        public void ForeachFromTail(Action<Node> action)
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }

        public void ForeachFromHead(Action<Node> action)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public void AddHead(Node node)
        {
            count++;
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head.Previous = node;
            Head = node;

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

        public Node RemoveHead()
        {
            if (Head == null)
            {
                return null;
            }

            count--;
            Node head = Head;

            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return head;
        }

        public Node RemoveTail()
        {
            if (Tail == null)
            {
                return null;
            }

            count--;
            Node tail = Tail;

            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Tail = null;
                Head = null;
            }

            return tail;
        }
    }
}
