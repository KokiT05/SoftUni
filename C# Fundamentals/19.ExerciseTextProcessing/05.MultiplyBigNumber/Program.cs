using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int singleDigitChar = int.Parse(Console.ReadLine());
            string result = MultiplyLargeNumber(bigNumber, singleDigitChar);
            Console.WriteLine(result);
        }

        static string MultiplyLargeNumber(string bigNumber, int singleDigitChar)
        {
            if (singleDigitChar == '0' || bigNumber == "0")
                return "0";

            int singleDigit = singleDigitChar; // Превръщане на символа в число
            int carry = 0;
            StringBuilder result = new StringBuilder();

            // Обработване на всяка цифра от края към началото
            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int digit = bigNumber[i] - '0'; // Превръщане на символа в число
                int product = digit * singleDigit + carry;
                result.Insert(0, product % 10); // Добавяне на последната цифра на произведението
                carry = product / 10; // Обновяване на остатъка
            }

            // Добавяне на останалия остатък ако има такъв
            if (carry > 0)
                result.Insert(0, carry);

            return result.ToString();
        }

    }
}