namespace _01.CountCharsIn_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ');

            Dictionary<char, int> charactersCount = new Dictionary<char, int>();

            foreach (string s in text)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (charactersCount.ContainsKey(s[i]))
                    {
                        charactersCount[s[i]]++;
                    }
                    else
                    {
                        charactersCount.Add(s[i], 1);
                    }
                }
            }

            foreach (KeyValuePair<char, int> character in charactersCount)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}