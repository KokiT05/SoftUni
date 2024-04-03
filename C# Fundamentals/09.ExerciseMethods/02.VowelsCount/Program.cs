namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int countOfVowels = StringVowelsCount(text);
            Console.WriteLine(countOfVowels);
        }

        static int StringVowelsCount(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case 'a':
                        count++;
                        break;
                    case 'e':
                        count++;
                        break;
                    case 'i':
                        count++;
                        break;
                    case 'o':
                        count++;
                        break;
                    case 'u':
                        count++;
                        break;
                    case 'A':
                        count++;
                        break;
                    case 'E':
                        count++;
                        break;
                    case 'I':
                        count++;
                        break;
                    case 'O':
                        count++;
                        break;
                    case 'U':
                        count++;
                        break;
                }
            }

            return count;
        }
    }
}