namespace _1.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int index = rnd.Next(0, words.Length);
                string currentWords = words[i];
                words[i] = words[index];
                words[index] = currentWords;
            }

            foreach (string word in words) 
            {
                Console.WriteLine(word);
            }
        }
    }
}