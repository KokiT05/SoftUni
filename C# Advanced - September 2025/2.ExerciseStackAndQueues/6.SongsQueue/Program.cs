using System.Linq;

string[] inputSongs = Console.ReadLine()!.Split(", ");

Queue<string> songs = new Queue<string>(inputSongs);

string command = string.Empty;
while (songs.Count > 0)
{
    command = Console.ReadLine()!;

	if (command == "Play")
	{
		songs.Dequeue();
	}
	else if (command == "Show")
	{
        Console.WriteLine(string.Join(", ", songs));
	}
	else if (command.StartsWith("Add"))
	{
		string song = command.Substring(4, command.Length - 4);

		if (songs.Contains(song))
		{
			Console.WriteLine($"{song} is already contained!");
        }
		else
		{
            songs.Enqueue(song);
        }
	}
}

Console.WriteLine("No more songs!");