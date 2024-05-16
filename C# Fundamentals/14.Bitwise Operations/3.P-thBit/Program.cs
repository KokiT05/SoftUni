namespace _3.P_thBit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int duplicateNumber = number;

            int count = 0;
            while (duplicateNumber != 0)
            {
                duplicateNumber = duplicateNumber / 2;
                count++;
            }

            int[] binaryRepresentation = new int[count];

            count = 0;
            while (number != 0)
            {
                int digit = number % 2;
                number = number / 2;
                binaryRepresentation[count] = digit;
                count++;
            }
            ;
            if (position >= binaryRepresentation.Length)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(binaryRepresentation[position] & 1);
            }
        }
    }
}