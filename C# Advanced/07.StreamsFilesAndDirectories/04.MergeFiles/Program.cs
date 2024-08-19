namespace _04.MergeFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            using (StreamReader reader = new StreamReader("../../../Input1.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    numbers.Add(int.Parse(text));
                    text = reader.ReadLine();
                }
                reader.Close();
            }

            using (StreamReader reader = new StreamReader("../../../Input2.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    numbers.Add(int.Parse(text));
                    text = reader.ReadLine();
                }
                reader.Close();
            }

            numbers.Sort();
            using (StreamWriter streamWriter = new StreamWriter("../../../Output.txt"))
            {
                for (int number = 0; number < numbers.Count; number++)
                {
                    streamWriter.WriteLine(numbers[number]);
                }
                streamWriter.Close();
            }
        }
    }
}
