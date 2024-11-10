namespace _02.Cars // Cars
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Grey");
            Console.WriteLine(seat);
            Console.WriteLine(seat.Start());
            Console.WriteLine(seat.Stop());

            ICar tesla = new Tesla("Model 3", "Red", 2);
            Console.WriteLine(tesla);
            Console.WriteLine(tesla.Start());
            Console.WriteLine(tesla.Stop());


        }
    }
}
