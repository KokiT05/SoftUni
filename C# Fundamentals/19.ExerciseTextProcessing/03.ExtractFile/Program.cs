namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] separators = { '.', '\\' };
            string[] input = Console.ReadLine().Split(separators);
            string fileExtension = input[input.Length - 1];
            string fileName = input[input.Length - 2];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}