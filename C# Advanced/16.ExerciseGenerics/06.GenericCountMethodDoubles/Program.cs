namespace _06.GenericCountMethodDoubles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> list = new List<Box<double>>(n);
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(input);
                list.Add(box);
            }

            double element = double.Parse(Console.ReadLine());
            Box<double> comperableBox = new Box<double>(element);

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
