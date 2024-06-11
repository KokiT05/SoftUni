using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumString = Console.ReadLine();
            bigNumString = bigNumString.TrimStart(new char[] { '0' });
            char[] bigNum = bigNumString.ToCharArray();
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine("0");
                return;
            }
            List<string> newNum = new List<string>();

            int parse = 0;
            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                parse = (int.Parse(Convert.ToString(bigNum[i])) * number) + parse;
                newNum.Insert(0, (parse % 10).ToString());
                parse /= 10;
            }


            if (parse > 0)
                Console.WriteLine($"{parse}{string.Join("", newNum)}");
            else
                Console.WriteLine($"{string.Join("", newNum)}");

            //string bigNumber = Console.ReadLine();
            //int singleDigitChar = int.Parse(Console.ReadLine());
            //string result = MultiplyLargeNumber(bigNumber, singleDigitChar);
            //Console.WriteLine(result);
        }

        //static string MultiplyLargeNumber(string bigNumber, int singleDigitChar)
        //{
        //    if (singleDigitChar == '0' || bigNumber == "0")
        //        return "0";

        //    int singleDigit = singleDigitChar; // Превръщане на символа в число
        //    int carry = 0;
        //    StringBuilder result = new StringBuilder();

        //    // Обработване на всяка цифра от края към началото
        //    for (int i = bigNumber.Length - 1; i >= 0; i--)
        //    {
        //        int digit = bigNumber[i] - '0'; // Превръщане на символа в число
        //        int product = digit * singleDigit + carry;
        //        result.Insert(0, product % 10); // Добавяне на последната цифра на произведението
        //        carry = product / 10; // Обновяване на остатъка
        //    }

        //    // Добавяне на останалия остатък ако има такъв
        //    if (carry > 0)
        //        result.Insert(0, carry);

        //    return result.ToString();
        //}

    }
}