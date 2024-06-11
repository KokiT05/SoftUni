namespace _04.MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morseCode = Console.ReadLine().Split(' ');
            string[] morceAlphabet = "·- -··· -·-· -·· · ··-· --· ···· ·· ·--- -·- ·-·· -- -· --- ·--· --·- ·-· ··· - ··- ···- ·-- -··- -·-- --··".Replace('·', '.').Split(' ');
            string[] alphabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z".Split(' ');

            string message = string.Empty;
            foreach (string code in morseCode)
            {
                int indexOfCode = Array.IndexOf(morceAlphabet, code);
                if (indexOfCode != - 1)
                {
                    message += alphabet[indexOfCode];
                }
                else if (code == "|")
                {
                    message += " ";
                }
            }

            Console.WriteLine(message);
        }
    }
}