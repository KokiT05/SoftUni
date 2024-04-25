using System.Text;

namespace _03.TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> encryptedMessage = Console.ReadLine().ToList();
            StringBuilder decrypted = new StringBuilder();

            List<int> numberList = new List<int>();
            for (int i = 0; i < encryptedMessage.Count; i++)
            {
                char symbol = encryptedMessage[i];
                if (char.IsDigit(symbol))
                {
                    int number = int.Parse(symbol.ToString());
                    numberList.Add((number));
                    encryptedMessage.Remove(symbol);
                    i--;
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numberList[i]);
                }
                else
                {
                    skipList.Add(numberList[i]);
                }
            }

            int indexForSkip = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(encryptedMessage
                                                    .Select(c => c.ToString())
                                                    .ToList());

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();

                decrypted.Append(string.Join("", temp));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(decrypted.ToString());
        }
    }
}