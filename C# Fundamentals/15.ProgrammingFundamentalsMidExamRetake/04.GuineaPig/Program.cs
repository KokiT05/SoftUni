namespace _04.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double quantityFood = double.Parse(Console.ReadLine());
            double quantityHal = double.Parse(Console.ReadLine());
            double quantityCover = double.Parse(Console.ReadLine());
            double guineaWeight = double.Parse(Console.ReadLine());

            quantityFood = quantityFood * 1000;
            quantityHal = quantityHal * 1000;
            bool isEnought = true;

            int count = 0;
            while (count != 30)
            {
                count++;
                quantityFood -= 300;

                if (count % 2 == 0)
                {
                    quantityHal -= (quantityFood * 0.05);
                }

                if (count % 3 == 0)
                {
                    quantityCover = (quantityCover - (guineaWeight * 1 / 3));
                }

                if (quantityCover <= 0 || quantityFood <= 0 || quantityHal <= 0)
                {
                    isEnought = false;
                    break;
                }
            }

            if (isEnought)
            {
                Console.WriteLine("Everything is fine! Puppy is happy! " +
                    $"Food: {(quantityFood / 1000):f2}, Hay: {(quantityHal / 1000):f2}, Cover: {quantityCover:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}