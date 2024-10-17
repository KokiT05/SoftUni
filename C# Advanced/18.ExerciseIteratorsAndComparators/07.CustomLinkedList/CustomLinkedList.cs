using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CustomLinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public CustomLinkedList(Node<T> head)
        {
            this.Head = head;
        }
        public Node<T> Head { get; set; }

        public void Add(Node<T> node)
        {
            Node<T> currentNode = this.Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = node;
        }

        public void RemoveHead()
        {
            Node<T> node = this.Head;
            this.Head = node.Next;
        }

        public void RemoveLastNode()
        {
            Node<T> currentNode = this.Head;
            while (currentNode.Next.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = null;
        }

        public void PrintListValues()
        {
            Node<T> currentNode = this.Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.Head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
