namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (TopNumber(i.ToString()))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool TopNumber(string number)
        {
            bool isOddNumber = false;
            int sumOfDigits = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (int.Parse(number[i].ToString()) % 2 != 0)
                {
                    isOddNumber = true;
                }
                sumOfDigits += int.Parse(number[i].ToString());
            }

            if (sumOfDigits % 8 == 0 && isOddNumber)
            {
                return true;
            }

            return false;
        }
    }
}