using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster soulMaster = new SoulMaster("SoulMaster", 14);
            Console.WriteLine(soulMaster);
        }
    }
}