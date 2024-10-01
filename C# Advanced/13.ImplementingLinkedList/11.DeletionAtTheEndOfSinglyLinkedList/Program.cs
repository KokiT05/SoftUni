namespace _11.DeletionAtTheEndOfSinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<Node> linkedList = new List<Node>();
            Node head = new Node(inputNumbers[0]);
            Node currentNode = head;
            linkedList.Add(head);

            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                Node node = linkedList[i];
                node.Next = new Node(inputNumbers[i + 1]);
                linkedList.Add(node.Next);
            }

            string command = Console.ReadLine();
            while (command != "end" && head != null)
            {
                if (command == "delete last")
                {
                    if (head.Next == null)
                    {
                        head = null;
                        break;
                    }

                    currentNode = head;
                    while (currentNode.Next.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }

                    currentNode.Next = null;
                }
                else if (command == "print list")
                {
                    currentNode = head;
                    while (currentNode != null)
                    {
                        Console.WriteLine(currentNode.Value);
                        currentNode = currentNode.Next;
                    }
                }

                command = Console.ReadLine();
            }

            while (head.Next != null)
            {
                head = head.Next;
            }

            Console.WriteLine($"Last element value: {head.Value}");
        }
    }
}
