namespace _01.CustomDoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedList softUniLinkedList = new SoftUniLinkedList();

            for (int i = 0; i < 10; i++)
            {
                softUniLinkedList.AddHead(new Node(i));
            }

            for (int i = 0; i < 10; i++)
            {
                softUniLinkedList.AddTail(new Node(i));
            }

            Console.WriteLine($"Romove Head: " + softUniLinkedList.RemoveHead().Value);
            Console.WriteLine();
            Console.WriteLine($"Romove Tail: " + softUniLinkedList.RemoveTail().Value);

            Console.WriteLine($"Foreach from head: ");
            softUniLinkedList.ForeachFromHead((node) =>
            {
                Console.WriteLine($"From action: {node.Value}");
            });

            Console.WriteLine($"Foreach from tail: ");
            softUniLinkedList.ForeachFromTail((node) =>
            {
                Console.WriteLine($"From action: {node.Value}");
            });
        }
    }
}
