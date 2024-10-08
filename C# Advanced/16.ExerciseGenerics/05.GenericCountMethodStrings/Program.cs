namespace _05.GenericCountMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> list = new List<Box<string>>(n);
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                list.Add(box);
            }

            string element = Console.ReadLine();
            Box<string> elementForComparer = new Box<string>(element);

            Console.WriteLine(elementForComparer.Comparer(list, element));

        }
    }
}
