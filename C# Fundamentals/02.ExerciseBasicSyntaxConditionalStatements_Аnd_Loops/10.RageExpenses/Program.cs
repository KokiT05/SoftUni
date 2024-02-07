using System;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashesHeadset = lostGames / 2;
            int trashesMouse = lostGames / 3;
            int trashesKeyboard = lostGames / 6;
            int trashesDisplay = trashesKeyboard / 2;

            double totalPrice = (trashesDisplay * displayPrice) + (trashesHeadset * headsetPrice)
                                + (trashesKeyboard * keyboardPrice) + (trashesMouse * mousePrice);

            Console.WriteLine($"Rage expenses: {totalPrice:f2}lv.");
        }
    }
}
