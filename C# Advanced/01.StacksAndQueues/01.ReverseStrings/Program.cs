namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string inputText = Console.ReadLine();
            //Stack<char> stack = new Stack<char>(inputText);

            //foreach (char c in stack)
            //{
            //    Console.Write(c);
            //}

            string inputText = Console.ReadLine();

            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < inputText.Length; i++)
            {
                stack.Push(inputText[i].ToString());
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
