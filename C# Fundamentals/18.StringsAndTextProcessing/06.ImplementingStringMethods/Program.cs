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
    }
}