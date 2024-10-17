namespace _07.CustomLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> head = new Node<int>(1);
            CustomLinkedList<int> numbers = new CustomLinkedList<int>(head);
            numbers.Add(new Node<int>(2));
            numbers.Add(new Node<int>(3));
            numbers.Add(new Node<int>(4));
            numbers.Add(new Node<int>(5));
            numbers.Add(new Node<int>(6));
            numbers.Add(new Node<int>(7));

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
