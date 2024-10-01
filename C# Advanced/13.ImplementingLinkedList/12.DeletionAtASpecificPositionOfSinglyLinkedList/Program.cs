using System.Xml;

namespace _12.DeletionAtASpecificPositionOfSinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<Node> linkedList = new List<Node>();
            Node head = new Node(inputNumbers[0]);
            linkedList.Add(head);

            int length = 0;
            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                length++;
                Node node = linkedList[i];
                node.Next = new Node(inputNumbers[i + 1]);
                linkedList.Add(node.Next);
            }

            int position = int.Parse(Console.ReadLine());

            if (position > length)
            {
                Console.WriteLine("Invalid position!");
                return;
            }
            length = 1;

            Node currentNode = head;
            Node previous = null;
            Node current = null;
            while (currentNode != null)
            {
                if (length == position)
                {
                    current = currentNode.Next;
                    currentNode = null;
                    previous.Next = current;
                    break;
                }
                else
                {
                    previous = currentNode;
                    currentNode = currentNode.Next;
                }
                length++;
            }

            while (head != null)
            {
                Console.Write(head.Value + "->");
                head = head.Next;
            }
        }
    }
}
