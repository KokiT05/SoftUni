namespace _08.InsertionAtTheEndOfSinglyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            int headValue = int.Parse(Console.ReadLine());
            Node head = new Node(headValue);

            string[] input = Console.ReadLine().Split();
            string command = input[0];

            while (command != "end")
            {
                if (command == "add")
                {
                    int value = int.Parse(input[1]);
                    Node node = new Node(value);
                    AddLastNode(head, node);
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

                input = Console.ReadLine().Split();
                command = input[0];
            }

            Console.WriteLine($"Current head: {head.Value}");
        }

        static void AddLastNode(Node head,Node node)
        {

            while (head.Next != null)
            {
                head = head.Next;
            }

            head.Next = node;
        }
    }
}
