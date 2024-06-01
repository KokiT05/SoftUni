using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _010.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> 
                languageUserPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] cmdArg = input.Split('-');
                string userName = cmdArg[0];
                string operation = cmdArg[1];

                if (operation != "banned")
                {
                    int userPoints = int.Parse(cmdArg[2]);
                    if (languageUserPoints.ContainsKey(operation) == false)
                    {
                        languageUserPoints.Add(operation,
                            new Dictionary<string, int> { { userName, userPoints } });
                        languageSubmissions.Add(operation, 1);
                    }
                    else
                    {
                        if (languageUserPoints[operation].ContainsKey(userName) == false)
                        {
                            languageUserPoints[operation].Add(userName, userPoints);
                            languageSubmissions[operation] += 1;
                        }
                        else
                        {
                            languageSubmissions[operation] += 1;
                            if (languageUserPoints[operation][userName] < userPoints)
                            {
                                languageUserPoints[operation][userName] = userPoints;
                            }
                        }
                    }
                }
                else if (operation == "banned")
                {
                    foreach (var item in languageUserPoints.Keys)
                    {
                        if (languageUserPoints[item].ContainsKey(userName))
                        {
                            languageUserPoints[item].Remove(userName);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach (var item in languageUserPoints.Keys)
            {
                foreach (string username in languageUserPoints[item].Keys)
                {
                    if (keyValuePairs.ContainsKey(username) == false)
                    {
                        keyValuePairs.Add(username, languageUserPoints[item][username]);
                    }
                }
            }

            keyValuePairs = keyValuePairs.OrderByDescending(v => v.Value).ThenBy(k => k.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"Results:");
            foreach (var item in keyValuePairs.Keys)
            {
                Console.WriteLine($"{item} | {keyValuePairs[item]}");
            }
            Console.WriteLine($"Submissions:");
            foreach (var item in languageSubmissions.OrderByDescending(v => v.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}