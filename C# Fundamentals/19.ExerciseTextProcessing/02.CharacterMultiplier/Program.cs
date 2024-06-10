namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            string firstInput = input[0];
            string secondInput = input[1];

            int result = 0;

            if (firstInput.Length == secondInput.Length)
            {
                for (int i = 0; i < firstInput.Length; i++)
                {
                    result += (byte)firstInput[i] * (byte)secondInput[i];
                }
            }
            else if(firstInput.Length < secondInput.Length)
            {
                for (int i = 0; i < firstInput.Length; i++)
                {
                    result += firstInput[i] * secondInput[i];
                }

                for (int i = firstInput.Length; i < secondInput.Length; i++)
                {
                    result += secondInput[i];
                }
            }
            else
            {
                for (int i = 0; i < secondInput.Length; i++)
                {
                    result += (byte)firstInput[i] * (byte)secondInput[i];
                }

                for (int i = secondInput.Length; i < firstInput.Length; i++)
                {
                    result += (byte)firstInput[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}