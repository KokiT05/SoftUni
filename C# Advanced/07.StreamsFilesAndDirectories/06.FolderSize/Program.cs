namespace _06.FolderSize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();

            string[] files = Directory.GetFiles(folderPath);
            double fileSize = 0;

            string[] directories = Directory.GetDirectories(folderPath);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                fileSize += fileInfo.Length;
                Console.WriteLine($"Name: {fileInfo.FullName}");
                Console.WriteLine($"Extension: {fileInfo.Extension}");
                Console.WriteLine($"Length: {fileInfo.Length}");
            }
        }
    }
}
