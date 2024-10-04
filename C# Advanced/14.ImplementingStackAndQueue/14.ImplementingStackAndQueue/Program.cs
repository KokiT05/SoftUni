using System.Threading.Channels;

namespace _14.ImplementingStackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomList customList = new CustomList();

            //customList.Add(1);
            //customList.Add(2);
            //customList.Add(3);
            //customList.Add(4);

            //Console.WriteLine(customList.Count);
            //for (int i = 0; i < customList.Count; i++)
            //{
            //    Console.Write(customList[i] + " ");
            //}
            //Console.WriteLine();
            //customList.Insert(1, 2222);

            //Console.WriteLine(customList.Count);
            //for (int i = 0; i < customList.Count; i++)
            //{
            //    Console.Write(customList[i] + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(customList.Contains(1));
            //Console.WriteLine(customList.Contains(1123));

            //customList.Swap(0, 4);
            //for (int i = 0; i < customList.Count; i++)
            //{
            //    Console.Write(customList[i] + " ");
            //}

            CustomStack customStack = new CustomStack();
            customStack.Push(6);
            customStack.Push(7);
            customStack.Push(8);
            customStack.Push(9);

            customStack.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Length: " + customStack.Count);

            Console.WriteLine($"Last element {customStack.Peek()}");
            Console.WriteLine($"Pop element {customStack.Pop()}");
            Console.WriteLine($"Last element {customStack.Peek()}");
            customStack.Push(32);
            customStack.Push(3122);

            customStack.ForEach(e => Console.WriteLine(e));

            Console.WriteLine($"Last element {customStack.Peek()}");
            customStack.Pop();
            customStack.Pop();
            customStack.Pop();

            customStack.MySelect(n => n * 2);
            customStack.ForEach(x => Console.WriteLine(x));
        }
    }
}
