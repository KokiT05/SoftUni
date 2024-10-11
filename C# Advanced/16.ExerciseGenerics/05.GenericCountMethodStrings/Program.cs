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
            Box<string> comperableBox = new Box<string>(element);

            Console.WriteLine(GetGreaterThanCount(list, comperableBox));

        }

        public static int GetGreaterThanCount<T>(List<Box<T>> boxes, Box<T> element)
            where T : IComparable
        {
            int count = 0;

            foreach (Box<T> box in boxes)
            {
                int compare = box.Value.CompareTo(element.Value);

                if (compare > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
