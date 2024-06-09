namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string unnecessaryString = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.ToLower().IndexOf(unnecessaryString.ToLower()) != -1)
            {
                int indexOfString = text.ToLower().IndexOf(unnecessaryString.ToLower());
                text = text.Remove(indexOfString, unnecessaryString.Length);
            }

            Console.WriteLine(text);
        }
    }
}