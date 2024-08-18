using static System.Net.Mime.MediaTypeNames;

namespace _02.LineNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("../../../Input.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("../../../Output.txt"))
                {
                    int count = 1;
                    string text = string.Empty;
                    while ((text = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"{count++}. {text}");
                    }
                }
            }
        }
    }
}
