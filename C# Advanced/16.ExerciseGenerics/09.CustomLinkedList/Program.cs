namespace _09.CustomLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> head = new Node<int>(321);
            CustomLinkedList<int> linkedList = new CustomLinkedList<int>(head);

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "add")
                {
                    int value = int.Parse(Console.ReadLine());
                    Node<int> node = new Node<int>(value);
                    linkedList.Add(node);
                }
                input = Console.ReadLine();
            }

            linkedList.PrintListValues();

            //linkedList.RemoveHead();
            linkedList.RemoveLastNode();

            Console.WriteLine();
            linkedList.PrintListValues();
            
            Console.WriteLine($"Head: {linkedList.Head.Value}");
        }
    }
}
