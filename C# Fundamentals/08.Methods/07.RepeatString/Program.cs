using System.Text;

namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string result = RepeatStr(text, n);
            Console.WriteLine(result);
        }

        static string RepeatStr(string text, int count)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append(text);
            }

            return stringBuilder.ToString();
        }
    }
}