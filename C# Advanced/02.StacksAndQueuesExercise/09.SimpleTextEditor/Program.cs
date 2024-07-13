using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();
            var stack = new Stack<string>();
            stack.Push(builder.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        builder.Append(input[1]);
                        stack.Push(builder.ToString());
                        break;
                    case 2:
                        int number = int.Parse(input[1]);
                        builder.Remove(builder.Length - number, number);
                        stack.Push(builder.ToString());
                        break;
                    case 3:
                        int index = int.Parse(input[1]);
                        Console.WriteLine(builder[index - 1]);
                        break;
                    case 4:
                        stack.Pop();
                        builder = new StringBuilder();
                        builder.Append(stack.Peek());
                        break;
                }
            }
            //Stack<string> textStack = new Stack<string>();
            ////string currentText = string.Empty;

            //StringBuilder currentText = new StringBuilder();
            //int nLines = int.Parse(Console.ReadLine());
            //for (int i = 0; i < nLines; i++)
            //{
            //    string[] inputData = Console.ReadLine().Split();
            //    string command = inputData[0];
            //    if (command == "1")
            //    {
            //        string subString = inputData[1];
            //        currentText.Append(subString);
            //        textStack.Push(currentText.ToString());
            //    }
            //    else if (command == "2")
            //    {
            //        string subString = inputData[1];
            //        int count = int.Parse(subString);

            //        if (count >= 0 && count <= currentText.Length)
            //        {

            //            currentText.Remove(currentText.Length - count, count);
            //            textStack.Push(currentText.ToString());
            //        }
            //    }
            //    else if (command == "3")
            //    {
            //        string subString = inputData[1];
            //        int index = int.Parse(subString) - 1;

            //        string symbol = string.Empty;
            //        if (textStack.Count > 0)
            //        {
            //            symbol = textStack.Peek();
            //        }

            //        if (index >= 0 && index <= symbol.Length)
            //        {
            //            Console.WriteLine(symbol[index]);
            //        }
            //    }
            //    else if (command == "4")
            //    {
            //        currentText.Clear();
            //        if (textStack.Count > 0)
            //        {
            //            textStack.Pop();
            //            currentText.Append(textStack.Peek());
            //        }
            //    }
            //}
        }
    }
}
