namespace _02.FindMiddleOfTheLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hare and Tortoise Algorithm

            SystemLinkedList hareAndTortoiseAlgorithm = new SystemLinkedList();
            Node headOne = new Node(10);
            headOne.Next = new Node(20);
            headOne.Next.Next = new Node(30);
            headOne.Next.Next.Next = new Node(40);
            headOne.Next.Next.Next.Next = new Node(50);
            headOne.Next.Next.Next.Next.Next = new Node(60);

            Console.WriteLine(hareAndTortoiseAlgorithm.GetMiddleHareAndTortoise(headOne));

            // GeeksForGeeks solution
            //SystemLinkedList systemLinkedList = new SystemLinkedList();
            //Node headTwo = new Node(10);
            //headTwo.Next = new Node(20);
            //headTwo.Next.Next = new Node(30);
            //headTwo.Next.Next.Next = new Node(40);
            //headTwo.Next.Next.Next.Next = new Node(50);
            //head.Next.Next.Next.Next.Next = new Node(60);

            //Console.WriteLine(systemLinkedList.GetMiddle(headTwo));

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
