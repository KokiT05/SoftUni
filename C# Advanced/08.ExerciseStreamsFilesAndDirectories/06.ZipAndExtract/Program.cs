using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = "../../";
            //string zipPath = "../../../newZipFile.zip";

            //ZipFile.CreateFromDirectory(path, zipPath);
            //ZipFile.ExtractToDirectory("../../../newZipFile.zip", "C:\\Users\\konst\\Desktop");

            ZipArchive zipArchive;
            using (zipArchive = ZipFile.Open("../../../zipFile.zip", ZipArchiveMode.Create))
            {
                ZipArchiveEntry zipArchiveEntry = 
                    zipArchive.CreateEntryFromFile("../../../NewCopyMe.png", "zipNewCopyMe.png");
                zipArchive.Dispose();
            }

            ZipFile.ExtractToDirectory("../../../zipFile.zip", "C:\\Users\\konst\\Desktop");
        }
    }
}
