int greenLight = int.Parse(Console.ReadLine()!);
int freeWindow =  int.Parse(Console.ReadLine()!);

Queue<char> carsByChars = new Queue<char>();
Queue<string> carsName = new Queue<string>();

int currentTimeToPass = 0;
string currentCar = string.Empty;
int crashIndex = 0;
int carsPassed = 0;

bool inFreeWindowsTime = false;

string command = Console.ReadLine()!;
while (command != "END")
{
	if (command == "green")
	{
        currentTimeToPass = greenLight;

        while (currentTimeToPass > 0 && carsName.Count > 0 && inFreeWindowsTime == false)
		{
            currentCar = carsName.Peek();

            currentTimeToPass -= currentCar.Length;

			if (currentTimeToPass < 0)
			{
				currentTimeToPass += freeWindow;
                inFreeWindowsTime = true;

                if (currentTimeToPass >= 0)
                {
                    carsPassed++;
                    carsName.Dequeue();
                }
            }
            else
            {
                carsPassed++;
                carsName.Dequeue();
            }

            if (currentTimeToPass < 0)
            {
                crashIndex = currentCar.Length + currentTimeToPass;
                Console.WriteLine($"A crash happened!");
                Console.WriteLine($"{carsName.Peek()} was hit at {currentCar[crashIndex]}.");
                return;
            }
        }
	}
	else
	{
		carsName.Enqueue(command);
	}

    command = Console.ReadLine()!;
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carsPassed} total cars passed the crossroads.");