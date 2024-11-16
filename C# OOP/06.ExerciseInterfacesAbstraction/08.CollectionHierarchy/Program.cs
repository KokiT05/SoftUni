namespace _08.CollectionHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            string[] input = Console.ReadLine().Split();
            int removeCount = int.Parse(Console.ReadLine());

            PrintAddIndex(addCollection, input);
            Console.WriteLine();
            PrintAddIndex(addRemoveCollection, input);
            Console.WriteLine();
            PrintAddIndex(myList, input);
            Console.WriteLine();

            PrintRemoveResult(addRemoveCollection, removeCount);
            Console.WriteLine();
            PrintRemoveResult(myList, removeCount);

        }

        public static void PrintAddIndex(IAddCollection<string> collection, string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(collection.Add(input[i]) + " ");
            }
        }

        public static void PrintRemoveResult(IAddRemoveCollection<string> collection,
                                            int count)
        {
            for(int i = 0;i < count; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
        }
    }
}
