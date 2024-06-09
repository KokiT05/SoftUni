namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string unnecessaryString = Console.ReadLine();
            string text = Console.ReadLine();

            IndexOfString(unnecessaryString, text);

            //while (text.ToLower().IndexOf(unnecessaryString.ToLower()) != -1)
            //{
            //    int indexOfString = text.ToLower().IndexOf(unnecessaryString.ToLower());
            //    text = text.Remove(indexOfString, unnecessaryString.Length);
            //}

            //Console.WriteLine(text);
        }

        static int IndexOfString(string key, string text)
        {
            int[] indexes = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                indexes[i] = -1;
            }

            int arrayIndex = 0;
            int index = -1;
            int indexOfKey = 0;
            string newString = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = indexOfKey; j < key.Length; j++)
                {
                    if (text[i] == key[j])
                    {

                        indexOfKey = j + 1;
                        indexes[arrayIndex] = i;
                        arrayIndex++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                if (indexOfKey == key.Length)
                {
                    for (int j = 0; j < text.Length; j++)
                    {
                        if (indexes.Contains(j) == false)
                        {
                            newString += text[j];
                        }
                    }

                    arrayIndex = 0;
                    index = -1;
                    indexOfKey = 0;
                }
                else
                {
                    for (int j = 0; j < text.Length; j++)
                    {
                        indexes[i] = -1;
                    }
                }
            }

            Console.WriteLine(newString);
            return index;
        }
    }
}