namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackString = new StackOfStrings();
            Console.WriteLine(stackString.IsEmpty());

            stackString.AddRange("1", "2", "3", "4", "5");

            foreach (string item in stackString)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(stackString.IsEmpty());
        }
    }
}
