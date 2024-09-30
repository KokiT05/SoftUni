namespace _04.Traversal_InSinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<Node> nodes = new List<Node>();
            Node head = new Node(numbers[0]);
            nodes.Add(head);

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                nodes[i].Next = new Node(numbers[i + 1]);
                nodes.Add(nodes[i].Next);
            }

            PrintValue(nodes.First());
        }

        static void PrintValue(Node head)
        {
            Node currentNote = head;

            while (currentNote != null)
            {
                Console.WriteLine(currentNote.Value);
                currentNote = currentNote.Next;
            }
        }
    }
}
