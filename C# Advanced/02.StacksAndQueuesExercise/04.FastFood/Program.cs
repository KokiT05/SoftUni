namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            EnoughFood(ordersQueue, quantityOfFood);
        }

        public static void EnoughFood(Queue<int> orders, int quantityOfFood)
        {
            int biggestOrder = orders.Max(); ;
            while (orders.Count > 0)
            {
                if (quantityOfFood - orders.Peek() >= 0)
                {
                    quantityOfFood = quantityOfFood - orders.Dequeue();
                }
                else
                {
                    Console.WriteLine(biggestOrder);
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    break;
                }
            }

            CompleteOrders(orders, biggestOrder);
        }

        static void CompleteOrders(Queue<int> orders, int biggestOrder) 
        {

            if (orders.Any() == false)
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }
        }
    }
}
