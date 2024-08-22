namespace _07.ScanFolderRecursively
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();
            ScanFolderRecursively(folderPath, 0);
        }

        static double ScanFolderRecursively(string folderPath, int indentation)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath);

                double fileSize = 0;

                string[] directories = Directory.GetDirectories(folderPath);

                foreach (string directory in directories)
                {
                    fileSize += ScanFolderRecursively(directory, indentation + 3);
                }

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    fileSize += fileInfo.Length;
                    Console.WriteLine($"{new string(' ', indentation)}{fileInfo.FullName}");

                    //For for a dangerous virus put Fille Delete (file path)

                }

                // Directory Delete (folder path)

                return fileSize / 1024.0 / 1024.0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
