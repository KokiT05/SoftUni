namespace _10.DeletionInSinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<Node> linkedList = new List<Node>();
            Node head = new Node(inputNumbers[0]);
            linkedList.Add(head);

            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                Node node = linkedList[i];
                node.Next = new Node(inputNumbers[i + 1]);
                linkedList.Add(node.Next);
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "delete")
                {
                    Node newHead = head.Next;
                    head = newHead;
                }
                else if (command == "print")
                {
                    Node currentNode = head;
                    while (currentNode != null)
                    {
                        Console.Write(currentNode.Value + "->");
                        currentNode = currentNode.Next;
                    }
                    Console.WriteLine("null");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Head current value: {head.Value}");
        }

        static Node DeleteHead(Node head)
        {
            if (head.Next == null)
            {
                return  null;
            }

            head = head.Next;

            return head;
        }
    }
}
