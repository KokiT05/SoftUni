using System.Text;

namespace _05.DirectoryTraversal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, List<string>> fileInformations = new Dictionary<string, List<string>>();
            //string[] files = Directory.GetFiles
            //("C:\\Users\\konst\\Desktop\\SoftUni\\C# Advanced\\08.ExerciseStreamsFilesAndDirectories\\05.DirectoryTraversal");

            //FindFiles(files, fileInformations);

            //fileInformations = fileInformations
            //                    .OrderByDescending(v => v.Value.Count)
            //                    .ThenBy(k => k.Key)
            //                    .ToDictionary(k => k.Key, v => v.Value);

            //string result = CreateText(fileInformations);

            //File.WriteAllText
            //("C:\\Users\\konst\\Desktop\\SoftUni\\C# Advanced\\08.ExerciseStreamsFilesAndDirectories\\05.DirectoryTraversal\\ResultText.txt", result);

            string directoryPath = "../../../";
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesData =
                new Dictionary<string, Dictionary<string, double>>();

            foreach (string fullFileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fullFileName);
                string extension = fileInfo.Extension;
                string name = fileInfo.Name;
                long fileSize = fileInfo.Length;
                double kbSize = Math.Round(fileSize / 1024.0, 3);

                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }

                filesData[extension].Add(fileInfo.Name, kbSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedDictionary = 
                filesData.OrderByDescending(f => f.Value.Values.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            List<string> result = new List<string>();

            foreach (KeyValuePair<string, Dictionary<string, double>> item in sortedDictionary)
            {
                result.Add(item.Key);
                foreach (KeyValuePair<string, double> fileData in item.Value.OrderBy(kvp => kvp.Value))
                {
                    result.Add($"$--{fileData.Key} - {fileData.Value}kb");
                }
            }

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "report.txt");

            File.WriteAllLines(filePath, result);
        }

        //static void FindFiles(string[] files, Dictionary<string, List<string>> fileInformations)
        //{
        //    foreach (string file in files)
        //    {
        //        FileInfo fileInfo = new FileInfo(file);
        //        if (!fileInformations.ContainsKey(fileInfo.Extension))
        //        {
        //            fileInformations.Add(fileInfo.Extension, new List<string>());
        //        }

        //        fileInformations[fileInfo.Extension].Add($"{fileInfo.Name} - {(fileInfo.Length / 1024.0):f3}");
        //    }
        //}

        //static string CreateText(Dictionary<string, List<string>> fileInformations)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();

        //    foreach (KeyValuePair<string, List<string>> file in fileInformations)
        //    {
        //        stringBuilder.AppendLine(file.Key);
        //        foreach (string information in file.Value)
        //        {
        //            stringBuilder.AppendLine($"--{information}kb");
        //        }
        //    }

        //    return stringBuilder.ToString();
        //}
    }
}
