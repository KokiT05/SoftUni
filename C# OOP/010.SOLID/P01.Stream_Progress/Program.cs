using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            string artist = "Ivan";
            string album = "The monkey";
            int length = 2891;
            int bytesSent = 76;
            IProgress music = new Music(artist, album, length, bytesSent);

            string fileName = "Game";
            int fileLength = 4121;
            int fileBytesSent = 51;
            IProgress file = new File(fileName, fileLength, fileBytesSent);

            StreamProgressInfo musicProgress = new StreamProgressInfo(music);
            StreamProgressInfo fileProgress = new StreamProgressInfo(file);


            int progressValue = 0;

            while (progressValue < 100)
            {
                Console.WriteLine($"{progressValue}%");
                progressValue += musicProgress.CalculateCurrentPercent();
            }

            progressValue = 0;
            while (progressValue < 100)
            {
                Console.WriteLine($"{progressValue}%");
                progressValue += fileProgress.CalculateCurrentPercent();
            }
        }
    }
}
