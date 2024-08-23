namespace _01.EvenLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] sumbols = { '-', ',', '.', '!', '?' };

            using (StreamReader streamReader = new StreamReader("../../../text.txt"))
            {
                int count = 0;
                string textFromFile = streamReader.ReadLine();
                while (textFromFile != null)
                {
                    if (count % 2 == 0)
                    {
                        textFromFile = ReplaceSumbols(sumbols, textFromFile);
                        textFromFile = ReverseString(textFromFile);
                        Console.WriteLine(textFromFile);
                    }
                    count++;
                    textFromFile = streamReader.ReadLine();
                }
            }
        }

        static string ReplaceSumbols(char[] chars, string text)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                text = text.Replace(chars[i], '@');
            }

            return text;
        }

        static string ReverseString(string text)
        {
            string[] stringArray = text.Split();
            string reverseString = string.Empty;

            for (int i = stringArray.Length - 1; i >= 0; i--)
            {
                reverseString += stringArray[i] + " ";
            }
            reverseString = reverseString.TrimEnd();
            return reverseString;
        }
    }
}
