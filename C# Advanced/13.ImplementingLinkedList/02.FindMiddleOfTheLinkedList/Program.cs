namespace _02.FindMiddleOfTheLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GeeksForGeeks solution
            SystemLinkedList systemLinkedList = new SystemLinkedList();
            Node head = new Node(10);
            head.Next = new Node(20);
            head.Next.Next = new Node(30);
            head.Next.Next.Next = new Node(40);
            head.Next.Next.Next.Next = new Node(50);
            //head.Next.Next.Next.Next.Next = new Node(60);

            Console.WriteLine(systemLinkedList.GetMiddle(head));

            // My solution to the task
            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //LinkedList<int> list = new LinkedList<int>();

            //// We can use the length of the array
            //int count = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    list.AddLast(numbers[i]);
            //    count++;
            //}

            //LinkedListNode<int> node = list.First;

            //int counter = 0;
            //int middleIndex = count / 2;
            //while (counter != middleIndex)
            //{
            //    node = node.Next;
            //    counter++;
            //}

            //Console.WriteLine(node.Value);
        }
    }
}
