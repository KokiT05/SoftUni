namespace _15.Generics
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> intBox = new Box<int>();
            intBox.Add(9);
            intBox.Add(8);
            intBox.Add(7);
            Console.WriteLine(intBox.Remove());
            intBox.Add(4);
            intBox.Add(5);
            Console.WriteLine(intBox.Remove());

            for (int i = 0; 0 < intBox.Count; i++)
            {
                Console.Write($"{intBox.Remove()} ");
            }
        }
    }
}
