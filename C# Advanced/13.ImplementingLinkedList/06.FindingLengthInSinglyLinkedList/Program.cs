namespace _06.FindingLengthInSinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int length = 0;
            List<Node> linkedList = new List<Node>();
            Node head = new Node(inputNumbers[0]);
            linkedList.Add(head);

            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                Node node = linkedList[i];
                node.Next = new Node(inputNumbers[i + 1]);
                linkedList.Add(node.Next);
            }

            Node currentNode = linkedList.First();
            while (currentNode != null)
            {
                length++;
                currentNode = currentNode.Next;
            }

            Console.WriteLine(length);
        }
    }
}
