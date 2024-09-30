using System.Collections.Generic;

namespace _07.InsertionInSinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int headValue = int.Parse(Console.ReadLine());
            Node head = new Node(headValue);

            string[] input = Console.ReadLine().Split(' ');
            string command = input[0].ToLower();
            while (command != "end")
            {
                if (command == "add")
                {
                    int value = int.Parse(input[1]);
                    head = AddHead(value, head);
                    //AddHead(value, head);
                }
                else if (command == "print")
                {
                    PrintValue(head);
                }

                input = Console.ReadLine().Split(' ');
                command = input[0].ToLower();
            }

            Console.WriteLine($"Current head: {head.Value}");
        }

        static void PrintValue(Node head)
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                Console.Write(currentNode.Value + " ");
                currentNode = currentNode.Next;
            }
        }
        static Node AddHead(int value, Node head)
        {
            Node newHead = new Node(value);

            newHead.Next = head;
            head = newHead;

            return head;
        }
    }
}
