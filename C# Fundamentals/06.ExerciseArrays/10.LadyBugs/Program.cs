using System;
using System.Security.Cryptography;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfFiled = int.Parse(Console.ReadLine());
            string[] filed = new string[sizeOfFiled];
            for (int i = 0; i < sizeOfFiled; i++)
            {
                filed[i] = "0";
            }

            string indexes = Console.ReadLine();
            indexes = indexes.Replace(" ", "");
            for (int i = 0; i < indexes.Length; i++)
            {
                int currentIndex = int.Parse(indexes[i].ToString());

                if (currentIndex >= 0 && currentIndex < filed.Length)
                {
                    filed[currentIndex] = "1";
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] parstOfCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int ladybugIndex = int.Parse(parstOfCommand[0]);
                string diretion = parstOfCommand[1];
                int flyLength = int.Parse(parstOfCommand[2]);

                bool inRange = ladybugIndex >= 0 && ladybugIndex < filed.Length;
                bool hasLadybug = false;
                if (inRange)
                {
                    hasLadybug = filed[ladybugIndex] == "1";
                }

                if (!inRange && !hasLadybug)
                {
                    continue;
                }

                if (diretion == "right")
                {
                    int sumOfMove = -1;
                    if (ladybugIndex + flyLength >= filed.Length)
                    {
                        filed[ladybugIndex] = "0";
                    }
                    else
                    {
                        if (filed[ladybugIndex + flyLength] == "1")
                        {
                            sumOfMove = flyLength;
                            filed[ladybugIndex] = "0";
                            for (int i = ladybugIndex; i < filed.Length; i++)
                            {
                                if (ladybugIndex + flyLength < filed.Length &&
                                    filed[ladybugIndex + flyLength] == "1")
                                {
                                    sumOfMove = sumOfMove + flyLength;
                                    ladybugIndex = ladybugIndex + flyLength;
                                }
                                else if (ladybugIndex + flyLength < filed.Length
                                    && filed[ladybugIndex + flyLength] == "1")
                                {
                                    filed[ladybugIndex + flyLength] = "0";
                                }
                            }
                        }
                        else
                        {
                            filed[ladybugIndex] = "0";
                            filed[ladybugIndex + flyLength] = "1";
                        }
                    }

                    if (sumOfMove < filed.Length && sumOfMove >= 0)
                    {
                        filed[sumOfMove] = "1";
                    }
                }
                else if (diretion == "left") 
                {
                    int sumOfMove = -1;
                    if (ladybugIndex - flyLength < 0)
                    {
                        filed[ladybugIndex] = "0";
                    }
                    else
                    {
                        if (filed[ladybugIndex - flyLength] == "1")
                        {
                            sumOfMove = flyLength;
                            filed[ladybugIndex] = "0";
                            for (int i = ladybugIndex; i >= 0; i++)
                            {
                                if (ladybugIndex - flyLength >= 0 &&
                                    filed[ladybugIndex - flyLength] == "1")
                                {
                                    sumOfMove = sumOfMove - flyLength;
                                    ladybugIndex = ladybugIndex - flyLength;
                                }
                                else if (ladybugIndex - flyLength >= 0
                                    && filed[ladybugIndex - flyLength] == "1")
                                {
                                    filed[ladybugIndex - flyLength] = "0";
                                }
                            }
                        }
                        else
                        {
                            filed[ladybugIndex] = "0";
                            filed[ladybugIndex - flyLength] = "1";
                        }
                    }

                    if (sumOfMove >= 0 && sumOfMove < filed.Length)
                    {
                        filed[sumOfMove] = "1";
                    }
                }
            }

            Console.WriteLine(string.Join(" ", filed));
        }
    }
}
