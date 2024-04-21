namespace _7.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split('|').Reverse().ToArray();
            List<string> pieces = new List<string>(inputData.Length);
            List<string> result = new List<string>(pieces.Count);

            for (int i = 0; i < inputData.Length; i++)
            {
                string[] numbers = inputData[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < numbers.Length; j++)
                {
                    result.Add(numbers[j]);
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}