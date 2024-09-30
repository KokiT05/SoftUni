namespace _05.SearchingInSinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(n => int.Parse(n))
                                .ToArray();
            int target = int.Parse(Console.ReadLine());

            List<Node> linkedList = new List<Node>();

            Node head;
            if (inputNumbers.Length == 0)
            {
                head = new Node(0);
            }
            else
            {
                head = new Node(inputNumbers[0]);
            }

            linkedList.Add(head);

            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                Node node = linkedList[i];
                node.Next = new Node(inputNumbers[i + 1]);
                linkedList.Add(node.Next);
            }

            bool isFound = false;

            Node currentNode = linkedList.First();
            while (currentNode != null)
            {
                if (target == currentNode.Value)
                {
                    isFound = true;
                    break;
                }

                currentNode = currentNode.Next;
            }

            Console.WriteLine(isFound);
        }
    }
}
