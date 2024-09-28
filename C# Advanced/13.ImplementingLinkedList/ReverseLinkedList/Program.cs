using _01.CustomDoublyLinkedList;

namespace ReverseLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedListFastReverse reverseLinkedList = new SoftUniLinkedListFastReverse();

            for (int i = 0; i < 10; i++)
            {
                reverseLinkedList.AddTail(new Node(i));
            }

            reverseLinkedList.Reverse();
            //reverseLinkedList.Reverse();

            reverseLinkedList.Foreach(node =>
            {
                Console.WriteLine(node.Value);
            });
        }
    }
}
