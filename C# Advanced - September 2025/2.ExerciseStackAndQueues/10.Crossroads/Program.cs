int greenLight = int.Parse(Console.ReadLine()!);
int freeWindow =  int.Parse(Console.ReadLine()!);

Queue<char> carsByChars = new Queue<char>();
Queue<string> carsName = new Queue<string>();

int carsPassed = 0;

string command = Console.ReadLine()!;
//while (command != "END")
//{
//	if (command == "green")
//	{
//		for (int i = 1; i <= greenLight && carsByChars.Count > 0; i++)
//		{
//			if (carsByChars.Peek() == ' ')
//			{
//				carsPassed++;
//				carsName.Dequeue();
//                carsByChars.Dequeue();
//            }

//			if (carsByChars.Count > 0)
//			{
//                carsByChars.Dequeue();
//            }
//		}

//		for (int i = 1; i <= freeWindow && carsByChars.Count > 0; i++)
//		{
//			if (carsByChars.Peek() == ' ')
//			{
//				carsPassed++;
//				carsName.Dequeue();
//				break;
//			}
//            carsByChars.Dequeue();
//		}

//		if (carsByChars.Count > 0 && carsByChars.Peek() != ' ')
//		{
//            Console.WriteLine("A crash happened!");
//            Console.WriteLine($"{carsName.Peek()} was hit at {carsByChars.Peek()}.");
//			return;
//		}
//	}
//	else
//	{
//		for (int i = 0; i < command.Length; i++)
//		{
//            carsByChars.Enqueue(command[i]);
//		}
//        carsByChars.Enqueue(' ');

//		carsName.Enqueue(command);
//	}

//	command = Console.ReadLine()!;
//}

//Console.WriteLine($"Everyone is safe.");
//Console.WriteLine($"{carsPassed} total cars passed the crossroads.");