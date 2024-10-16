namespace _02.Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag;
            string[] collection = Console.ReadLine().Split().Skip(1).ToArray();
            ListyIterator<string> listyIterator = new ListyIterator<string>(collection);

            string input = Console.ReadLine();
            while (input != "END")
            {

                if (input == "Move")
                {
                    flag = listyIterator.Move();
                    Console.WriteLine(flag);
                }
                else if (input == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "HasNext")
                {
                    flag = listyIterator.HasNext();
                    Console.WriteLine(flag);
                }
                else if (input == "PrintAll")
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write($"{item} ");
                    }

                    Console.WriteLine(string.Join(" ", listyIterator));
                }

                input = Console.ReadLine();
            }
        }
    }
}
