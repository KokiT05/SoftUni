namespace _09.InsertionAtASpecificPositionOfTheSinglyLinkedList
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

            int position = int.Parse(Console.ReadLine());
            int nodeValue = int.Parse(Console.ReadLine());
            Node newNode = new Node(nodeValue);

            bool isCorrentPosition = false;
            int length = 1;
            Node currentNode = head;
            Node previous = null;
            Node next = null;
            while (currentNode != null)
            {
                if (length == position)
                {
                    next = currentNode.Next;
                    currentNode.Next = newNode;
                    newNode.Next = next;
                    isCorrentPosition = true;
                    break;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
                length++;
            }

            if (!isCorrentPosition)
            {
                Console.WriteLine("Not found this position");
            }

            while (head != null)
            {
                Console.Write(head.Value + "->");
                head = head.Next;
            }
            Console.WriteLine("null");
        }
    }
}
