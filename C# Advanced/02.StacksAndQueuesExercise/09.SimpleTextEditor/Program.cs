using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> textStack = new Stack<string>();
            //string currentText = string.Empty;

            StringBuilder currentText = new StringBuilder();
            int nLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < nLines; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string command = inputData[0];
                if (command == "1")
                {
                    string subString = inputData[1];
                    currentText.Append(subString);
                    textStack.Push(currentText.ToString());
                }
                else if (command == "2")
                {
                    string subString = inputData[1];
                    int count = int.Parse(subString);

                    if (count >= 0 && count <= currentText.Length)
                    {

                        currentText.Remove(currentText.Length - count, count);
                        textStack.Push(currentText.ToString());
                    }
                }
                else if (command == "3")
                {
                    string subString = inputData[1];
                    int index = int.Parse(subString) - 1;

                    string symbol = textStack.Peek();

                    if (index >= 0 && index <= symbol.Length)
                    {
                        Console.WriteLine(symbol[index]);
                    }
                }
                else if (command == "4")
                {
                    currentText.Clear();
                    if (textStack.Count > 1)
                    {
                        currentText.Append(textStack.Pop());
                    }
                    else
                    {
                        textStack.Pop();
                    }
                }
            }
        }
    }
}
