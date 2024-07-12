namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();

                OperationCommand(command, songsQueue);
            }

            Console.WriteLine($"No more songs!");
        }

        static void AddSong(string song, Queue<string> songs)
        {
            if (songs.Contains(song))
            {
                Console.WriteLine($"{song} is already contained!");
            }
            else
            {
                songs.Enqueue(song);
            }
        }

        static void OperationCommand(string command, Queue<string> songsQueue)
        {
            if (command.Contains("Play"))
            {
                songsQueue.Dequeue();
            }
            else if (command.Contains("Add"))
            {
                string song = GetSong(command);
                AddSong(song, songsQueue);
            }
            else if (command.Contains("Show"))
            {
                Console.WriteLine(string.Join(", ", songsQueue));
            }
        }

        static string GetSong(string inputData)
        {
            int indexOfSong = inputData.IndexOf(" ") + 1;
            string song = inputData.Substring(indexOfSong, inputData.Length - indexOfSong);
            return song;
        }
    }
}
