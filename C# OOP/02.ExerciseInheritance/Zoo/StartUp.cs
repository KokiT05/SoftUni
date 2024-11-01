using System;
using System.Data;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("bear");
            Console.WriteLine(bear.Name);
        }
    }
}