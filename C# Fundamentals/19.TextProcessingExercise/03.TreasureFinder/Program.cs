using System;
using System.Diagnostics;

namespace _03.TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int index = 0;
            string decryptMessage = string.Empty;
            string resource = string.Empty;
            string coordinates = string.Empty;

            string input = Console.ReadLine();
            while (input != "find")
            {
                index = 0;
                decryptMessage = DecryptString(key, input);

                resource = Resource('&', decryptMessage, resource);
                coordinates = Coordinates('<', decryptMessage, coordinates);
                Console.WriteLine($"Found {resource} at {coordinates}");

                input = Console.ReadLine();
            }
        }

        static string DecryptString(int[] key, string text)
        {
            string decryptMessage = string.Empty;
            int index = 0;
            for (int i = 0; i < text.Length; i++)
            {
                decryptMessage += (char)(text[i] - key[index]);
                index++;
                if (index == key.Length)
                {
                    index = 0;
                }
            }

            return decryptMessage;
        }

        static string Resource(char sumbol, string decryptMessage, string resource)
        {
            resource = string.Empty;
            int indexOfSpecialSumbol = decryptMessage.IndexOf(sumbol);
            for (int i = indexOfSpecialSumbol + 1; i < decryptMessage.Length; i++)
            {
                if (decryptMessage[i] != '&')
                {
                    resource += decryptMessage[i];
                }
                else
                {
                    break;
                }
            }

            return resource;
        }

        static string Coordinates(char sumbol, string decryptMessage, string coordinates)
        {
            coordinates = string.Empty;

            int indexOfSpecialSumbol = decryptMessage.IndexOf(sumbol);

            for (int i = indexOfSpecialSumbol + 1; i < decryptMessage.Length; i++)
            {
                if (decryptMessage[i] != '>')
                {
                    coordinates += decryptMessage[i];
                }
                else
                {
                    break;
                }
            }

            return coordinates;
        }
    }
}