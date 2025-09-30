int n = int.Parse(Console.ReadLine()!);

Queue<string> cars = new Queue<string>();
int passedCars = 0;

string command = Console.ReadLine()!;
while (command.ToLower() != "end")
{
    if(command == "green")
    {
        for (int i = 1; i <= n && cars.Count > 0; i++)
        {
            Console.WriteLine($"{cars.Dequeue()} passed!");
            passedCars++;
        }
    }
    else
    {
        cars.Enqueue(command);
    }

    command = Console.ReadLine()!;
}

Console.WriteLine($"{passedCars} cars passed the crossroads.");