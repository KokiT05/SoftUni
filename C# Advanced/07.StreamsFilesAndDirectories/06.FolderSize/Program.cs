namespace _06.FolderSize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();

            string[] files = Directory.GetFiles(folderPath);

            long fileSize = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                fileSize += fileInfo.Length;

            }

            Console.WriteLine(fileSize / 1024.0 / 1024.0);
        }
    }
}
