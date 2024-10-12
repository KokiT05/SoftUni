namespace _09.CustomLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<string> head = new Node<string>("AAA");
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(head);

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "add")
                {
                    string value = Console.ReadLine();
                    Node<string> node = new Node<string>(value);
                    linkedList.Add(node);
                }
                input = Console.ReadLine();
            }

            linkedList.PrintListValues();

            linkedList.RemoveHead();
            linkedList.RemoveLastNode();

            Console.WriteLine();
            linkedList.PrintListValues();
            
            Console.WriteLine($"Head: {linkedList.Head.Value}");
        }
    }
}
