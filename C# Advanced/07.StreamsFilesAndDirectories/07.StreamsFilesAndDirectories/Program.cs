using static System.Net.Mime.MediaTypeNames;

namespace _01.OddLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Input.txt.txt"))
            {
                int count = 0;
                string text = reader.ReadLine();

                using (StreamWriter streamWriter = new StreamWriter("../../../Output.txt"))
                {
                    while (text != null)
                    {
                        if (count % 2 == 1)
                        {
                            streamWriter.WriteLine(text);
                            Console.WriteLine(text);
                        }
                        count++;
                        text = reader.ReadLine();
                    }
                }
            }
        }
    }
}
