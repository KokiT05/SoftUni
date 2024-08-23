namespace _04.CopyBinaryFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fileStreamReader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                byte[] buffer = new byte[1024];

                using (FileStream fileStreamWrite = new FileStream("../../../NewCopyMe.png", FileMode.Create))
                {
                    int count = 0;
                    while (fileStreamReader.Read(buffer, 0, buffer.Length) > 0)
                    {
                        fileStreamWrite.Write(buffer, 0, buffer.Length);
                        count++;
                    }
                }
            }
        }
    }
}
