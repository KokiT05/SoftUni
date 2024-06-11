namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            int symbolValue = 0;
            string encryptText = string.Empty;
            for (int i = 0; i < inputText.Length; i++)
            {
                //symbolValue = Convert.ToInt32(inputText[i]);
                symbolValue = inputText[i] + 3;
                encryptText = encryptText + (char)symbolValue;
            }

            Console.WriteLine(encryptText);
        }
    }
}