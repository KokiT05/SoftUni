namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            int countOfBulletsFired = 0;
            int bulletsFired = 0;
            while (locksQueue.Count > 0 && bulletsStack.Count > 0)
            {
                int bullet = bulletsStack.Pop();
                countOfBulletsFired++;
                if (bullet <= locksQueue.Peek())
                {
                    Console.WriteLine($"Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }

                bulletsFired++;
                if (bulletsFired == sizeOfGunBarrel && bulletsStack.Count > 0)
                {
                    bulletsFired = 0;
                    Console.WriteLine($"Reloading!");
                }
            }

            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int moneyEarned = valueOfIntelligence - (countOfBulletsFired * priceOfBullet);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
