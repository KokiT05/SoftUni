namespace _06.ImplementingStringMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(IndexOfS(text, "ice"));
        }

        static int IndexOfS(string str, string value) 
        {
            if (str == null || value == null)
            {
                Console.WriteLine($"Null value!!!!");
            }

            int strLen = str.Length;
            int valueLen = str.Length;

            if (valueLen == 0)
            {
                return 0;
            }

            if (valueLen > strLen)
            {
                return -1;
            }

            for (int i = 0; i <= strLen - valueLen; i++)
            {
                int j = 0;
                for (; j < valueLen; j++)
                {
                    if (str[i + j] != value[j])
                    {
                        break;
                    }
                }

                if (j == valueLen)
                {
                    return i;
                }
            }

            return -1;
        }

        static string RemoveS(string str, int startIndex, int count) 
        {
            if (str == null)
            {
                Console.WriteLine($"The string is Null!");
            }

            if (startIndex < 0 || startIndex >= str.Length)
            {
                Console.WriteLine($"The startIndex is out of range");
            }

            if (count < 0 || startIndex + count >= str.Length)
            {
                Console.WriteLine($"The count is incorrect!");
            }

            return str.Substring(0, startIndex) + str.Substring(startIndex + count);
        }

        static string SubStringS(string str, int startIndex, int length) 
        {
            if (str == null)
            {
                Console.WriteLine($"The string is Null!");
            }

            if (startIndex < 0 || startIndex >= str.Length)
            {
                Console.WriteLine($"The startIndex is out of range");
            }

            if (length < 0 || startIndex + length >= str.Length)
            {
                Console.WriteLine($"The length is incorrect!");
            }

            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = str[startIndex + i];
            }

            return new string(result);
        }
    }
}