namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();
            while (command.ToLower() != "generate")
            {
                string[] commandArg = command.Split(">>>");
                string instruction = commandArg[0];

                if (instruction.ToLower() == "contains")
                {
                    string substring = commandArg[1];
                    string result = activationKey.Contains(substring) ?
                    $"{activationKey} contains {substring}" : "Substring not found!";
                    Console.WriteLine(result);
                }
                else if (instruction.ToLower() == "flip" && commandArg[1].ToLower() == "upper")
                {
                    int startIndex = int.Parse(commandArg[2]);
                    int endIndex = int.Parse(commandArg[3]);

                    string oldSubString = string.Empty;
                    string newResult = string.Empty;

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        newResult += char.ToUpper(activationKey[i]);
                        oldSubString += activationKey[i];
                    }

                    activationKey = activationKey.Replace(oldSubString, newResult);
                    Console.WriteLine(activationKey);

                }
                else if (instruction.ToLower() == "flip" && commandArg[1].ToLower() == "lower")
                {
                    int startIndex = int.Parse(commandArg[2]);
                    int endIndex = int.Parse(commandArg[3]);

                    string oldSubString = string.Empty;
                    string newResult = string.Empty;

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        newResult += char.ToLower(activationKey[i]);
                        oldSubString += activationKey[i];
                    }

                    activationKey = activationKey.Replace(oldSubString, newResult);
                    Console.WriteLine(activationKey);
                }
                else if (instruction.ToLower() == "slice")
                {
                    int startIndex = int.Parse(commandArg[1]);
                    int endIndex = int.Parse(commandArg[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}