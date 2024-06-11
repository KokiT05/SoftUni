namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int strength = 0;
            int amountOfStrength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength = int.Parse(input[i + 1].ToString());
                    amountOfStrength += strength;
                }

                if (input[i] != '>' && amountOfStrength > 0)
                {
                    input = input.Remove(i, 1);
                    amountOfStrength--;
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}