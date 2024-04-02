namespace _09.Greater_of_TwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            string result = string.Empty;
            if (type == "int")
            {

                result = GetMax(int.Parse(firstValue), int.Parse(secondValue)).ToString();
            }
            else if (type == "string")
            {
                result = GetMax(firstValue, secondValue);
            }
            else if (type == "char")
            {
                result = GetMax(firstValue[0], secondValue[0]).ToString();
            }

            Console.WriteLine(result);

        }

        static int GetMax(int firstValue, int secondValue)
        {
            int result = 0;
            if (firstValue >= secondValue)
            {
                result = firstValue;
            }
            else
            {
                result = secondValue;
            }

            return result;
        }

        static string GetMax(string firstValue, string secondValue)
        {
            string result = string.Empty;

            if (string.Compare(firstValue, secondValue) == 0 || string.Compare(firstValue, secondValue) == 1)
            {
                result = firstValue;
            }
            else
            {
                result = secondValue;
            }

            return result;
        }

        static char GetMax(char firstValue, char secondValue)
        {
            char result = ' ';
            if (firstValue >= secondValue)
            {
                result = firstValue;
            }
            else
            {
                result = secondValue;
            }

            return result;
        }
    }
}