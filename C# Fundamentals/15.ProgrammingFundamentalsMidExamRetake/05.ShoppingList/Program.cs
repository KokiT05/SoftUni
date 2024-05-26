using System.Diagnostics.Tracing;

namespace _05.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            string input = Console.ReadLine();
            while (input != "Go Shopping!")
            {
                string[] inputData = input.Split(' ');
                string command = inputData[0];
                string item = inputData[1];

                if (command == "Urgent" && !IsExists(item, list))
                {
                    list.Insert(0, item);
                }
                else if (command == "Unnecessary" && IsExists(item, list))
                {
                    list.Remove(item);
                }
                else if (command == "Correct" && IsExists(item, list))
                {
                    int index = list.IndexOf(item);
                    list[index] = inputData[2];
                }
                else if (command == "Rearrange" && IsExists(item, list))
                {
                    int index = list.IndexOf(item);
                    string currentItem = list[index];
                    list.Remove(item);
                    list.Add(currentItem);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }

        static bool IsExists(string itemNamem, List<string> collection)
        {
            if (collection.Contains(itemNamem))
            {
                return true;
            }

            return false;
        }
    }
}