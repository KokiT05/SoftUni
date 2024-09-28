using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReverseАLinkedList
{
    public class SystemLinkedList
    {
        public Node ReverseLinkedList(Node node)
        {
            //if (node == null && node.Next == null)
            //{
            //    return;
            //}

            Node currentNode = node;
            Node nextNode = null;
            Node previousNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.Next;

                currentNode.Next = previousNode;

                previousNode = currentNode;
                currentNode = nextNode;
            }

            return previousNode;
        }

        public void PrintLinkedList(Node head)
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}
