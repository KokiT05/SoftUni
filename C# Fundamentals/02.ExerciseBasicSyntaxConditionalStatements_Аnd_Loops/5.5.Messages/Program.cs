using System;

namespace _5._5.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSame = true;

            string code = string.Empty;

            int length = 0;
            int mainDigit = 0;
            int offset = 0;
            int letterIndex = 0;

            string message = string.Empty;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                code = Console.ReadLine();

                length = code.Length;

                mainDigit = int.Parse(code[0].ToString());

                for (int j = 0; j < code.Length; j++)
                {
                    if (mainDigit != int.Parse(code[j].ToString()))
                    {
                        isSame = false;
                    }
                }

                offset = (mainDigit - 2) * 3;

                if (mainDigit == 0 && isSame)
                {
                    message += " ";
                }
                else if (mainDigit != 1 && isSame)
                {

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset += 1;
                    }

                    letterIndex = (offset + length - 1);

                    switch (letterIndex)
                    {
                        case 0:
                            message += "a";
                            break;
                        case 1:
                            message += "b";
                            break;
                        case 2:
                            message += "c";
                            break;
                        case 3:
                            message += "d";
                            break;
                        case 4:
                            message += "e";
                            break;
                        case 5:
                            message += "f";
                            break;
                        case 6:
                            message += "g";
                            break;
                        case 7:
                            message += "h";
                            break;
                        case 8:
                            message += "i";
                            break;
                        case 9:
                            message += "j";
                            break;
                        case 10:
                            message += "k";
                            break;
                        case 11:
                            message += "l";
                            break;
                        case 12:
                            message += "m";
                            break;
                        case 13:
                            message += "n";
                            break;
                        case 14:
                            message += "o";
                            break;
                        case 15:
                            message += "p";
                            break;
                        case 16:
                            message += "q";
                            break;
                        case 17:
                            message += "r";
                            break;
                        case 18:
                            message += "s";
                            break;
                        case 19:
                            message += "t";
                            break;
                        case 20:
                            message += "y";
                            break;
                        case 21:
                            message += "v";
                            break;
                        case 22:
                            message += "w";
                            break;
                        case 23:
                            message += "x";
                            break;
                        case 24:
                            message += "y";
                            break;
                        case 25:
                            message += "z";
                            break;
                    }
                }
            }

            Console.WriteLine(message);
        }
    }
}
