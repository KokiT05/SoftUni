using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../";
            string zipPath = "../../../newZipFile.zip";

            ZipFile.CreateFromDirectory(path, zipPath);
            ZipFile.ExtractToDirectory("../../../newZipFile.zip", "C:\\Users\\konst\\Desktop");
        }
    }
}
