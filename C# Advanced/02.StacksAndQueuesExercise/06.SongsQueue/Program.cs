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

                if (command.Contains("Play"))
                {
                    songsQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    int indexOfSong = command.IndexOf(" ") + 1;
                    string song = command.Substring(indexOfSong, command.Length - indexOfSong);
                    if (songsQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(song);
                    }

                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine($"No more songs!");
        }
    }
}
