namespace _3.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> listOfSongs = new List<Song>(numberOfSongs);
            string[] dataInformation = new string[2];

            for (int i = 0; i < numberOfSongs; i++)
            {
                dataInformation = Console.ReadLine().Split('_', StringSplitOptions.RemoveEmptyEntries);
                Song song = new Song(dataInformation[0], dataInformation[1], dataInformation[2]);
                listOfSongs.Add(song);
            }

            string typeOfSong = Console.ReadLine();

            if (typeOfSong == "all")
            {
                foreach (Song itemOfList in listOfSongs)
                {
                    Console.WriteLine(itemOfList.Name);
                }
            }
            else
            {
                foreach (Song itemOfList in listOfSongs)
                {
                    if (itemOfList.TypeList == typeOfSong)
                    {
                        Console.WriteLine(itemOfList.Name);
                    }
                }
            }

        }
    }

    public class Song
    {
        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }

        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }


    }
}