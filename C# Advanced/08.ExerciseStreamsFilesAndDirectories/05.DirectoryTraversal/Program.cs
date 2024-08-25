using System.Text;

namespace _05.DirectoryTraversal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> fileInformations = new Dictionary<string, List<string>>();
            string[] files = Directory.GetFiles
            ("C:\\Users\\konst\\Desktop\\SoftUni\\C# Advanced\\08.ExerciseStreamsFilesAndDirectories\\05.DirectoryTraversal");

            FindFiles(files, fileInformations);

            fileInformations = fileInformations
                                .OrderByDescending(v => v.Value.Count)
                                .ThenBy(k => k.Key)
                                .ToDictionary(k => k.Key, v => v.Value);

            string result = CreateText(fileInformations);

            File.WriteAllText
            ("C:\\Users\\konst\\Desktop\\SoftUni\\C# Advanced\\08.ExerciseStreamsFilesAndDirectories\\05.DirectoryTraversal\\ResultText.txt", result);
        }

        static void FindFiles(string[] files, Dictionary<string, List<string>> fileInformations)
        {
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!fileInformations.ContainsKey(fileInfo.Extension))
                {
                    fileInformations.Add(fileInfo.Extension, new List<string>());
                }

                fileInformations[fileInfo.Extension].Add($"{fileInfo.Name} - {(fileInfo.Length / 1024.0):f3}");
            }
        }

        static string CreateText(Dictionary<string, List<string>> fileInformations)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (KeyValuePair<string, List<string>> file in fileInformations)
            {
                stringBuilder.AppendLine(file.Key);
                foreach (string information in file.Value)
                {
                    stringBuilder.AppendLine($"--{information}kb");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
