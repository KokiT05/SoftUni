namespace _03.ReverseАLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Recursion Method

            Node head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(4);

            RecursionReverse systemLinkedList = new RecursionReverse();

            systemLinkedList.Reverse(head);
            Console.WriteLine();

            Node reverseLinkedList = systemLinkedList.Reverse(head);

            // Interative Method
            //Node head = new Node(1);
            //head.Next = new Node(2);
            //head.Next.Next = new Node(3);
            //head.Next.Next.Next = new Node(4);

            //SystemLinkedList systemLinkedList = new SystemLinkedList();

            //systemLinkedList.PrintLinkedList(head);
            //Console.WriteLine();

            //Node reverseLinkedList = systemLinkedList.ReverseLinkedList(head);

            //systemLinkedList.PrintLinkedList(reverseLinkedList);
        }
    }
}
