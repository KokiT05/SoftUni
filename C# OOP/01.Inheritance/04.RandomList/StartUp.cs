﻿namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("1");
            randomList.Add("2");
            randomList.Add("3");
            randomList.Add("4");
            randomList.Add("5");

            randomList.RandomString();
            randomList.RandomString();

            foreach (string item in randomList)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
